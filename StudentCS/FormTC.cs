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
    public partial class FormTC : Form
    {
        public FormTC()
        {
            InitializeComponent();
        }

        private void select_Click(object sender, EventArgs e)
        {
            //获取用户在界面输入的参数
            string tno = this.textTNO.Text.Trim();
            string tname = this.textTName.Text.Trim();
            //实例化BLL层并调用方法getListStudent获取教师档案列表
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();

            this.dataGridView1.DataSource = bll.GetListTeacher(tno, tname).Tables[0].DefaultView;
        }

        private void SetLesson_Click(object sender, EventArgs e)
        {
            //获取TNO和TNO
            string tno = this.dataGridView1.SelectedRows[0].Cells["TNO"].Value.ToString();
            string cno = this.dataGridView3.SelectedRows[0].Cells["CNO1"].Value.ToString();

            //实例化Model层并给Model的各个属性赋值
            StudentMS.Model.T_C model = new StudentMS.Model.T_C();
            model.TNO = tno;
            model.CNO = cno;

            //实例化BLL层并给BLL的各个属性赋值
            StudentMS.BLL.T_C bll = new StudentMS.BLL.T_C();
            try
            {
                //更新到数据库中
                bll.Add(model);
                //刷新显示
                this.dataGridView1_SelectionChanged(dataGridView1, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "选课失败！\n" + ex.Message, "出错了！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        

        private void FinishLesson_Click(object sender, EventArgs e)
        {
            //获取TNO和TNO
            string tno = this.dataGridView1.SelectedRows[0].Cells["TNO"].Value.ToString();
            string cno = this.dataGridView2.SelectedRows[0].Cells["CNO"].Value.ToString();

            //实例化BLL层并调用方法DELETE删除所选记录
            StudentMS.BLL.T_C bll = new StudentMS.BLL.T_C();
            try
            {
                //从数据库中删除记录
                bll.Delete(tno, cno);
                //刷新显示
                this.dataGridView1_SelectionChanged(dataGridView1, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "退课失败！\n" + ex.Message, "出错了！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0)
                return;
            //获取被选中的记录的SNO
            string tno = this.dataGridView1.SelectedRows[0].Cells["TNO"].Value.ToString();
            //实例化BLL层并调用方法getListSC获取已选课程列表和未选课程列表
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();
            this.dataGridView2.DataSource = bll.GetListTC(tno, 1).Tables[0].DefaultView;
            this.dataGridView3.DataSource = bll.GetListTC(tno, 0).Tables[0].DefaultView;

            //刷新按钮[选课]和[被选]的可用性
            this.SetLesson.Enabled = this.dataGridView3.SelectedRows.Count > 0;
            this.FinishLesson.Enabled = this.dataGridView2.SelectedRows.Count > 0;
        }

    }
}
