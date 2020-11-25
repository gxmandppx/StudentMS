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
    public partial class FormTreeEdit : Form
    {
        private int _editflag;//编辑标记 0-新增兄弟节点  1-新增子节点 2-修改节点
        private string _tno;//节点编号
        private string _tname;//节点名称
        private string _tnoparent;//父节点编号
        
        public string TNO//属性：节点编号
        {
            set { _tno = value; }
            get { return _tno; }
        }

        public string TName//属性：节点名称
        {
            set { _tname = value; }
            get { return _tname; }
        }

        public FormTreeEdit()
        {
            InitializeComponent();
        }
        public FormTreeEdit(int editflag, string tno)
        {
            _editflag = editflag;
            _tno = tno;
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //关闭窗口
            this.Close();
        }

        private void FormTreeEdit_Load(object sender, EventArgs e)
        {
            if (_editflag == 0)
            {
                this.Text = "新增兄弟节点";
                _tnoparent = _tno;//保存父节点编号
            }
            else if (_editflag == 1)
            {
                this.Text = "新增子节点";
                _tnoparent = _tno;//保存父节点编号
            }
            else if (_editflag == 2)
            {
                this.Text = "修改节点";
                this.dataTNO.ReadOnly = true;//编号不可修改
                StudentMS.Model.Tree model = new StudentMS.BLL.Tree().GetModel(_tno);
                if (model != null)
                {
                    this.dataTNO.Text = model.TNO;
                    this.dataTName.Text = model.TName;
                    _tnoparent = model.TNOParent;//父节点编号
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            String strError = "";
            if (this.dataTNO.Text.Trim() == "")
                strError += "节点编号不得为空！";
            if (this.dataTName.Text.Trim() == "")
                strError += "节点名称不得为空！";
            if (strError != "")
            {
                MessageBox.Show(this, strError, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //实例化Model并给model的各属性赋值
            StudentMS.Model.Tree model = new StudentMS.Model.Tree();
            model.TNO = this.dataTNO.Text.Trim();//节点编号
            model.TName = this.dataTName.Text.Trim();//节点名称
            model.TNOParent = _tnoparent;//父节点编号

            //实例化BLL层并调用方法实现数据更新
            StudentMS.BLL.Tree bll = new StudentMS.BLL.Tree();
            try
            {
                if (_editflag == 0 || _editflag == 1)
                    bll.Add(model);
                else if (_editflag == 2)
                    bll.Update(model);
                //更新属性值
                _tno = model.TNO;
                _tname = model.TName;
                //设置弹出窗口的返回值
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "更新数据失败！\n" + ex.Message, "出错了", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
