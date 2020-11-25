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
    public partial class FormUserEdit : Form
    {
        private int _editflag;//标记  0-新增 1-修改
        private String _userid;//用户名

        public string _UserID//属性 用户名
        {
            set { value = _userid; }
            get { return _userid; }
        }
        public FormUserEdit()
        {
            InitializeComponent();
        }
        public FormUserEdit(int editflag)
        {
            _editflag = editflag;//获取数据源
            InitializeComponent();
        }
        public FormUserEdit(int editflag, String UserID)
        {
            _editflag = editflag;
            _userid = UserID;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //数据校验
            string strError = "";
            if (this.User_ID.Text.Trim() == "")
                strError += "用户名不能为空，请重新输入！\n";
            if (this.UPassword.Text.Trim() == "")
                strError += "密码不能为空！\n";
            if (this.SNO.Text.Trim() == "" && this.TNO.Text.Trim() == "")
                strError += "学号和教工号不能同时为空，请重新输入！\n";

            if (strError != "")
            {
                MessageBox.Show(this, strError, "校验提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //实例化Model，并给Model赋值
            StudentMS.Model.S_User model = new StudentMS.Model.S_User();
            model.UserID = this.User_ID.Text.Trim();//用户名
            model.UPassWord = this.UPassword.Text.Trim();//密码
            if (this.SNO.Text.Trim() != "")
                model.SNO = this.SNO.Text.Trim();//学号
            if (this.TNO.Text.Trim() != "")
                model.TNO = this.TNO.Text.Trim();//教工号

            //实例化BLL层并调用相应的方法访问数据库
            StudentMS.BLL.S_User bll = new StudentMS.BLL.S_User();
            try
            {
                if (_editflag == 0)//新增
                    bll.Add(model);
                if (_editflag == 1)//修改
                    bll.Update(model);
                _userid = model.SNO;//更新属性值

                MessageBox.Show(this, "操作完成！\n", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;//设置弹出窗返回值
                this.Close();//推出弹出窗口
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "数据更新失败！\n" + ex.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void FormUserEdit_Load(object sender, EventArgs e)
        {
            if (_editflag == 0)//新增
                this.Text = "新增用户信息";
            else if (_editflag == 1)//修改
            {
                this.Text = "修改用户信息";
                this.User_ID.ReadOnly = true;//用户名不能修改
                //依据学号获取该人相关信息并填写到相应条件
                StudentMS.Model.S_User model = new StudentMS.BLL.S_User().GetModel(_userid);
                if (model != null)
                {
                    this.User_ID.Text = model.UserID;
                    this.SNO.Text = model.SNO;
                    this.TNO.Text = model.TNO;
                    this.UPassword.Text = model.UPassWord.ToString();
                }
            }
        }
    }
}
