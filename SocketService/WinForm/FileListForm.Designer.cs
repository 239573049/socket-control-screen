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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点9", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点8", new System.Windows.Forms.TreeNode[] {
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点7", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点6", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点5", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode10});
            this.FileContainer = new System.Windows.Forms.SplitContainer();
            this.path = new System.Windows.Forms.TextBox();
            this.verificationUtilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainSocketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainSocketBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.FileContainer)).BeginInit();
            this.FileContainer.Panel1.SuspendLayout();
            this.FileContainer.Panel2.SuspendLayout();
            this.FileContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.verificationUtilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSocketBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSocketBindingSource1)).BeginInit();
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
            this.FileContainer.Panel2.Controls.Add(this.treeView1);
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
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "节点0";
            treeNode2.Name = "节点1";
            treeNode2.Text = "节点1";
            treeNode3.Name = "节点3";
            treeNode3.Text = "节点3";
            treeNode4.Name = "节点4";
            treeNode4.Text = "节点4";
            treeNode5.Name = "节点10";
            treeNode5.Text = "节点10";
            treeNode6.Name = "节点9";
            treeNode6.Text = "节点9";
            treeNode7.Name = "节点8";
            treeNode7.Text = "节点8";
            treeNode8.Name = "节点7";
            treeNode8.Text = "节点7";
            treeNode9.Name = "节点6";
            treeNode9.Text = "节点6";
            treeNode10.Name = "节点5";
            treeNode10.Text = "节点5";
            treeNode11.Name = "节点2";
            treeNode11.Text = "节点2";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode11});
            this.treeView1.Size = new System.Drawing.Size(696, 383);
            this.treeView1.TabIndex = 0;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer FileContainer;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.BindingSource verificationUtilBindingSource;
        private System.Windows.Forms.BindingSource mainSocketBindingSource;
        private System.Windows.Forms.BindingSource mainSocketBindingSource1;
    }
}