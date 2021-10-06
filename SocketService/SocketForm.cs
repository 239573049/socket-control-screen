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
        public readonly static Dictionary<string,Socket> sockets= new Dictionary<string,Socket>();
        public static bool isClose = true;
        public static MainSocketManagement mainSocketManagement;
        public static bool isScreen = false;
        public static ScreenShow screenShow;
        public static Form GetForm;
        public static Button getScreenBut;
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
            
        }
        public void initialize()
        {
            GetForm = this;
            getScreenBut = getScreen;
            MainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var port = new IPEndPoint(IPAddress.Any, MainPort);
            height.Text = "1080";
            width.Text = "720";
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

        private void getScreen_Click(object sender, EventArgs e)
        {
            if (isScreen) {
                screenShow.Close();
            }
            else {
                if (string.IsNullOrEmpty(height.Text) || string.IsNullOrEmpty(width.Text)) {
                    MessageBox.Show("请先设置屏幕大小在启动");
                    return;
                }
                var data = (string)SocketList.Items[SocketList.SelectedIndex];
                var socket = sockets.Where(a => a.Key == data)
                     .FirstOrDefault();

                var mainSocket = new MainSocket();
                mainSocket.Name = "准备接收屏幕流";
                mainSocket.Data = $"{11234}";
                mainSocket.Statue = MainSocketEnum.Screen;
                var json = JsonConvert.SerializeObject(mainSocket);
                socket.Value.Send(Encoding.UTF8.GetBytes(json));
                screenShow = new ScreenShow();
                screenShow.Widths = Convert.ToInt32(width.Text);
                screenShow.Heights = Convert.ToInt32(height.Text);
                screenShow.ip = data.Split(':')[0];
                screenShow.ClientIp = socket.Key;
                screenShow.Post = Convert.ToInt32(mainSocket.Data );
                screenShow.Show();
                GetForm.Visible = false;
            }
            getScreen.Text = isScreen ? "获取屏幕":"关闭获取屏幕";
            isScreen = !isScreen;
        }
        public static void Visibles()
        {
            GetForm.Visible = !GetForm.Visible;
        }
        private void height_TextChanged(object sender, EventArgs e)
        {
            VerificationUtil.NumeralsLimit(sender);
        }

        private void width_TextChanged(object sender, EventArgs e)
        {
            VerificationUtil.NumeralsLimit(sender);
        }

        private void SocketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
    }
}
