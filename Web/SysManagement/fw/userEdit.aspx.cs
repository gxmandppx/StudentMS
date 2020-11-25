using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class userEdit : System.Web.UI.Page
    {

        protected int EditFlag//编辑状态  0-新增  1-修改
        {
            set { ViewState["_editflag"] = value;}
            get { return int.Parse(ViewState["_editflag"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Js.ControlClickConfirm(this.OK,"确定提交？\n");
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
                        this.UserID.ReadOnly = true;//用户名只读
                        //依据UserID获取该用户相关信息，便展示在编辑信息框里
                        StudentMS.Model.S_User model = new StudentMS.BLL.S_User().GetModel(id);
                        if (model != null)
                        {
                            this.UserID.Text = model.UserID;
                            this.UPassword.Text = model.UPassWord;
                            this.SNO.Text = model.SNO;
                            this.TNO.Text = model.TNO;
                        }
                    }
                }
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("user.aspx");
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            string strError = "";
            if (this.UserID.Text.Trim() == "")
                strError += "用户名不可为空！\\n";
            if (this.UPassword.Text.Trim() == "")
                strError += "密码不能为空！\\n";
            if (strError != "")
            {
                Js.Alert(this, strError);
                return;
            }

            StudentMS.Model.S_User model = new StudentMS.Model.S_User();
            StudentMS.BLL.S_User bll = new StudentMS.BLL.S_User();
            model.UserID = this.UserID.Text.Trim();
            model.UPassWord = this.UPassword.Text;
            model.SNO = this.SNO.Text.Trim();
            model.TNO = this.TNO.Text.Trim();

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
                Js.AlertAndRedirect(this, "数据更新成功！\\n","user.aspx");
                //Response.Redirect("user.aspx");
            }catch(Exception ex){
                Js.Alert(this, "出错了！\n" + ex.Message);
                return;
            }
        }
    }
}