<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userEdit.aspx.cs" Inherits="Web.userEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 20px;
        }
        .style3
        {
            width: 124px;
            text-align: right;
        }
        .style4
        {
            height: 20px;
            width: 124px;
            text-align: right;
        }
        .style5
        {
            height: 18px;
            width: 124px;
            text-align: right;
        }
        .style6
        {
            height: 18px;
        }
        .style7
        {
            height: 22px;
            width: 124px;
            text-align: right;
        }
        .style8
        {
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td align="right" class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style5">
                用户名</td>
            <td class="style6">
                <asp:TextBox ID="UserID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style7">
                密码</td>
            <td class="style8">
                <asp:TextBox ID="UPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style4">
                学号</td>
            <td class="style2">
                <asp:TextBox ID="SNO" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                工号</td>
            <td>
                <asp:TextBox ID="TNO" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                <asp:Button ID="OK" runat="server" onclick="OK_Click" Text="提交" />
            </td>
            <td>
                <asp:Button ID="Cancel" runat="server" onclick="Cancel_Click" Text="取消" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
