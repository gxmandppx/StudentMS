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
    public partial class FormRole : Form
    {

        private bool rightAdd = false, rightDelete = false, rightModify = false;//权限控制

        public FormRole()
        {
            InitializeComponent();
        }

        private void FormRole_Load(object sender, EventArgs e)
        {
            //获取系统中所有角色
            this.dataGridView1.DataSource = new StudentMS.BLL.S_Role().GetAllList().Tables[0].DefaultView;
            rightAdd = StudentMS.BLL.Core.IsHaveRight("YC20");//新增
            rightDelete = StudentMS.BLL.Core.IsHaveRight("YC25");//删除
            rightModify = StudentMS.BLL.Core.IsHaveRight("YC30");//修改

            this.ADD.Enabled = rightAdd;
        }

        private void Right_Click(object sender, EventArgs e)
        {
            //获取被选中的记录的RoleID
            string roleid = this.dataGridView1.SelectedRows[0].Cells["RoleID"].Value.ToString();

            FormRoleRight temp = new FormRoleRight(roleid);
            temp.ShowDialog();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0 && e.Button == MouseButtons.Right && e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dataGridView1.CurrentRow.Selected = false;//取消当前行被选中
                this.dataGridView1.Rows[e.RowIndex].Selected = true;//选择鼠标所在行
            }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            string RoleID = this.dataGridView1.SelectedRows[0].Cells["RoleID"].Value.ToString();
            FormRoleEdit temp = new FormRoleEdit(1, RoleID);//实例化
            temp.ShowDialog();//以对话框的方式展示
            if (temp.DialogResult == DialogResult.OK)
            {
                //this.buttonQuery_Click(this.buttonQuery, e);//数据刷新
                this.AutoLocation(this.dataGridView1, "RoleID", temp.roleid);//自动定位
            }
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            FormRoleEdit temp = new FormRoleEdit(0);//实例化
            temp.ShowDialog();//以对话框形式展示
            if (temp.DialogResult == DialogResult.OK)//数据刷新
            {
                //this.FormRole_Load(, e);
                this.AutoLocation(this.dataGridView1, "RoleID", temp.roleid);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //更新谈出菜单的可用性
            this.Delete.Enabled = rightDelete && this.dataGridView1.SelectedRows.Count > 0;
            this.Modify.Enabled = rightModify && this.dataGridView1.SelectedRows.Count > 0;
        }

        //自动定位 datagrid定位的datagridview  fieldname定位所依据的字段名  locatevalue定位的值
        private void AutoLocation(DataGridView datagrid, string fieldname, string locatevalue)
        {
            if (datagrid.Rows.Count <= 0 || fieldname == "" || locatevalue == "")
                return;
            int found = -1;//是否找到，值是找到的行号
            for (int i = 0; i < datagrid.Rows.Count; i++)
            {
                if (datagrid.Rows[i].Cells[fieldname].Value.ToString() == locatevalue)
                {
                    found = i;
                    break;
                }
            }
            if (found >= 0)
            {
                datagrid.CurrentRow.Selected = false;//取消选择当前行
                datagrid.Rows[found].Selected = true;//选中
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "您确定要删除选中记录吗？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //获取被选中的记录的角色编号RoleID
                string roleid = this.dataGridView1.SelectedRows[0].Cells["RoleID"].Value.ToString();
                //实例化BLL层中的Role
                StudentMS.BLL.S_Role bll = new StudentMS.BLL.S_Role();
                try
                {
                    //调用方法DELETE删除权限记录
                    bll.Delete(roleid);
                    MessageBox.Show(this, "删除成功！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //数据刷新
                    Query();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "删除失败！\n" + ex.Message, "出错咯", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Query()
        {
            //实例化BLL层里的Core
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();

            this.dataGridView1.DataSource = bll.GetListRole().Tables[0].DefaultView;
        }
    }
}
