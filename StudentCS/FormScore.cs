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
    public partial class FormScore : Form
    {
        public FormScore()
        {
            InitializeComponent();
        }

        private void FormScore_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "您确定要提交成绩吗？", "提交确认",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int countCommit = 0;//提交成绩的个数

                //实例化Model并给model的各个属性赋值
                StudentMS.Model.S_C model = new StudentMS.Model.S_C();
                model.CNO = this.textCNO.Text.Trim();//课程编号

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    model.SNO = dataGridView1.Rows[i].Cells["SNO"].Value.ToString();
                    if (dataGridView1.Rows[i].Cells["Score"].Value.ToString() == "")
                        continue;
                    try
                    {
                        model.Score = decimal.Parse(dataGridView1.Rows[i].Cells["Score"].Value.ToString());
                    }
                    catch { continue; }
                    //实例化BLL层并调用方法update更新数据
                    StudentMS.BLL.S_C bll = new StudentMS.BLL.S_C();
                    try
                    {
                        bll.Update(model);
                        countCommit++;//提交成绩的个数
                    }
                    catch { }
                }//end_for
                MessageBox.Show(this, "提交了" + countCommit.ToString() + "个学生成绩。\n", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end_if
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取用户在界面输入的参数
            string cno = this.textCNO.Text.Trim();
            //实例化BLL层并调用方法getListStudent获取学生档案列表
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();

            this.dataGridView1.DataSource = bll.GetListS_C(cno).Tables[0].DefaultView;
        }
    }
}








        /*
        private void buttonOK_Click(object sender, EventArgs e)
        {
            //数据校验
            string strError = "";
            if (this.textSNO.Text.Trim() == "")
                strError += "学号不能为空，请重新输入！\n";
            int score = 0;
            try
            {
                score = int.Parse(this.textScore.Text.Trim());
                if (score <= 0)
                {
                    strError += "分数只能是正整数！\n";
                }
                if (score > 100)
                {
                    strError += "分数不能超出满分！\n";
                }
                StudentMS.BLL.S_C bll = new StudentMS.BLL.S_C();
                //初始化下拉框的数据列表
                StudentMS.BLL.Course bll = new StudentMS.BLL.Course();
                this.comboCourse.DataSource = bll.GetAllList().Tables[0].DefaultView;//数据源
                this.comboCourse.ValueMember = "CNO";//值的字段名
                this.comboCourse.DisplayMember = "CName";//显示的字段名
                if (bll.GetList(" SNO = '" + this.textSNO.Text.Trim() + "' and CNO = '" + this.comboCourse.SelectedValue.ToString() + "'") == null)
                {
                    strError += "该生未选此课！\n";
                }
            }
            catch
            {
                strError += "请重新输入！\n";
            }
            if (strError != "")
            {
                MessageBox.Show(this, strError, "校验提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //实例化Model，并给Model赋值
            StudentMS.Model.S_C model = new StudentMS.Model.S_C();
            model.SNO = this.textSNO.Text.Trim();//学号
            model.CNO = this.comboCourse.SelectedValue.ToString();//课程号
            model.Score = score;
            //实例化BLL层并调用相应的方法访问数据库
            StudentMS.BLL.S_C bll1 = new StudentMS.BLL.S_C();
            try
            {
                bll1.Update(model);

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
}*/
