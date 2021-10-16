using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.IO;
namespace SocketService.WinForm
{
    public partial class SocketClient : Form
    {
        public SocketClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private bool isOpenSocket = false;
        private Socket MainSocket;
        private bool isClose = true;
        public static PictureBox iamges;
        private bool isScreen = true;
        public Socket socketScreen;
        string ClipboardData=null;
        private void openSocket_Click(object sender, EventArgs e)
        {
            try {
                var openSocket = sender as Button;
                if (!isOpenSocket) {
                    MainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip.Text), Convert.ToInt32(port.Text));
                    MainSocket.Connect(endPoint);
                    new Thread(delegate () { Review(); }) { IsBackground=true}.Start();
                    new Thread(delegate () {
                        while (isScreen) {
                            string data = Clipboard.GetText();
                            var main = new MainSocket();
                            main.Data = data;
                            main.Statue = MainSocketEnum.Clipboard;
                            if (data != ClipboardData) {
                                MainSocket.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(main)));
                            }
                            Thread.Sleep(200);
                        }
                    })
                    { IsBackground = true }.Start();
                }
                else {
                    isScreen = false;
                    MainSocket.Close();
                    if (socketScreen != null) {
                        socketScreen.Close();
                        socketScreen.Dispose();
                    }
                }
                openSocket.Text = isOpenSocket ? "连接服务器" : "断开服务器连接";
                isOpenSocket = !isOpenSocket;
            }
            catch (Exception es) {
                MessageBox.Show(es.Message);
            }
        }
        public void Review()
        {
            while (isClose) {
                try {
                    MainSocket.Receive(new byte[0]);
                    var btes = new byte[MainSocket.Available];
                    MainSocket.Receive(btes);
                    var strings = Encoding.UTF8.GetString(btes);
                    MainSocket data = null;
                    try {
                        data = JsonConvert.DeserializeObject<MainSocket>(strings);
                    }
                    catch (JsonSerializationException j) {
                        Debug.WriteLine(j.Message);
                        continue;
                    }
                    catch (JsonReaderException s) {

                        Debug.WriteLine(s.Message);
                        continue;
                    }
                    if (data == null) continue;
                    switch (data.Statue) {
                        case MainSocketEnum.File:
                            var sw = FileSocket(MainSocket, Convert.ToInt32(data.Data), data.Name);
                            MessageBox.Show($"服务器发送文件接收成功；文件名称：{data.Name}；文件大小：{Math.Round(Convert.ToDecimal(data.Data) / (decimal)1024 / (decimal)1024, 2)}MB；接收耗时：{sw}ms");
                            break;
                        case MainSocketEnum.Clipboard:
                            if(ClipboardData!=null&& ClipboardData != data.Data) {
                                Clipboard.SetText(data.Data);
                            }
                            break;
                        case MainSocketEnum.Screen:
                            new Thread(delegate ()
                            {
                                ScreenSockets(Convert.ToInt32(data.Data));
                            })
                            { IsBackground = true }.Start();
                            break;
                        case MainSocketEnum.Keyboard:
                            break;
                        case MainSocketEnum.LeftClick:
                            LeftClickSocket(data);
                            break;
                        case MainSocketEnum.LeftClicks:
                            LeftClickSocket(data, true);
                            break;
                        case MainSocketEnum.RightClick:
                            RightClickSocket(data);
                            break;
                        case MainSocketEnum.RightClicks:
                            RightClickSocket(data, true);
                            break;
                        case MainSocketEnum.Move:
                            MoveSocket(data);
                            break;
                        case MainSocketEnum.PressLeft:
                            PressLeftSocket(data);
                            break;
                        case MainSocketEnum.LeftUp:
                            LeftUpSocket(data);
                            break;
                        case MainSocketEnum.PressRight:
                            PressRightSocket(data);
                            break;
                        case MainSocketEnum.RightUp:
                            RightUpSocket(data);
                            break;
                        case MainSocketEnum.Break:
                            MessageBox.Show("断开服务器连接");
                            SocketClose();
                            break;
                        case MainSocketEnum.ListedFiles:
                            ListedFiles(data.Name);
                            break;
                        case MainSocketEnum.DemandFile:
                            SendFileSocket(MainSocket, data.Name,data.Data);
                            break;
                        default:
                            break;
                    }
                }
                catch (SocketException e) {
                    if (e.Message == "远程主机强迫关闭了一个现有的连接。") {
                        SocketClose();
                        return;
                    }
                }
                catch (ObjectDisposedException o) {
                    if (o.Message.Contains("无法访问已释放的对象")) {
                        SocketClose();
                        return;
                    }
                }

            }
        }
        public void ListedFiles(string data)
        {
            var listedFilesEntity = new List<ListedFilesEntity>();
            if (string.IsNullOrEmpty(data))
            {
                var files= Directory.GetLogicalDrives().Select(a=>new ListedFilesEntity {Name=a,IsFile=false }).ToList();
                listedFilesEntity.AddRange(files);
                var mainData = new MainSocket() {
                    Data = JsonConvert.SerializeObject(listedFilesEntity),
                    Statue=MainSocketEnum.ListedFiles,
                };
                var bytes=Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainData));
                MainSocket.Send(bytes);
                return;
            }
            else
            {
                if (Directory.Exists(data))
                {
                    try
                    {

                        var folder = new DirectoryInfo(data);
                        foreach (var file in folder.GetDirectories())
                        {
                            listedFilesEntity.Add(new ListedFilesEntity { Name = file.Name, IsFile = false, OlutePath = file.FullName });
                        }
                        foreach (var file in folder.GetFiles())
                        {
                            listedFilesEntity.Add(new ListedFilesEntity { Name = file.Name, IsFile = true, OlutePath = file.FullName });
                        }
                        var mainData = new MainSocket()
                        {
                            Data = JsonConvert.SerializeObject(listedFilesEntity),
                            Statue = MainSocketEnum.ListedFiles,
                        };
                        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainData));
                        MainSocket.Send(bytes);
                        return;
                    }
                    catch (UnauthorizedAccessException un)
                    {
                        var mainData = new MainSocket()
                        {
                            Data = "false",
                            Name = un.Message,
                            Statue = MainSocketEnum.FilesExists,
                        };
                        var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainData));
                        MainSocket.Send(bytes);
                        return;
                    }
                }
                else
                {
                    var mainData = new MainSocket() {
                        Data="false",
                        Name= "文件路径不存在",
                        Statue=MainSocketEnum.FilesExists,
                    };
                    var bytes=Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainData));
                    MainSocket.Send(bytes);
                    return;
                }
            }
        }

        public void MoveSocket(MainSocket data)
        {
            var coordinate = data.Data.Split('|');
            if (coordinate.Length == 2) {
                var heigth = int.Parse(coordinate[0]);
                var width = int.Parse(coordinate[1]);
                ControlUtil.MoveEvent(width, heigth);
            }
        }

        public void PressLeftSocket(MainSocket data)
        {
            var coordinate = data.Data.Split('|');
            if (coordinate.Length == 2) {
                var heigth = int.Parse(coordinate[0]);
                var width = int.Parse(coordinate[1]);
                ControlUtil.PressLeft(width, heigth);
            }
        }
        public void LeftUpSocket(MainSocket data)
        {
            var coordinate = data.Data.Split('|');
            if (coordinate.Length == 2) {
                var heigth = int.Parse(coordinate[0]);
                var width = int.Parse(coordinate[1]);
                ControlUtil.LeftUp(width, heigth);
            }
        }
        public void PressRightSocket(MainSocket data)
        {
            var coordinate = data.Data.Split('|');
            if (coordinate.Length == 2) {
                var heigth = int.Parse(coordinate[0]);
                var width = int.Parse(coordinate[1]);
                ControlUtil.PressRight(width, heigth);
            }
        }
        public void RightUpSocket(MainSocket data)
        {
            var coordinate = data.Data.Split('|');
            if (coordinate.Length == 2) {
                var heigth = int.Parse(coordinate[0]);
                var width = int.Parse(coordinate[1]);
                ControlUtil.RightUp(width, heigth);
            }
        }
        public void RightClickSocket(MainSocket data, bool isClikes = false)
        {
            var coordinate = data.Data.Split('|');
            if (coordinate.Length == 2) {
                var heigth = int.Parse(coordinate[0]);
                var width = int.Parse(coordinate[1]);
                if (isClikes) {
                    ControlUtil.RightDownClickEvents(width, heigth, 0);
                }
                else {
                    ControlUtil.RightDownClickEvent(width, heigth, 0);
                }
            }
        }
        public void LeftClickSocket(MainSocket data, bool isClikes = false)
        {
            var coordinate = data.Data.Split('|');
            if (coordinate.Length == 2) {
                var heigth = int.Parse(coordinate[0]);
                var width = int.Parse(coordinate[1]);
                if (isClikes) {
                    ControlUtil.MouseLefClickEvents(width, heigth, 0);
                }
                else {
                    ControlUtil.MouseLefClickEvent(width, heigth, 0);
                }
            }

        }
        /// <summary>
        /// 文件Socket处理
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="length"></param>
        private long FileSocket(Socket socket, long length, string name)
        {
            var file = System.IO.File.Create(name);
            var sw = new Stopwatch();
            socket.Receive(new byte[0]);
            sw.Start();
            int len = 0;
            if (length > 1024 * 1024 * 10) {
                byte[] bytes = new byte[1024 * 60];
                while (len < length) {
                    var size = length - len;
                    if (size < bytes.Length) {
                        bytes = new byte[size];
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
            file.Close();
            return sw.ElapsedMilliseconds;
        }
        public void SocketClose()
        {
            openSocket.Text = "连接服务器";
            Text = "";
            delayed.Text = "";
            isOpenSocket = false;
        }
        public void ScreenSockets(int port)
        {
            if (socketScreen == null) {

                socketScreen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketScreen.Connect(new IPEndPoint(IPAddress.Parse(ip.Text), port));
                isScreen = true;
            }

            new Thread(delegate ()
            {
                try {
                    while (isScreen) {
                        new Thread(accept) { IsBackground = true }.Start(socketScreen);
                    }
                }
                catch (SocketException e) {
                    Debug.WriteLine(e.Message);
                }
            }).Start();

        }
        public void accept(object obj)
        {
            Text = "服务端正在监控屏幕";
            var socket = obj as Socket;
            var bytes = new byte[1024];
            socket.Receive(bytes);
            var json = JsonConvert.DeserializeObject<MainSocket>(Encoding.UTF8.GetString(bytes));
            var size = Screen.AllScreens[0].Bounds.Size;
            ScreenUtil.size = size;
            if (json != null) {
                try {
                    while (isScreen) {
                        var sw = new Stopwatch();
                        sw.Start();
                        socket.Send( ScreenUtil.GetScreenByte());
                        sw.Stop();
                        GC.Collect();
                    }
                }
                catch (SocketException) {
                    isScreen = false;
                    socket.Close();
                    socket.Dispose();
                    socketScreen.Close();
                    socketScreen.Dispose();
                    socketScreen = null;
                    Text = "";
                    delayed.Text = "";
                }
            }
        }

        private void port_TextChanged(object sender, EventArgs e)
        {
            var port = sender as TextBox;
            if (string.IsNullOrEmpty(port.Text)) return;
            port.Text = Regex.Replace(port.Text, @"[^0-9]+", "");
            if (!string.IsNullOrEmpty(port.Text) && Convert.ToInt32(port.Text) > 65535) {
                port.Text = "65535";
            }
        }


        private void SendFile_Click(object sender, EventArgs e)
        {
            var dialog = openFile.ShowDialog();
            if (dialog == DialogResult.OK) {
                SocketClient.SendFileSocket(MainSocket,openFile.FileName, openFile.SafeFileName);
            }
        }
        public static void SendFileSocket(Socket socket,string path,string name)
        {
            var file =File.OpenRead(path);
            var mainSocket = new MainSocket()
            {
                Data = file.Length.ToString(),
                Name = name,
                Statue = MainSocketEnum.File
            };
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket));
            socket.Send(bytes);
            Thread.Sleep(50);
            long fileSize = 1024 * 60;
            if (file.Length < fileSize)
            {
                fileSize = file.Length;
            }
            bytes = new byte[fileSize];
            int len = 0;
            while (len < file.Length)
            {
                if (file.Length - len < bytes.Length)
                {
                    bytes = new byte[file.Length - len];
                }
                len += file.Read(bytes, 0, bytes.Length);
                socket.Send(bytes);
            }
            file.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClose = false;
        }

        private void returnService_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void returnServices()
        {
            isScreen = false;
            isClose = false;
            SocketForm.Visibles();
        }

        private void SocketClient_Load(object sender, EventArgs e)
        {
            sendFile.Enabled = false;
            new Thread(delegate ()
            {
                while (isClose)
                {
                    if (!string.IsNullOrEmpty(ip.Text) && !string.IsNullOrEmpty(port.Text) && isOpenSocket)
                    {
                        sendFile.Enabled = true;
                    }
                    else
                    {
                        sendFile.Enabled = false;
                    }
                    Thread.Sleep(100);
                }
            })
            {IsBackground=true }.Start();
        }

        private void SocketClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            returnServices();
        }

    }
}
