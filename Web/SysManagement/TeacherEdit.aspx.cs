using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysManagement
{
    public partial class TeacherEdit : System.Web.UI.Page
    {

        protected int EditFlag//编辑状态  0-新增  1-修改
        {
            set { ViewState["_editflag"] = value; }
            get { return int.Parse(ViewState["_editflag"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Js.ControlClickConfirm(this.OK, "确定提交？\n");
                if (Request.Params["id"] != null)
                {
                    string id = Request.Params["id"].ToString();
                    if (id == "0" || id == " ")//新增
                    {
                        EditFlag = 0;
                    }
                    else//修改
                    {
                        EditFlag = 1;
                        this.BoxTNO.ReadOnly = true;//工号只读
                        //依据TNO获取该用户相关信息，便展示在编辑信息框里
                        StudentMS.Model.Teacher model = new StudentMS.BLL.Teacher().GetModel(id);
                        if (model != null)
                        {
                            this.BoxTNO.Text = model.TNO;
                            this.BoxTName.Text = model.TName;
                            this.BoxTSex.Text = model.TSex;
                            this.BoxTAge.Text = model.TAge.ToString();
                            this.BoxTAddress.Text = model.TAddress;
                        }
                    }
                }
            }
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            string strError = "";
            if (this.BoxTNO.Text.Trim() == "")
                strError += "工号不可为空！\\n";
            if (this.BoxTName.Text.Trim() == "")
                strError += "姓名不能为空！\\n";
            if (strError != "")
            {
                Js.Alert(this, strError);
                return;
            }

            StudentMS.Model.Teacher model = new StudentMS.Model.Teacher();
            StudentMS.BLL.Teacher bll = new StudentMS.BLL.Teacher();
            model.TNO = this.BoxTNO.Text.Trim();
            model.TName = this.BoxTName.Text.Trim();
            model.TSex = this.BoxTSex.Text.Trim();
            model.TAge = int.Parse(this.BoxTAge.Text.Trim());
            model.TAddress = this.BoxTAddress.Text.Trim();

            try
            {
                if (EditFlag == 0)
                {
                    bll.Add(model);
                }
                else
                {
                    bll.Update(model);
                }
                Js.AlertAndRedirect(this, "数据更新成功！\\n", "Teacher.aspx");
                //Response.Redirect("user.aspx");
            }
            catch (Exception ex)
            {
                Js.Alert(this, "出错了！\n" + ex.Message);
                return;
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Teacher.aspx");
        }
    }
}