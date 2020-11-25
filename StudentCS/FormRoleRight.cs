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
    public partial class FormRoleRight : Form
    {
        private string _roleid;//角色编号

        public FormRoleRight()
        {
            InitializeComponent();
        }

        public FormRoleRight(string roleid)
        {
            _roleid = roleid;//获取数据源
            InitializeComponent();
        }

        private void FormRoleRight_Load(object sender, EventArgs e)
        {
            //清空所有节点
            this.treeView1.Nodes.Clear();

            //获取系统所有权限和_roleid所拥有的权限
            DataTable tableRight = new StudentMS.BLL.Core().GetListRoleRight(_roleid).Tables[0];
            //遍历所有的数据行并展示在TreeView中
            foreach (DataRow row in tableRight.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["FunctionName"].ToString();
                node.Tag = row["FunctionID"].ToString();
                node.Checked = row["IfHave"].ToString() != "";
                this.treeView1.Nodes.Add(node);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "您确定要提交权限分配吗？", "提交确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                StudentMS.Model.S_R_F model = new StudentMS.Model.S_R_F();
                StudentMS.BLL.S_R_F bll = new StudentMS.BLL.S_R_F();
                //遍历所有的节点
                foreach (TreeNode node in this.treeView1.Nodes)
                {
                    if (node.Checked)
                    {
                        if (bll.Exists(_roleid, node.Tag.ToString()))
                            continue;
                        else//插入新增的权限
                        {
                            try
                            {
                                model.RoleID = _roleid;
                                model.FunctionID = node.Tag.ToString();
                                bll.Add(model);
                            }
                            catch { }
                        }
                    }
                    else//未选中
                    {
                        if (bll.Exists(_roleid, node.Tag.ToString()))//删除被取消的权限
                        {
                            try
                            {
                                bll.Delete(_roleid, node.Tag.ToString());
                            }
                            catch { }
                        }
                    }
                }//end_foreach
                this.Close();
            }
        }
    }
}
