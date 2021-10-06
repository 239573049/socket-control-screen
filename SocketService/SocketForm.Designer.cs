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
            this.getScreen = new System.Windows.Forms.Button();
            this.SocketList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.height = new System.Windows.Forms.TextBox();
            this.width = new System.Windows.Forms.TextBox();
            this.fileDialong = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.orClient = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.log);
            this.groupBox1.Location = new System.Drawing.Point(470, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输出日志";
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Location = new System.Drawing.Point(3, 17);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(304, 190);
            this.log.TabIndex = 0;
            this.log.Text = "";
            // 
            // SendFile
            // 
            this.SendFile.Location = new System.Drawing.Point(470, 12);
            this.SendFile.Name = "SendFile";
            this.SendFile.Size = new System.Drawing.Size(78, 23);
            this.SendFile.TabIndex = 2;
            this.SendFile.Text = "发送文件";
            this.SendFile.UseVisualStyleBackColor = true;
            this.SendFile.Click += new System.EventHandler(this.SendFile_Click);
            // 
            // getScreen
            // 
            this.getScreen.Location = new System.Drawing.Point(0, 41);
            this.getScreen.Name = "getScreen";
            this.getScreen.Size = new System.Drawing.Size(237, 23);
            this.getScreen.TabIndex = 3;
            this.getScreen.Text = "获取屏幕";
            this.getScreen.UseVisualStyleBackColor = true;
            this.getScreen.Click += new System.EventHandler(this.getScreen_Click);
            // 
            // SocketList
            // 
            this.SocketList.FormattingEnabled = true;
            this.SocketList.Location = new System.Drawing.Point(94, 6);
            this.SocketList.Name = "SocketList";
            this.SocketList.Size = new System.Drawing.Size(121, 20);
            this.SocketList.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "高度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "宽度：";
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(53, 14);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(52, 21);
            this.height.TabIndex = 7;
            this.height.TextChanged += new System.EventHandler(this.height_TextChanged);
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(158, 14);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(61, 21);
            this.width.TabIndex = 8;
            this.width.TextChanged += new System.EventHandler(this.width_TextChanged);
            // 
            // fileDialong
            // 
            this.fileDialong.FileName = "fileDialong";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.width);
            this.groupBox2.Controls.Add(this.getScreen);
            this.groupBox2.Controls.Add(this.height);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(221, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 75);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "客户端屏幕";
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
            this.orClient.Location = new System.Drawing.Point(554, 12);
            this.orClient.Name = "orClient";
            this.orClient.Size = new System.Drawing.Size(75, 23);
            this.orClient.TabIndex = 11;
            this.orClient.Text = "切换客户端";
            this.orClient.UseVisualStyleBackColor = true;
            this.orClient.Click += new System.EventHandler(this.orClient_Click);
            // 
            // SocketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 264);
            this.Controls.Add(this.orClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox log;
        private System.Windows.Forms.Button SendFile;
        private System.Windows.Forms.Button getScreen;
        private System.Windows.Forms.ComboBox SocketList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.OpenFileDialog fileDialong;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button orClient;
    }
}

