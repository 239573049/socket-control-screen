using Entity;
using Newtonsoft.Json;
using SocketService.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace SocketService
{
    public partial class SocketForm : Form
    {
        /// <summary>
        /// 主Scoket通道
        /// </summary>
        private Socket MainSocket;
        private int MainPort = 10426;
        private int ScreenPort = 11030;
        /// <summary>
        /// 客户端
        /// </summary>
        public readonly static Dictionary<string,Socket> sockets= new Dictionary<string,Socket>();
        public readonly static Dictionary<string,Socket> ScreenSockets = new Dictionary<string,Socket>();
        public static bool isClose = true;
        public static MainSocketManagement mainSocketManagement;
        public static bool isScreen = false;
        public static ScreenShow screenShow;
        public static Form GetForm;
        public static Button getScreenBut;
        public static List<string> OpenScreen = new List<string>();
        /// <summary>
        /// 屏幕接收Socket
        /// </summary>
        public static Socket ScreenSocket;
        public SocketForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void SocketForm_Load(object sender, EventArgs e)
        {
            try {
                initialize();
            }
            catch (SocketException s) {
                if(s.Message== "通常每个套接字地址(协议/网络地址/端口)只允许使用一次。") {
                    MainPort += 1;
                    initialize();
                }
            }
            try
            {
                initializeSreen();
            }
            catch (SocketException s)
            {
                if (s.Message == "通常每个套接字地址(协议/网络地址/端口)只允许使用一次。")
                {
                    ScreenPort += 1;
                    initializeSreen();
                }
            }
        }
        /// <summary>
        /// 屏幕接收Socket
        /// </summary>
        public void initializeSreen()
        {
            var port = new IPEndPoint(IPAddress.Any, ScreenPort);
            ScreenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScreenSocket.Bind(port);
            ScreenSocket.Listen(int.MaxValue);
            //new Thread(SrennReceive) { IsBackground = true}.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        public void SrennReceive()
        {
            while (isClose)
            {
                var socket=ScreenSocket.Accept();
                ScreenSockets.Add(socket.RemoteEndPoint.ToString(),socket);
            }
        }
        public void initialize()
        {
            GetForm = this;
            getScreenBut = getScreen;
            MainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var port = new IPEndPoint(IPAddress.Any, MainPort);
            MainSocket.Bind(port);
            MainSocket.Listen(int.MaxValue);
            log.AppendText($"Socket服务启动成功,ip列表{string.Join(",", NetworkUtil.GetLocalIPs())}服务端口：{MainPort}\r\n");
            mainSocketManagement = new MainSocketManagement();
            mainSocketManagement.ConnectSocket(sockets, MainSocket, log, SocketList);
            new Thread(delegate () {
                while (isClose) {
                    if (SocketList.Items.Count == 0 && SendFile.Enabled == true) {
                        SendFile.Enabled = false;
                    }
                    else if (SocketList.Items.Count != 0 && SendFile.Enabled == false) {
                        SendFile.Enabled = true;
                        SocketList.SelectedIndex = 0;
                    }
                    if (SocketList.Items.Count == 0 && getScreen.Enabled == true) {
                        getScreen.Enabled = false;
                    }
                    else if (SocketList.Items.Count != 0 && getScreen.Enabled == false) {
                        getScreen.Enabled = true;
                    }
                    Thread.Sleep(100);
                }

            }).Start();
        }
        private void SendFile_Click(object sender, EventArgs e)
        {
            var file = fileDialong.ShowDialog();
            if (file == DialogResult.OK) {
                var data = (string)SocketList.Items[SocketList.SelectedIndex];
                var socket = sockets.Where(a => a.Key == data)
                     .FirstOrDefault();
                if (!socket.Equals(null)) {
                    mainSocketManagement.SendFileSocket(socket.Value, fileDialong.FileName);
                }

            }
        }

        private void GetScreen_Click(object sender, EventArgs e)
        {
            var data = (string)SocketList.Items[SocketList.SelectedIndex];
            var socket = sockets.Where(a => a.Key == data)
                 .FirstOrDefault();
            if (OpenScreen.Any(a => a == socket.Key))
            {
                MessageBox.Show("已经打开屏幕共享");
                return;
            }
            var mainSocket = new MainSocket();
            mainSocket.Name = "准备接收屏幕流";
            mainSocket.Data = $"{ScreenPort}";
            mainSocket.Statue = MainSocketEnum.Screen;
            var json = JsonConvert.SerializeObject(mainSocket);
            socket.Value.Send(Encoding.UTF8.GetBytes(json));
            var socketSrenn = ScreenSocket.Accept();
            ScreenSockets.Add(socketSrenn.RemoteEndPoint.ToString(), socketSrenn);
            OpenScreen.Add(socket.Key);
            screenShow = new ScreenShow
            {
                Widths = 1080,
                Heights = 1920,
                ip = data.Split(':')[0],
                ClientIp = socket.Key,
                Post = Convert.ToInt32(mainSocket.Data),
                ScreenSocket = socketSrenn
            };
            screenShow.Show();
        }
        public static void Visibles()
        {
            GetForm.Visible = !GetForm.Visible;
        }

        private void SocketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var data = new MainSocket
            {
                Statue = MainSocketEnum.Break
            };
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
            try
            {
                foreach (var s in sockets)
                {
                    s.Value.Send(bytes);
                }
            }
            catch (Exception)
            {
            }
            mainSocketManagement.Close();
            isClose = false;
            MainSocket.Close();
            MainSocket.Dispose();
        }

        private void orClient_Click(object sender, EventArgs e)
        {
            SocketClient socketClient= new SocketClient();
            socketClient.Show();
            GetForm.Visible = false;
        }

        private void GetListedFiles_Click(object sender, EventArgs e)
        {
            if(SocketList.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择客户端");
                return;
            }

            var data = new MainSocket()
            {
                Data = "",
                Statue = MainSocketEnum.ListedFiles,
            };
            var json = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
            var socket = sockets.Where(a => a.Key == (string)SocketList.Items[SocketList.SelectedIndex])
                 .FirstOrDefault();
            if (!socket.Equals(null))
            {
                mainSocketManagement.FileListForm(socket.Value);
            }
        }
    }
}
