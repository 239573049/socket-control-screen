using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Socket socket;

        public FileListForm()
        {
            InitializeComponent();
        }


        private void FileListForm_Load(object sender, EventArgs e)
        {
            path.Width = FileContainer.Panel1.Width;
            path.Height = FileContainer.Panel1.Height;
        }
    }
}
