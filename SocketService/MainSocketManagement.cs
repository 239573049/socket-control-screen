using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketService
{
    public class MainSocketManagement
    {
        private static bool IsClose= true;
        private RichTextBox log;
        private ComboBox socketData;
        string ClipboardData;
        private Thread t;
        public void ConnectSocket(Dictionary<string,Socket> socketList,Socket mainSocket, RichTextBox log,ComboBox socketData)
        {
            this.socketData = socketData;
            this.log = log;
            new Thread(delegate () {
                while (IsClose) {
                    try {
                        var socket = mainSocket.Accept();
                        log.AppendText($"{socket.RemoteEndPoint}连接服务器成功");
                        socketList.Add(socket.RemoteEndPoint.ToString(), socket);
                        socketData.Items.Add(socket.RemoteEndPoint.ToString());
                        t = new Thread(ReceiveSocket);
                        t.ApartmentState = ApartmentState.STA;
                        t.Start(socket);
                    }
                    catch (SocketException) {

                    }

                }
            }).Start();
            new Thread(delegate () {
                while (IsClose) {
                    var clipboar = Clipboard.GetText();
                    if (ClipboardData!= clipboar) {
                        var data = new MainSocket();
                        data.Data = clipboar;
                        data.Statue = MainSocketEnum.Clipboard;
                        foreach (var d in socketList) {
                            d.Value.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
                        }
                    }
                    Thread.Sleep(200);
                }
            });
        }
        public void ReceiveSocket(object socket)
        {
            var sockets = socket as Socket;
            var ip=sockets.RemoteEndPoint.ToString();
            while (IsClose) {
                try {
                    sockets.Receive(new byte[0]);
                    var len = sockets.Available;
                    if (len == 0) {
                        socketData.Items.Remove(ip);
                        log.AppendText($"{ip}断开连接\r\n");
                        return;
                    }
                    byte[] bytes = new byte[len];
                    sockets.Receive(bytes);
                    var mainSocket = JsonConvert.DeserializeObject<MainSocket>(Encoding.UTF8.GetString(bytes));
                    switch (mainSocket.Statue) {
                        case MainSocketEnum.File:
                            FileSocket(sockets, Convert.ToInt64(mainSocket.Data), mainSocket.Name);
                            break;
                        case MainSocketEnum.Clipboard:
                            if (ClipboardData != null && ClipboardData != mainSocket.Data) {
                                Clipboard.SetText(mainSocket.Data);
                            }
                            break;
                        case MainSocketEnum.Screen:
                            break;
                        case MainSocketEnum.Keyboard:
                            break;
                        case MainSocketEnum.LeftClick:
                            break;
                        default:
                            throw new Exception($"未设置状态值{mainSocket.Statue}");
                    }
                }
                catch (JsonReaderException) {
                    Debug.WriteLine("json转换异常抛出异常不处理");
                }catch (SocketException) {
                    socketData.Items.Remove(ip);
                    log.AppendText($"{ip}断开连接");
                    return;
                }
            }
        }
        public void SendFileSocket(Socket socket,string fileName)
        {
            var file = File.Open(fileName,FileMode.Open);
            var length = file.Length;
            var name = file.Name.Split('\\')[file.Name.Split('\\').Length-1];
            var socketData = new MainSocket()
            {
                Data=file.Length.ToString(),
                Name= name,
                Statue= MainSocketEnum.File
            };
            var json = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(socketData));
            socket.Send(json);
            Thread.Sleep(50);
            var sw=new Stopwatch();
            long fileSize = 1024 * 60;
            if (file.Length < fileSize) {
                fileSize = file.Length;
            }
            var bytes=new byte[fileSize];
            var len = 0;
            sw.Start();
            while (len < file.Length) {
                if (file.Length - len < bytes.Length) {
                    bytes=new byte[file.Length-len]; 
                }
                len += file.Read(bytes, 0, bytes.Length);
                socket.Send(bytes);
            }
            sw.Stop();
            file.Close();
            log.AppendText($"向{socket.RemoteEndPoint}传输文件{name} 成功;耗时:{sw.ElapsedMilliseconds}ms\r\n");
        }
        /// <summary>
        /// 文件Socket处理
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="length"></param>
        private void FileSocket(Socket socket,long length,string name)
        {
            socket.Receive(new byte[0]);
            var file = File.Create(name);
            var sw = new Stopwatch();
            sw.Start();
            int len = 0;
            if (length > 1024 * 1024 * 10) {
                byte[] bytes = new byte[1024 * 60];
                while (len < length) {
                    if (length - len < bytes.Length) {
                        bytes = new byte[length - len];
                    }
                    len += socket.Receive(bytes);
                    file.Write(bytes, 0, bytes.Length);
                }
            }
            else {
                byte[] bytes = new byte[1024 * 60];
                while (len < length) {
                    if (length - len < bytes.Length) {
                        bytes = new byte[length - len];
                    }
                    len += socket.Receive(bytes);
                    file.Write(bytes, 0, bytes.Length);
                }
            }
            sw.Stop();
            log.AppendText($"{socket.LocalEndPoint}：文件大小{Math.Round(((decimal)file.Length / (decimal)1024)/(decimal)1024, 2)}MB,上传文件耗时{sw.ElapsedMilliseconds}ms。\r\n");
            file.Close();
        }
        public void Close()
        {
            IsClose = false;
            t = null;
        }
    }
}
