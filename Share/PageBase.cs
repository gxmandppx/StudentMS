using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public class PageBase : System.Web.UI.Page
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public PageBase()
    {

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.Load += new System.EventHandler(PageBase_Load);
        this.Error += new System.EventHandler(PageBase_Error);
    }
    //错误处理
    protected void PageBase_Error(object sender, System.EventArgs e)
    {
        string errMsg;
        Exception currentError = Server.GetLastError();
        errMsg = "<link rel=\"stylesheet\" href=\"/style.css\">";
        errMsg += "<h1>系统错误：</h1><hr/>系统发生错误， " +
            "该信息已被系统记录，请稍后重试或与管理员联系。<br/>" +
            "错误地址： " + Request.Url.ToString() + "<br/>" +
            "错误信息： <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
            "<b>Stack Trace:</b><br/>" + currentError.ToString();
        Response.Write(errMsg);
        Server.ClearError();

    }

    //设置编辑型控件是否可写
    protected void setControlReadOnly(System.Web.UI.Control contrl,bool bl)
    {
        int ctl_count = contrl.Controls.Count;
        for (int i = 0; i < ctl_count; i++)
        {
            foreach (Control ctl in contrl.Controls[i].Controls)
            {
                if (ctl.HasControls())
                {
                    setControlReadOnly(ctl.Parent, bl);
                }
                else
                {
                    if (ctl is TextBox)
                    {
                        if (bl==true)
                            (ctl as TextBox).BackColor = System.Drawing.Color.Silver;// "#E1E1E0";
                        (ctl as TextBox).ReadOnly = bl;
                    }
                    if (ctl is CheckBox)
                        (ctl as CheckBox).Enabled = !bl;
                    if (ctl is DropDownList)
                        (ctl as DropDownList).Enabled = !bl;
                }
            }
        }
    }

    //设置编辑型控件是否可写
    protected void setControlColor(System.Web.UI.Control contrl)
    {
        int ctl_count = contrl.Controls.Count;
        for (int i = 0; i < ctl_count; i++)
        {
            foreach (Control ctl in contrl.Controls[i].Controls)
            {
                if (ctl.HasControls())
                {
                    setControlColor(ctl.Parent);
                }
                else
                {
                    if (ctl is TextBox)
                    {
                        if ((ctl as TextBox).ReadOnly == true)
                            (ctl as TextBox).BackColor = System.Drawing.Color.Silver;// "#E1E1E0";
                        else (ctl as TextBox).BackColor = System.Drawing.Color.White;
                    }
                    //if (ctl is CheckBox)
                    //    (ctl as CheckBox).Enabled = !bl;
                    if (ctl is DropDownList)
                    {
                        if ((ctl as DropDownList).Enabled == false)
                            (ctl as DropDownList).BackColor = System.Drawing.Color.Silver;// "#E1E1E0";
                        else (ctl as DropDownList).BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
    }
    private void PageBase_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //如果未登录则跳转到首页
            if (Session["UID"] == null)
                Response.Redirect("~/Default.aspx");
        }
    }
}
