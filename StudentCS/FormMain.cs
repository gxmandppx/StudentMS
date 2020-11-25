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
    public partial class FormMain : Form
    {
        private bool right = false;
 
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("S03"))
            {
                if (!flag("Student"))
                {
                    FormStudent temp = new FormStudent();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("T03"))
            {
                if (!flag("Teacher"))
                {
                    FormTeacher temp = new FormTeacher();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 树结构ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("Tree"))
            {
                if (!flag("Tree"))
                {
                    FormTree temp = new FormTree();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("SC1"))
            {
                if (!flag("SC"))
                {
                    FormSC temp = new FormSC();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("S_C"))
            {
                if (!flag("Score"))
                {
                    FormScore temp = new FormScore();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("TC1"))
            {
                if (!flag("TC"))
                {
                    FormTC temp = new FormTC();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("TJ"))
            {
                if (!flag("TJ"))
                {
                    FormTJ temp = new FormTJ();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("U01"))
            {
                if (!flag("User"))
                {
                    FormUser temp = new FormUser();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("C04"))
            {
                if (!flag("Course"))
                {
                    FormCourse temp = new FormCourse();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("Role"))
            {
                if (!flag("Role"))
                {
                    FormRole temp = new FormRole();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (StudentMS.BLL.Core.IsHaveRight("SS"))
            {
                if (!flag("SS"))
                {
                    FormSS temp = new FormSS();//实例化
                    temp.MdiParent = this;//设置父窗体
                    temp.Show();//调用show显示窗体.
                }
            }
            else
            {
                MessageBox.Show(this, "您没有权限执行此操作！", "权限认证失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        //重新登陆
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //关闭所有子窗体
            foreach(Form frmtemp in this.MdiChildren)
            {
                try
                {
                    frmtemp.Close();//关闭子窗体
                }
                catch { }
            }
            this.Visible = false;//把主窗体设为不可见

            FormLogin temp = new FormLogin();
            temp.ShowDialog();

            if (temp.DialogResult == DialogResult.OK)
                this.Visible = true;
            else
            {
                this.Close();//释放资源
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();//释放资源
        }

        private bool flag(String _flag)
        {
            bool flag = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == "Form" + _flag)
                {
                    frm.Show();
                    frm.Focus();
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        

        

        
    }
}
