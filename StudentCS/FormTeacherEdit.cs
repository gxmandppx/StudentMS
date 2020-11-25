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
    public partial class FormTeacherEdit : Form
    {
        int _editflag;//标记  0-新增 1-修改 2-详细信息
        private String _tno;//工号

        public string _TNO//属性 工号
        {
            set { value = _tno; }
            get { return _tno; }
        }

        public FormTeacherEdit()
        {
            InitializeComponent();
        }

        public FormTeacherEdit(int editflag)
        {
            _editflag = editflag;
            InitializeComponent();
        }

        public FormTeacherEdit(int editflag, String tno)
        {
            _editflag = editflag;
            _tno = tno;
            InitializeComponent();
        }

        private void FormTeacherEdit_Load(object sender, EventArgs e)
        {
            if (_editflag == 0)
            {
                this.Text = "新增教师档案信息";
            }
            else if (_editflag == 1)
            {
                this.Text = "修改教师档案信息";
                this.TNO.ReadOnly = true;//教工号不能修改
                //依据教工号获取相关信息并填写到相应条件
                StudentMS.Model.Teacher model = new StudentMS.BLL.Teacher().GetModel(_tno);
                if (model != null)
                {
                    this.TNO.Text = model.TNO;
                    this.TName.Text = model.TName;
                    this.TAge.Text = model.TAge.ToString();
                    if (model.TSex == "男")//性别
                        this.radioButtonman.Checked = true;
                    else
                        this.radioButtonwoman.Checked = true;
                    this.TAddress.Text = model.TAddress; //院系
                }
            }
            else
                this.Text = "详细教师档案信息";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //数据校验
            string strError = "";
            if (this.TNO.Text.Trim() == "")
                strError += "教工号不能为空，请重新输入！\n";
            if (this.TName.Text.Trim() == "")
                strError += "姓名不能为空！\n";
            int age = 0;
            try
            {
                age = int.Parse(this.TAge.Text.Trim());
                if (age <= 0)
                {
                    strError += "年龄只能是正整数！\n";
                }
                if (age >= 200)
                {
                    strError += "建国以后不许成精！\n";
                }
            }
            catch
            {
                strError += "请输入正常人的年龄！\n";
            }
            if (strError != "")
            {
                MessageBox.Show(this, strError, "校验提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //实例化Model，并给Model赋值
            StudentMS.Model.Teacher model = new StudentMS.Model.Teacher();
            model.TNO = this.TNO.Text.Trim();//教工号
            model.TName = this.TName.Text.Trim();//姓名
            model.TSex = this.radioButtonman.Checked ? "男" : "女";//性别
            model.TAge = age;
            model.TAddress = this.TAddress.Text.Trim();//教师住址
            //实例化BLL层并调用相应的方法访问数据库
            StudentMS.BLL.Teacher bll = new StudentMS.BLL.Teacher();
            try
            {
                if (_editflag == 0)//新增
                {
                    bll.Add(model);
                }
                if (_editflag == 1)//修改
                {
                    bll.Update(model);
                }
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
    }
}
