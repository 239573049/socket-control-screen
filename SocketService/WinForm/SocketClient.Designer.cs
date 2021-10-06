
namespace SocketService.WinForm
{
    partial class SocketClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.openSocket = new System.Windows.Forms.Button();
            this.sendFile = new System.Windows.Forms.Button();
            this.returnService = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.delayed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器地址：";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(95, 6);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(100, 21);
            this.ip.TabIndex = 2;
            this.ip.Text = "192.168.31.62";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口：";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(248, 6);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(62, 21);
            this.port.TabIndex = 4;
            this.port.Text = "10426";
            this.port.TextChanged += new System.EventHandler(this.port_TextChanged);
            // 
            // openSocket
            // 
            this.openSocket.Location = new System.Drawing.Point(316, 4);
            this.openSocket.Name = "openSocket";
            this.openSocket.Size = new System.Drawing.Size(75, 23);
            this.openSocket.TabIndex = 5;
            this.openSocket.Text = "连接服务器";
            this.openSocket.UseVisualStyleBackColor = true;
            this.openSocket.Click += new System.EventHandler(this.openSocket_Click);
            // 
            // sendFile
            // 
            this.sendFile.Location = new System.Drawing.Point(397, 4);
            this.sendFile.Name = "sendFile";
            this.sendFile.Size = new System.Drawing.Size(75, 23);
            this.sendFile.TabIndex = 6;
            this.sendFile.Text = "发送文件";
            this.sendFile.UseVisualStyleBackColor = true;
            // 
            // returnService
            // 
            this.returnService.Location = new System.Drawing.Point(478, 4);
            this.returnService.Name = "returnService";
            this.returnService.Size = new System.Drawing.Size(75, 23);
            this.returnService.TabIndex = 7;
            this.returnService.Text = "返回服务器";
            this.returnService.UseVisualStyleBackColor = true;
            this.returnService.Click += new System.EventHandler(this.returnService_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // delayed
            // 
            this.delayed.AutoSize = true;
            this.delayed.Location = new System.Drawing.Point(12, 33);
            this.delayed.Name = "delayed";
            this.delayed.Size = new System.Drawing.Size(0, 12);
            this.delayed.TabIndex = 8;
            // 
            // SocketClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 71);
            this.Controls.Add(this.delayed);
            this.Controls.Add(this.returnService);
            this.Controls.Add(this.sendFile);
            this.Controls.Add(this.openSocket);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.label1);
            this.Name = "SocketClient";
            this.ShowIcon = false;
            this.Text = "客户端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SocketClient_FormClosed);
            this.Load += new System.EventHandler(this.SocketClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Button openSocket;
        private System.Windows.Forms.Button sendFile;
        private System.Windows.Forms.Button returnService;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Label delayed;
    }
}