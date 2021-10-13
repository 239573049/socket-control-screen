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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketService.WinForm
{
    public partial class FileListForm : Form
    {
        public Socket socket { set; get; }
        private string PresentPath = "";
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

        }

        private void ListPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ListPath.SelectedIndex == -1) return;
                var isData = listedFiles[ListPath.SelectedIndex];
                if (isData.IsFile) return;
                var mainSocket = new MainSocket()
                {
                    Name = isData.Name,
                    Statue = MainSocketEnum.ListedFiles
                };
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mainSocket));
                socket.Send(bytes);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
