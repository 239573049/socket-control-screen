namespace SocketService.WinForm
{
    partial class ScreenShow
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
            this.images = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.images)).BeginInit();
            this.SuspendLayout();
            // 
            // images
            // 
            this.images.Cursor = System.Windows.Forms.Cursors.Default;
            this.images.Dock = System.Windows.Forms.DockStyle.Fill;
            this.images.Location = new System.Drawing.Point(0, 0);
            this.images.Name = "images";
            this.images.Size = new System.Drawing.Size(1471, 647);
            this.images.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.images.TabIndex = 0;
            this.images.TabStop = false;
            this.images.MouseClick += new System.Windows.Forms.MouseEventHandler(this.images_MouseClick);
            this.images.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.images_MouseDoubleClick);
            this.images.MouseDown += new System.Windows.Forms.MouseEventHandler(this.images_MouseDown);
            this.images.MouseMove += new System.Windows.Forms.MouseEventHandler(this.images_MouseMove);
            this.images.MouseUp += new System.Windows.Forms.MouseEventHandler(this.images_MouseUp);
            // 
            // ScreenShow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 647);
            this.Controls.Add(this.images);
            this.Name = "ScreenShow";
            this.ShowIcon = false;
            this.Text = "ScreenShow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenShow_FormClosing);
            this.Load += new System.EventHandler(this.ScreenShow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ScreenShow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ScreenShow_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.images)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox images;
    }
}