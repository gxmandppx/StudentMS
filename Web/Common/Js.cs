using System;
using System.Text;

/// <summary>
/// ASP.NET消息提示框
/// </summary>
public class Js
{

    /// <summary>
    /// 显示消息提示对话框
    /// </summary>
    /// <param name="page">当前页面指针，一般为this</param>
    /// <param name="msg">提示信息</param>
    public static void Alert(System.Web.UI.Page page, string msg)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
    }

    /// <summary>
    /// 控件添加消息确认提示框
    /// </summary>
    /// <param name="page">控件对象或this</param>
    /// <param name="msg">提示信息</param>
    public static void ControlClickConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
    {
        Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
    }

    /// <summary>
    /// 控件添加自定义脚本
    /// </summary>
    /// <param name="page">控件对象或this</param>
    /// <param name="method">控件添加的事件，只能是js所支持的事件</param>
    /// <param name="script">脚本</param>
    public static void ControlAddScript(System.Web.UI.WebControls.WebControl Control, string method, string script)
    {
        Control.Attributes.Add(method, script);
    }


    /// <summary>
    /// 显示消息提示对话框，并进行页面跳转
    /// </summary>
    /// <param name="page">当前页面指针，一般为this</param>
    /// <param name="msg">提示信息</param>
    /// <param name="url">跳转的目标URL</param>
    public static void AlertAndRedirect(System.Web.UI.Page page, string msg, string url)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg + "');window.location=\"" + url + "\"</script>");
    }

    /// <summary>
    /// 显示消息提示对话框，并使主框架页跳转
    /// </summary>
    /// <param name="page">当前页面指针，一般为this</param>
    /// <param name="msg">提示信息</param>
    /// <param name="url">跳转的目标URL</param>
    public static void AlertAndRedirectWithFrame(System.Web.UI.Page page, string msg, string url)
    {
        StringBuilder Builder = new StringBuilder();
        Builder.Append("<script language='javascript' defer>");
        Builder.AppendFormat("alert('{0}');", msg);
        Builder.AppendFormat("top.location.href='{0}'", url);
        Builder.Append("</script>");
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

    }

    /// <summary>
    /// 输出自定义脚本信息
    /// </summary>
    /// <param name="page">当前页面指针，一般为this</param>
    /// <param name="script">输出脚本</param>
    public static void ResponseScript(System.Web.UI.Page page, string script)
    {
        page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
    }
}
