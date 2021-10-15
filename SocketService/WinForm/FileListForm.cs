using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SocketService.WinForm
{
    public partial class FileListForm : Form
    {
        public Socket socket { set; get; }
        public List<ListedFilesEntity> listedFiles { set; get; } = new List<ListedFilesEntity>();
        public FileListForm()
        {
            InitializeComponent();
        }

        public void PathSocket(string data)
        {
            try
            {
                ListPath.Items.Clear();
                listedFiles = JsonConvert.DeserializeObject<List<ListedFilesEntity>>(data);
                foreach (var d in listedFiles)
                {
                    string name=d.Name+ (d.IsFile ? "            文件" : "            文件夹");
                    ListPath.Items.Add(name);
                }
            }
            catch (JsonSerializationException e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        private void FileListForm_Load(object sender, EventArgs e)
        {
            path.Width = FileContainer.Panel1.Width;
            path.Height = FileContainer.Panel1.Height;
            DownloadFile.Enabled = false;

        }

        private void ListPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ListPath.SelectedIndex == -1) return;
                var isData = listedFiles[ListPath.SelectedIndex];
                DownloadFile.Enabled = isData.IsFile;
                if (isData.IsFile)
                {
                    return;
                }
                var mainSocket = new MainSocket()
                {
                    Name = string.IsNullOrEmpty(isData.OlutePath)?isData.Name: isData.OlutePath,
                    Statue = MainSocketEnum.ListedFiles
                };
                path.Text= mainSocket.Name;
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket));
                socket.Send(bytes);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void retreat_Click(object sender, EventArgs e)
        {
            DownloadFile.Enabled = false;
            var names = path.Text.Split('\\');
            names = names.Where(a => !string.IsNullOrEmpty(a)).ToArray();
            if (names.Length == 0|| names.Length==1)
            {
                path.Text = "";
                var mainSocket = new MainSocket()
                {
                    Name = path.Text,
                    Statue = MainSocketEnum.ListedFiles
                };
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket));
                socket.Send(bytes);
                return;
            }
            names = names.Take(names.Length - 1).ToArray();
            if(names.Length == 1)
            {
                path.Text = names[0]+"\\";
                var mainSocket = new MainSocket()
                {
                    Name = path.Text,
                    Statue = MainSocketEnum.ListedFiles
                };
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket));
                socket.Send(bytes);
                return;
            }
            else
            {
                path.Text = string.Join("\\", names);
                var mainSocket = new MainSocket()
                {
                    Name = path.Text,
                    Statue = MainSocketEnum.ListedFiles
                };
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket));
                socket.Send(bytes);
            }
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            if (ListPath.SelectedIndex == -1) return;
            var isData = listedFiles[ListPath.SelectedIndex];
            if (!isData.IsFile) return;

            var mainSocket = new MainSocket()
            {
                Data=isData.Name,
                Name = isData.OlutePath,
                Statue = MainSocketEnum.DemandFile
            };
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket));
            socket.Send(bytes);
        }

        private void FileListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SocketForm.GetForm.Visible = true;
        }
    }
}
