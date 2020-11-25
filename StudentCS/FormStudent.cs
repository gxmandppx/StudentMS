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
    public partial class FormStudent : Form
    {

        private bool rightAdd = false, rightDelete = false, rightModify = false,rightQuery = false;//权限控制

        public FormStudent()
        {
            InitializeComponent();
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            //获取用户在界面输入的参数
            string sno = this.textBoxSNO.Text.Trim();
            string sname = this.textBoxSName.Text.Trim();
            //实例化BLL层里的Core
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();

            this.dataGridView1.DataSource = bll.GetListStudent(sno, sname).Tables[0].DefaultView;
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this,"您确定要删除选中记录吗？","删除确认",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                //获取被选中的记录的学号SNO
                string sno = this.dataGridView1.SelectedRows[0].Cells["SNO"].Value.ToString();
                //实例化BLL层中的student
                StudentMS.BLL.Student bll = new StudentMS.BLL.Student();
                try
                {
                    //调用方法DELETE删除学生档案记录
                    bll.Delete(sno);
                    MessageBox.Show(this, "删除成功！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //调用查询功能实现数据刷新
                    this.buttonQuery_Click(this.buttonQuery, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "删除失败！\n" + ex.Message, "出错咯", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0 && e.Button == MouseButtons.Right && e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dataGridView1.CurrentRow.Selected = false;//取消当前行被选中
                this.dataGridView1.Rows[e.RowIndex].Selected = true;//选择鼠标所在行
            }
        }

        private void MenuItemAdd_Click(object sender, EventArgs e)
        {
            FormStudentEdit temp = new FormStudentEdit(0);//实例化
            temp.ShowDialog();//以对话框形式展示
            if (temp.DialogResult == DialogResult.OK)//调用查询功能实现数据刷新
                this.buttonQuery_Click(this.buttonQuery, e);
                this.AutoLocation(this.dataGridView1,"SNO",temp.SSNO);
        }

        private void MenuItemModify_Click(object sender, EventArgs e)
        {
            string sno = this.dataGridView1.SelectedRows[0].Cells["SNO"].Value.ToString();
            FormStudentEdit temp = new FormStudentEdit(1, sno);//实例化
            temp.ShowDialog();//以对话框的方式展示
            if (temp.DialogResult == DialogResult.OK)
                this.buttonQuery_Click(this.buttonQuery, e);//调用查询功能实现数据刷新
                this.AutoLocation(this.dataGridView1,"SNO",temp.SSNO);//自动定位
        }
        //自动定位 datagrid定位的datagridview  fieldname定位所依据的字段名  locatevalue定位的值
        private void AutoLocation(DataGridView datagrid, string fieldname, string locatevalue)
        { 
            if(datagrid.Rows.Count<=0 || fieldname == "" || locatevalue == "")
                return;
            int found = -1;//是否找到，值是找到的行号
            for(int i = 0;i < datagrid.Rows.Count;i++)
            {
                if(datagrid.Rows[i].Cells[fieldname].Value.ToString() == locatevalue)
                {
                    found = i;
                    break;
                }
            }
            if(found >= 0)
            {
                datagrid.CurrentRow.Selected = false;//取消选择当前行
                datagrid.Rows[found].Selected = true;//选中
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //更新谈出菜单的可用性
            this.MenuItemDelete.Enabled = rightDelete && this.dataGridView1.SelectedRows.Count > 0;
            this.MenuItemModify.Enabled = rightModify && this.dataGridView1.SelectedRows.Count > 0;
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            rightAdd = StudentMS.BLL.Core.IsHaveRight("5");//新增
            rightDelete = StudentMS.BLL.Core.IsHaveRight("10");//删除
            rightModify = StudentMS.BLL.Core.IsHaveRight("15");//修改

            this.MenuItemAdd.Enabled = rightAdd;
        }
    }
}
