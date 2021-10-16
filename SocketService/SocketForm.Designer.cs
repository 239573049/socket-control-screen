namespace SocketService
{
    partial class SocketForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.log = new System.Windows.Forms.RichTextBox();
            this.SendFile = new System.Windows.Forms.Button();
            this.SocketList = new System.Windows.Forms.ComboBox();
            this.fileDialong = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.orClient = new System.Windows.Forms.Button();
            this.GetListedFiles = new System.Windows.Forms.Button();
            this.getScreen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.log);
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输出日志";
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Location = new System.Drawing.Point(3, 17);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(761, 190);
            this.log.TabIndex = 0;
            this.log.Text = "";
            // 
            // SendFile
            // 
            this.SendFile.Location = new System.Drawing.Point(311, 4);
            this.SendFile.Name = "SendFile";
            this.SendFile.Size = new System.Drawing.Size(78, 23);
            this.SendFile.TabIndex = 2;
            this.SendFile.Text = "发送文件";
            this.SendFile.UseVisualStyleBackColor = true;
            this.SendFile.Click += new System.EventHandler(this.SendFile_Click);
            // 
            // SocketList
            // 
            this.SocketList.FormattingEnabled = true;
            this.SocketList.Location = new System.Drawing.Point(94, 6);
            this.SocketList.Name = "SocketList";
            this.SocketList.Size = new System.Drawing.Size(121, 20);
            this.SocketList.TabIndex = 4;
            // 
            // fileDialong
            // 
            this.fileDialong.FileName = "fileDialong";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "客户端列表：";
            // 
            // orClient
            // 
            this.orClient.Location = new System.Drawing.Point(395, 4);
            this.orClient.Name = "orClient";
            this.orClient.Size = new System.Drawing.Size(75, 23);
            this.orClient.TabIndex = 11;
            this.orClient.Text = "切换客户端";
            this.orClient.UseVisualStyleBackColor = true;
            this.orClient.Click += new System.EventHandler(this.orClient_Click);
            // 
            // GetListedFiles
            // 
            this.GetListedFiles.Location = new System.Drawing.Point(476, 4);
            this.GetListedFiles.Name = "GetListedFiles";
            this.GetListedFiles.Size = new System.Drawing.Size(142, 23);
            this.GetListedFiles.TabIndex = 12;
            this.GetListedFiles.Text = "获取客户端文件列表";
            this.GetListedFiles.UseVisualStyleBackColor = true;
            this.GetListedFiles.Click += new System.EventHandler(this.GetListedFiles_Click);
            // 
            // getScreen
            // 
            this.getScreen.Location = new System.Drawing.Point(221, 4);
            this.getScreen.Name = "getScreen";
            this.getScreen.Size = new System.Drawing.Size(84, 23);
            this.getScreen.TabIndex = 13;
            this.getScreen.Text = "获取屏幕";
            this.getScreen.UseVisualStyleBackColor = true;
            this.getScreen.Click += new System.EventHandler(this.GetScreen_Click);
            // 
            // SocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 264);
            this.Controls.Add(this.getScreen);
            this.Controls.Add(this.GetListedFiles);
            this.Controls.Add(this.orClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SocketList);
            this.Controls.Add(this.SendFile);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(806, 303);
            this.Name = "SocketForm";
            this.ShowIcon = false;
            this.Text = "Socket服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SocketForm_FormClosing);
            this.Load += new System.EventHandler(this.SocketForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.Button SendFile;
        private System.Windows.Forms.ComboBox SocketList;
        private System.Windows.Forms.OpenFileDialog fileDialong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button orClient;
        private System.Windows.Forms.Button GetListedFiles;
        private System.Windows.Forms.Button getScreen;
    }
}

