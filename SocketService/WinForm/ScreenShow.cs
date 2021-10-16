using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using Util;
using static System.Windows.Forms.AxHost;

namespace SocketService.WinForm
{
    public partial class ScreenShow : Form
    {
        public Socket ScreenSocket;
        public int Widths;
        public int Heights;
        public int Post;
        /// <summary>
        /// 客户端ip
        /// </summary>
        public string ClientIp;
        public string ip;
        bool isClose = true;
        public ScreenShow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void ScreenShow_Load(object sender, EventArgs e)
        {
            Size = new Size(Widths, Heights);
            new Thread(SocketData) { IsBackground=true}.Start();
        }
        public void SocketData()
        {
            //ScreenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //try {
            //    ScreenSocket.Connect(IPAddress.Any, Post);
            //}
            //catch (SocketException) {
            //    Thread.Sleep(2000);
            //    ScreenSocket.Connect(IPAddress.Any, Post);
            //}
            //ScreenSocket.Listen(int.MaxValue);
            new Thread(SrceenSocketPush).Start(ScreenSocket);
        }
        public void SrceenSocketPush(object obj)
        {
            try {
                var socket = obj as Socket;
                var mainSocket = new MainSocket();
                mainSocket.Name = "开始接收屏幕流";
                mainSocket.Statue = MainSocketEnum.Screen;
                var json = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket));
                socket.Send(json);
                var screenByte = new byte[1024*1024*6];
                try {
                    while (isClose) {
                        try {
                            var len= socket.Receive(screenByte);
                            if (len == 0) {
                                isClose = false;
                                ScreenSocket.Close();
                                ScreenSocket.Dispose();
                                SocketForm.GetForm.Visible = true;
                                SocketForm.isScreen = false;
                                SocketForm.getScreenBut.Text = "获取屏幕";
                                Close();
                                return;
                            }
                            images.Image =new Bitmap(new MemoryStream(screenByte.ToArray()));

                        }
                        catch (ArgumentException a) {
                            Debug.WriteLine(a.Message);
                        }
                        finally {
                            GC.Collect();
                        }
                    }
                }
                catch (SocketException e) {
                    Debug.WriteLine(e.Message);
                    return;
                }
            }
            catch (SocketException e) {
                if (e.Message == "你的主机中的软件中止了一个已建立的连接。") {
                    Debug.WriteLine(e.Message);
                    Close();
                }
            }

        }
        public void ScreenShow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Move;
            }
            else {
                e.Effect = DragDropEffects.None;
                MessageBox.Show("错误");
            }
        }
        public void ScreenShow_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 1) {
                    MessageBox.Show("只能拖动单个文件");
                    return;
                }
                else if (Directory.Exists(files[0])) {
                    MessageBox.Show("暂时无法发送文件夹");
                    return;
                }
                else if (files.Length == 0) {
                    MessageBox.Show("发送数据错误");
                    return;
                }
                var socket = SocketForm.sockets.FirstOrDefault(a => a.Key == ClientIp);
                if (socket.Value != null) {
                    SocketForm.mainSocketManagement.SendFileSocket(socket.Value, files[0]);
                }
            }
        }
        private void ScreenShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClose = false;
            ScreenSocket.Close();
            ScreenSocket.Dispose();
            SocketForm.GetForm.Visible = true;
            SocketForm.isScreen = false;
            SocketForm.getScreenBut.Text = "获取屏幕";
            SocketForm.OpenScreen.Remove(ClientIp);
        }

        private void images_MouseClick(object sender, MouseEventArgs e)
        {
            var socket = SocketForm.sockets.FirstOrDefault(a => a.Key == ClientIp);
            if (socket.Value != null) {
                var mainSocket = new MainSocket()
                {
                    Data = GetCoordinate(images.Image.Width, images.Image.Height, images.Width, images.Height, e.X, e.Y)
                };
                if (string.IsNullOrEmpty(mainSocket.Data)) return;
                if (e.Button == MouseButtons.Left) {
                    mainSocket.Statue = MainSocketEnum.LeftClick;
                }
                else if (e.Button == MouseButtons.Right) {
                    mainSocket.Statue = MainSocketEnum.RightClick;

                }
                else return;
                socket.Value.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket)));
            }
        }
        public string GetCoordinate(int imgWidth, int imgHeight, int PWidth, int pHeight, int clickX, int clickY)
        {
            decimal width = 0;
            decimal height = 0;
            var isWidth = (decimal)PWidth / (decimal)imgWidth;
            var isHeight = (decimal)pHeight / (decimal)imgHeight;
            var isSize = isWidth <= isHeight;
            if (isSize) {
                width = imgWidth * (isWidth);
                height = imgHeight * (isWidth);
            }
            else {
                width = imgWidth * (isHeight);
                height = imgHeight * (isHeight);
            }
            var w = (PWidth - width) / 2;
            var h = (pHeight - height) / 2;
            h = ((decimal)imgHeight / height) * (clickY - h);
            w = ((decimal)imgWidth / width) * (clickX - w);
            if (h < 0 || w < 0) return "";
            if (h > imgHeight+1 || w > imgWidth+1) return "";
            return $"{(int)h}|{(int)w}";
        }
        private void images_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var socket = SocketForm.sockets.FirstOrDefault(a => a.Key == ClientIp);
            if (socket.Value != null) {
                var mainSocket = new MainSocket()
                {
                    Data = GetCoordinate(images.Image.Width, images.Image.Height, images.Width, images.Height, e.X, e.Y)
                };
                if (string.IsNullOrEmpty(mainSocket.Data)) return;
                if (e.Button == MouseButtons.Left) {
                    mainSocket.Statue = MainSocketEnum.LeftClicks;
                }
                else if (e.Button == MouseButtons.Right) {
                    mainSocket.Statue = MainSocketEnum.RightClicks;
                }
                else return;
                socket.Value.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket)));
            }
        }

        private void images_MouseMove(object sender, MouseEventArgs e)
        {
            var socket = SocketForm.sockets.FirstOrDefault(a => a.Key == ClientIp);
            if (socket.Value != null && images.Image != null) {
                var mainSocket = new MainSocket()
                {
                    Statue = MainSocketEnum.Move,
                    Data = GetCoordinate(images.Image.Width, images.Image.Height, images.Width, images.Height, e.X, e.Y)
                };
                if (string.IsNullOrEmpty(mainSocket.Data)) return;
                socket.Value.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket)));
            }
        }

        private void images_MouseDown(object sender, MouseEventArgs e)
        {
            var socket = SocketForm.sockets.FirstOrDefault(a => a.Key == ClientIp);
            if (socket.Value != null) {

                var mainSocket = new MainSocket()
                {
                    Statue = MainSocketEnum.PressLeft,
                    Data = GetCoordinate(images.Image.Width, images.Image.Height, images.Width, images.Height, e.X, e.Y)
                };
                if (string.IsNullOrEmpty(mainSocket.Data)) return;
                if (e.Button == MouseButtons.Left) {
                    mainSocket.Statue = MainSocketEnum.PressLeft;
                }
                else if (e.Button == MouseButtons.Right) {
                    mainSocket.Statue = MainSocketEnum.PressRight;
                }
                else return;
                socket.Value.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket)));
            }
        }

        private void images_MouseUp(object sender, MouseEventArgs e)
        {
            var socket = SocketForm.sockets.FirstOrDefault(a => a.Key == ClientIp);
            if (socket.Value != null) {
                var mainSocket = new MainSocket()
                {
                    Data = GetCoordinate(images.Image.Width, images.Image.Height, images.Width, images.Height, e.X, e.Y)
                };
                if (string.IsNullOrEmpty(mainSocket.Data)) return;
                if (e.Button == MouseButtons.Left) {
                    mainSocket.Statue = MainSocketEnum.LeftUp;
                }
                else if (e.Button == MouseButtons.Right) {
                    mainSocket.Statue = MainSocketEnum.RightUp;

                }
                else return;
                socket.Value.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket)));
            }
        }
    }
}
