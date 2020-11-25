using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.SysManagement
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //给客户端脚本提供初始化数据（单机事件和关键字）
                ButtonDelete.OnClientClick = "return CheckDelete('" + this.GridView1.ClientID + "')";//客户端
                this.GridView1.DataKeyNames = new string[] { "UserID" };//关键字
                this.ButtonQuery_Click(this.ButtonQuery, e);
            }
        }

        protected void ButtonQuery_Click(object sender, EventArgs e)
        {
            string userid = this.TextBoxUserID.Text.Trim();
            StudentMS.BLL.Core bll = new StudentMS.BLL.Core();
            this.GridView1.DataSource = bll.GetListUser(userid).Tables[0];
            this.GridView1.DataBind();
        }

      

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("userEdit.aspx?id=0");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string idList = "";
            foreach (GridViewRow row in this.GridView1.Rows)//遍历所有状态为Select的复选框
            {
                CheckBox cb = (CheckBox)row.FindControl("check");
                if (cb != null && cb.Checked == true)//获取id并加入待删除列表idList中
                    idList += "'" + GridView1.DataKeys[row.RowIndex]["UserID"].ToString() + "',";
            }
            idList = idList.TrimEnd(',');//去掉最后一个逗号
            try{
                new StudentMS.BLL.S_User().DeleteList(idList);//删除列表idList中的记录

                Js.Alert(this, "删除成功！");
                this.ButtonQuery_Click(this.ButtonQuery,e);//刷新界面
            }catch(Exception ex){
                Js.Alert(this, "出错了！\n" + ex.Message);
                return;
            }
        }

        protected void ButtonModify_Click(object sender, EventArgs e)
        {
            string idList = "";
            foreach(GridViewRow row in this.GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("check");
                if (cb != null && cb.Checked == true)//获取id加入待修改列表idList中
                    idList += "'" + GridView1.DataKeys[row.RowIndex]["UserID"].ToString() + "',";
            }
            idList = idList.TrimEnd(',');//去掉最后一个逗号
            try
            {
                //new StudentMS.BLL.S_User().DeleteList()
            }
            catch(Exception ex)
            {

            }
        }
    }
}