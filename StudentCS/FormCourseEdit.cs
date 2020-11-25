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
    public partial class FormCourseEdit : Form
    {
        int _editflag;//标记  0-新增 1-修改

        private String _cno;//课程号

        public string _CNO//属性 课程号
        {
            set { value = _cno; }
            get { return _cno; }
        }

        public FormCourseEdit()
        {
            InitializeComponent();
        }

        public FormCourseEdit(int editflag)
        {
            _editflag = editflag;
            InitializeComponent();
        }

        public FormCourseEdit(int editflag,string cno)
        {
            _editflag = editflag;
            _cno = cno;
            InitializeComponent();
        }

        private void FormCourseEdit_Load(object sender, EventArgs e)
        {
            if (_editflag == 0)
            {
                this.Text = "新增课程档案信息";
            }
            else if (_editflag == 1)
            {
                this.Text = "修改课程档案信息";
                this.CNO.ReadOnly = true;//课程号不能修改
                //依据号获取相关信息并填写到相应条件
                StudentMS.Model.Course model = new StudentMS.BLL.Course().GetModel(_cno);
                if (model != null)
                {
                    this.CNO.Text = model.CNO;
                    this.CName.Text = model.CName;
                    this.Credit.Text = model.Credit.ToString();
                    this.CFirst.Text = model.CFirst; //
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //数据校验
            string strError = "";
            if (this.CNO.Text.Trim() == "")
                strError += "课程号不能为空！\n";
            if (this.CName.Text.Trim() == "")
                strError += "课程名不能为空！\n";
            if (strError != "")
            {
                MessageBox.Show(this, strError, "校验提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal credit = 0;

            credit = decimal.Parse(this.Credit.Text.Trim());

            //实例化Model，并给Model赋值
            StudentMS.Model.Course model = new StudentMS.Model.Course();
            model.CNO = this.CNO.Text.Trim();//课程号
            model.CName = this.CName.Text.Trim();//课程名
            model.Credit = credit;//学分
            model.CFirst= this.CFirst.Text.Trim();//先修课程号

            //实例化BLL层并调用相应的方法访问数据库
            StudentMS.BLL.Course bll = new StudentMS.BLL.Course();
            try
            {
                if (_editflag == 0)//新增
                    bll.Add(model);
                if (_editflag == 1)//修改
                    bll.Update(model);
                _cno = model.CNO;//更新属性值

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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}
