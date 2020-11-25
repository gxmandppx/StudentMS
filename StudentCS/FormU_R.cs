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
    public partial class FormU_R : Form
    {
        private string _userid;//用户名

        public FormU_R()
        {
            InitializeComponent();
        }

        public FormU_R(string userid)
        {
            _userid = userid;//获取参考值
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormU_R_Load(object sender, EventArgs e)
        {
            string strRole = ",";//用户_userid所拥有的角色

            //获取用户_userid的所有RoleID
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();
            DataTable tbRole = new StudentMS.BLL.Core().GetListU_R(_userid).Tables[0];
            foreach (DataRow row in tbRole.Rows)
            {
                strRole += row["RoleID"].ToString() + ",";
            }
            this.treeView1.Nodes.Clear();//清空所有节点
            //获取当前系统的所有角色
            DataTable tbRoleAll = new StudentMS.BLL.S_Role().GetAllList().Tables[0];
            foreach (DataRow row in tbRoleAll.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["RoleName"].ToString();
                node.Tag = row["RoleID"].ToString();
                this.treeView1.Nodes.Add(node);
                //根据用户
                if (strRole.Contains("," + node.Tag.ToString() + ","))
                    node.Checked = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //清空_userid的所有角色
            try
            {
                new StudentMS.BLL.Core().DeleteRoleByUser(_userid);
            }
            catch{}
            //插入角色信息
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                if (node.Checked)
                {
                    StudentMS.Model.S_U_R model = new StudentMS.Model.S_U_R();
                    model.UserID = _userid;
                    model.RoleID = node.Tag.ToString();
                    StudentMS.BLL.S_U_R bll = new StudentMS.BLL.S_U_R();

                    try
                    {
                        bll.Add(model);
                    }
                    catch { }
                }
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}
