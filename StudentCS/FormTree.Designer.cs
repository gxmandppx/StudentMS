namespace StudentCS
{
    partial class FormTree
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ADD = new System.Windows.Forms.ToolStripMenuItem();
            this.ADDBrother = new System.Windows.Forms.ToolStripMenuItem();
            this.ADDChild = new System.Windows.Forms.ToolStripMenuItem();
            this.DELETE = new System.Windows.Forms.ToolStripMenuItem();
            this.MODIFY = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ItemHeight = 25;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Text = "节点1";
            treeNode2.Name = "节点2";
            treeNode2.Text = "节点2";
            treeNode3.Name = "节点3";
            treeNode3.Text = "节点3";
            treeNode4.Name = "节点4";
            treeNode4.Text = "节点4";
            treeNode5.Name = "节点5";
            treeNode5.Text = "节点5";
            treeNode6.Name = "节点6";
            treeNode6.Text = "节点6";
            treeNode7.Name = "节点0";
            treeNode7.Text = "节点0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1.Size = new System.Drawing.Size(322, 425);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ADD,
            this.DELETE,
            this.MODIFY});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ADD
            // 
            this.ADD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ADDBrother,
            this.ADDChild});
            this.ADD.Name = "ADD";
            this.ADD.Size = new System.Drawing.Size(100, 22);
            this.ADD.Text = "新增";
            // 
            // ADDBrother
            // 
            this.ADDBrother.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.ADDBrother.Name = "ADDBrother";
            this.ADDBrother.Size = new System.Drawing.Size(152, 22);
            this.ADDBrother.Text = "兄弟节点";
            this.ADDBrother.Click += new System.EventHandler(this.ADDBrother_Click);
            // 
            // ADDChild
            // 
            this.ADDChild.Name = "ADDChild";
            this.ADDChild.Size = new System.Drawing.Size(152, 22);
            this.ADDChild.Text = "子节点";
            this.ADDChild.Click += new System.EventHandler(this.ADDChild_Click);
            // 
            // DELETE
            // 
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(100, 22);
            this.DELETE.Text = "删除";
            this.DELETE.Click += new System.EventHandler(this.DELETE_Click);
            // 
            // MODIFY
            // 
            this.MODIFY.Name = "MODIFY";
            this.MODIFY.Size = new System.Drawing.Size(100, 22);
            this.MODIFY.Text = "修改";
            this.MODIFY.Click += new System.EventHandler(this.MODIFY_Click);
            // 
            // FormTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 425);
            this.Controls.Add(this.treeView1);
            this.Name = "FormTree";
            this.Text = "树结构";
            this.Load += new System.EventHandler(this.FormTree_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ADD;
        private System.Windows.Forms.ToolStripMenuItem ADDBrother;
        private System.Windows.Forms.ToolStripMenuItem ADDChild;
        private System.Windows.Forms.ToolStripMenuItem DELETE;
        private System.Windows.Forms.ToolStripMenuItem MODIFY;
    }
}