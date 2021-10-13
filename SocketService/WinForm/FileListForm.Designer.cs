namespace SocketService.WinForm
{
    partial class FileListForm
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            this.FileContainer = new System.Windows.Forms.SplitContainer();
            this.path = new System.Windows.Forms.TextBox();
            this.verificationUtilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainSocketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainSocketBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.listedFilesEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListPath = new System.Windows.Forms.ListBox();
            this.listedFilesEntityBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FileContainer)).BeginInit();
            this.FileContainer.Panel1.SuspendLayout();
            this.FileContainer.Panel2.SuspendLayout();
            this.FileContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verificationUtilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSocketBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSocketBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listedFilesEntityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listedFilesEntityBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // FileContainer
            // 
            this.FileContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileContainer.Location = new System.Drawing.Point(0, 0);
            this.FileContainer.Name = "FileContainer";
            this.FileContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // FileContainer.Panel1
            // 
            this.FileContainer.Panel1.Controls.Add(this.path);
            // 
            // FileContainer.Panel2
            // 
            this.FileContainer.Panel2.Controls.Add(this.ListPath);
            this.FileContainer.Size = new System.Drawing.Size(698, 414);
            this.FileContainer.SplitterDistance = 25;
            this.FileContainer.TabIndex = 0;
            // 
            // path
            // 
            this.path.Location = new System.Drawing.Point(3, 3);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(692, 21);
            this.path.TabIndex = 0;
            // 
            // verificationUtilBindingSource
            // 
            this.verificationUtilBindingSource.DataSource = typeof(Entity.VerificationUtil);
            // 
            // mainSocketBindingSource
            // 
            this.mainSocketBindingSource.DataSource = typeof(Entity.MainSocket);
            // 
            // mainSocketBindingSource1
            // 
            this.mainSocketBindingSource1.DataSource = typeof(Entity.MainSocket);
            // 
            // listedFilesEntityBindingSource
            // 
            this.listedFilesEntityBindingSource.DataSource = typeof(Entity.ListedFilesEntity);
            // 
            // ListPath
            // 
            this.ListPath.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.listedFilesEntityBindingSource1, "Name", true));
            this.ListPath.FormattingEnabled = true;
            this.ListPath.ItemHeight = 12;
            this.ListPath.Items.AddRange(new object[] {
            "123",
            "123",
            "123"});
            this.ListPath.Location = new System.Drawing.Point(3, 3);
            this.ListPath.Name = "ListPath";
            this.ListPath.Size = new System.Drawing.Size(682, 376);
            this.ListPath.TabIndex = 0;
            this.ListPath.SelectedIndexChanged += new System.EventHandler(this.ListPath_SelectedIndexChanged);
            // 
            // listedFilesEntityBindingSource1
            // 
            this.listedFilesEntityBindingSource1.DataSource = typeof(Entity.ListedFilesEntity);
            // 
            // FileListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 414);
            this.Controls.Add(this.FileContainer);
            this.Name = "FileListForm";
            this.ShowIcon = false;
            this.Text = "FileList";
            this.Load += new System.EventHandler(this.FileListForm_Load);
            this.FileContainer.Panel1.ResumeLayout(false);
            this.FileContainer.Panel1.PerformLayout();
            this.FileContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileContainer)).EndInit();
            this.FileContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.verificationUtilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSocketBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSocketBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listedFilesEntityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listedFilesEntityBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer FileContainer;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.BindingSource verificationUtilBindingSource;
        private System.Windows.Forms.BindingSource mainSocketBindingSource;
        private System.Windows.Forms.BindingSource mainSocketBindingSource1;
        private System.Windows.Forms.BindingSource listedFilesEntityBindingSource;
        private System.Windows.Forms.ListBox ListPath;
        private System.Windows.Forms.BindingSource listedFilesEntityBindingSource1;
    }
}