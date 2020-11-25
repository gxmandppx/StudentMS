using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentCS
{
    public partial class FormTree : Form
    {
        private DataTable tb_tree = new DataTable();//保存所有节点的数据集
        public FormTree()
        {
            InitializeComponent();
        }

        private void FormTree_Load(object sender, EventArgs e)
        {
            this.treeView1.Nodes.Clear();//清空所有节点
            //创建根节点
            TreeNode root = new TreeNode();
            root.Text = "武汉纺织大学";
            root.Tag = "0";
            this.treeView1.Nodes.Add(root);
            //获取所有节点的数据集并保存到tb_tree中
            tb_tree = new StudentMS.BLL.Tree().GetAllList().Tables[0];

            this.buildTreeChild(root);
            this.treeView1.ExpandAll();//展开所有节点
        }
        //创建parentnode 的所有子节点
        private void buildTreeChild(TreeNode parentnode)
        {
            //从tb_tree过滤得到以parentnode为父节点的所有记录并保存到数组datarows中
            DataRow[] datarows = tb_tree.Select("TNOParent='" + parentnode.Tag.ToString() + "'");
            foreach (DataRow row in datarows)//遍历数组datarows
            {
                TreeNode node = new TreeNode();
                node.Text = row["TName"].ToString();
                node.Tag = row["TNO"].ToString();
                parentnode.Nodes.Add(node);

                this.buildTreeChild(node);//递归
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            //获取鼠标所在节点
            TreeNode node = this.treeView1.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                this.treeView1.SelectedNode = node;
            }
        }

        private void ADDBrother_Click(object sender, EventArgs e)
        {
            //获取被选中的节点的父节点的编号
            string tno = this.treeView1.SelectedNode.Parent.Tag.ToString();
            FormTreeEdit temp = new FormTreeEdit(0, tno);//实例化
            temp.ShowDialog();//以对话框形式展示
            if (temp.DialogResult == DialogResult.OK)//调用查询功能实现数据刷新
            {
                TreeNode node = new TreeNode();
                node.Text = temp.TName;
                node.Tag = temp.TNO;
                this.treeView1.SelectedNode.Parent.Nodes.Add(node);
            }
        }

        private void ADDChild_Click(object sender, EventArgs e)
        {
            //获取被选中的节点编号
            string tno = this.treeView1.SelectedNode.Tag.ToString();

            FormTreeEdit temp = new FormTreeEdit(1,tno);//实例化
            temp.ShowDialog();//以对话框形式展示
            if (temp.DialogResult == DialogResult.OK)//调用查询功能实现数据刷新
            {
                TreeNode node = new TreeNode();
                node.Text = temp.TName;
                node.Tag = temp.TNO;
                this.treeView1.SelectedNode.Nodes.Add(node);
            }
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            if (this.treeView1.SelectedNode.Nodes.Count > 0)
            {
                MessageBox.Show(this, "您所要删除的节点有子节点，请先删除子节点！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(this, "您确定要删除您选中的节点吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string tno = this.treeView1.SelectedNode.Tag.ToString();//节点编号
                StudentMS.BLL.Tree bll = new StudentMS.BLL.Tree();
                try
                {
                    bll.Delete(tno);
                    this.treeView1.SelectedNode.Remove();//删除节点，刷新显示
                }
                catch(Exception ex)
                {
                    MessageBox.Show(this, "删除节点失败！\n" + ex.Message, "出错了！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void MODIFY_Click(object sender, EventArgs e)
        {
            //获取被选中的节点编号
            string tno = this.treeView1.SelectedNode.Tag.ToString();
            //实例化并传入参数
            FormTreeEdit temp = new FormTreeEdit(2, tno);
            //对话框形式展示窗体
            temp.ShowDialog();
            //刷新显示
            if (temp.DialogResult == DialogResult.OK)
            {
                this.treeView1.SelectedNode.Tag = temp.TNO;//编号
                this.treeView1.SelectedNode.Text = temp.TName;//名称
            }
        }
    }
}
