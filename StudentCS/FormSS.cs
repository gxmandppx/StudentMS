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
    public partial class FormSS : Form
    {
        public FormSS()
        {
            InitializeComponent();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            //获取用户在界面输入的参数
            string sno = this.textSNO.Text.Trim();
            //实例化BLL层并调用方法getListStudent获取学生档案列表
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();

            this.dataGridView1.DataSource = bll.GetListSS(sno).Tables[0].DefaultView;
        }
    }
}
