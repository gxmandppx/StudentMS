<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherEdit.aspx.cs" Inherits="Web.SysManagement.TeacherEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style3
        {
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
        .style4
        {
            height: 20px;
            width: 124px;
            text-align: right;
        }
        .style2
        {
            height: 20px;
        }
        .auto-style1 {
            width: 124px;
            text-align: right;
            height: 26px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <table class="style1">
        <tr>
            <td align="right" class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style5">
                工号</td>
            <td class="style6">
                <asp:TextBox ID="BoxTNO" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style7">
                姓名</td>
            <td class="style8">
                <asp:TextBox ID="BoxTName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style4">
                性别</td>
            <td class="style2">
                <asp:TextBox ID="BoxTSex" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style1">
                年龄</td>
            <td class="auto-style2">
                <asp:TextBox ID="BoxTAge" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style1">
                住址</td>
            <td class="auto-style2">
                <asp:TextBox ID="BoxTAddress" runat="server"></asp:TextBox>
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
