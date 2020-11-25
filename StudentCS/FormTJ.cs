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
    public partial class FormTJ : Form
    {
        public FormTJ()
        {
            InitializeComponent();
        }

        private void FormTJ_Load(object sender, EventArgs e)
        {
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();
            this.dataGridView1.DataSource = bll.GetListTJ().Tables[0].DefaultView;
        }
    }
}
