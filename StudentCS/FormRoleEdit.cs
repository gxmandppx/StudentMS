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
    public partial class FormRoleEdit : Form
    {
        private int _editflag;//标记  0-新增 1-修改
        private String _roleid;//权限编号

        public string roleid//属性 权限
        {
            set { value = _roleid; }
            get { return _roleid; }
        }

        public FormRoleEdit()
        {
            InitializeComponent();
        }

        public FormRoleEdit(int editflag)
        {
            _editflag = editflag;//获取数据源
            InitializeComponent();
        }

        public FormRoleEdit(int editflag, String RoleID)
        {
            _editflag = editflag;//获取数据源
            _roleid = RoleID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //数据校验
            //实例化Model，并给Model赋值
            StudentMS.Model.S_Role model = new StudentMS.Model.S_Role();
            model.RoleID = this.ButtonRoleID.Text.Trim();//权限编号
            model.RoleName = this.ButtonRoleName.Text.Trim();//权限名
  
            //实例化BLL层并调用相应的方法访问数据库
            StudentMS.BLL.S_Role bll = new StudentMS.BLL.S_Role();
            try
            {
                if (_editflag == 0)//新增
                    bll.Add(model);
                if (_editflag == 1)//修改
                    bll.Update(model);
                _roleid = model.RoleID;//更新属性值

                MessageBox.Show(this, "操作完成！\n", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;//设置弹出窗返回值
                this.Close();//推出弹出窗口
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,"数据更新失败！\n"+ex.Message,"出错了",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void FormRoleEdit_Load(object sender, EventArgs e)
        {
            if (_editflag == 0)//新增
                this.Text = "新增权限信息";
            else if (_editflag == 1)//修改
            {
                this.Text = "修改权限信息";
                this.ButtonRoleID.ReadOnly = true;//权限编号不能修改
                //依据权限编号获取相关信息并填写到相应条件
                StudentMS.Model.S_Role model = new StudentMS.BLL.S_Role().GetModel(_roleid);
                if (model != null)
                {
                    this.ButtonRoleID.Text = model.RoleID;
                    this.ButtonRoleName.Text = model.RoleName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}
