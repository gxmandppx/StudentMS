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
    public partial class FormStudentEdit : Form
    {
        private int _editflag;//标记  0-新增 1-修改 2-详细信息
        private String _sno;//学号

        public string SSNO//属性 学号
        {
            set { value = _sno; }
            get { return _sno;}
        }
        public FormStudentEdit()
        {
            InitializeComponent();
        }
        public FormStudentEdit(int editflag)
        {
            _editflag = editflag;//获取数据源
            InitializeComponent();
        }
        public FormStudentEdit(int editflag,String sno)
        {
            _editflag = editflag;
            _sno = sno;
            InitializeComponent();
        }

        private void FormStudentEdit_Load(object sender, EventArgs e)
        {
            

            //初始化下拉框的数据列表
            StudentMS.BLL.Department bll = new StudentMS.BLL.Department();
            this.SDept.DataSource = bll.GetAllList().Tables[0].DefaultView;//数据源
            this.SDept.ValueMember = "DeptNO";//值的字段名
            this.SDept.DisplayMember = "DeptName";//显示的字段名

            if (_editflag == 0)//新增
                this.Text = "新增学生档案信息";
            else if (_editflag == 1)//修改
            {
                this.Text = "修改学生档案信息";
                this.SNO.ReadOnly = true;//学号不能修改
                //依据学号获取该生相关信息并填写到相应条件
                StudentMS.Model.Student model = new StudentMS.BLL.Student().GetModel(_sno);
                if (model != null)
                {
                    this.SNO.Text = model.SNO;
                    this.SName.Text = model.SName;
                    this.SAge.Text = model.SAge.ToString();
                    if (model.SSex == "男")//性别
                        this.radioButtonBoy.Checked = true;
                    else
                        this.radioButtonGirl.Checked = true;
                    if (model.SBirthday != null)
                        this.SBirthday.Value = model.SBirthday.Value;
                    this.SDept.SelectedValue = model.DeptNO; //院系
                }
            }
            else
                this.Text = "详细学生档案信息";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //数据校验
            string strError = "";
            if (this.SNO.Text.Trim() == "")
                strError += "学号不能为空，请重新输入！\n";
            if (this.SName.Text.Trim() == "")
                strError += "姓名不能为空！\n";
            int age = 0;
            try
            {
                age = int.Parse(this.SAge.Text.Trim());
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
            StudentMS.Model.Student model = new StudentMS.Model.Student();
            model.SNO = this.SNO.Text.Trim();//学号
            model.SName = this.SName.Text.Trim();//姓名
            model.SSex = this.radioButtonBoy.Checked ? "男" : "女";//性别
            model.SBirthday = this.SBirthday.Value;//出生年月
            model.SAge = age;
            model.DeptNO = this.SDept.SelectedValue.ToString();//院系
            //实例化BLL层并调用相应的方法访问数据库
            StudentMS.BLL.Student bll = new StudentMS.BLL.Student();
            try
            {
                if (_editflag == 0)//新增
                    bll.Add(model);
                if (_editflag == 1)//修改
                    bll.Update(model);
                _sno = model.SNO;//更新属性值

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
    }
}
