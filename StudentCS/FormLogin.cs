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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void denglu_Click(object sender, EventArgs e)
        {
            if (this.User_ID.Text.Trim() == "")
            {
                MessageBox.Show(this, "用户名不可为空！\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //获取用户名和密码
            string userid = this.User_ID.Text.Trim();
            string password = this.User_Password.Text.Trim();

            //实例化BLL层并调用方法ExistsUser校验用户是否存在
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();
            bll.getConnectionString();//获取数据库连接字符
            if (bll.ExistsUser(userid, password))
            {
                bll.GetListUserRight(userid);//获取该用户的权限
                this.DialogResult = DialogResult.OK;//设置窗体返回值
            }
            else
            {
                MessageBox.Show(this, "用户名或密码不正确！\n", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void User_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.denglu_Click(this.denglu, e);
        }

        
    }
}
