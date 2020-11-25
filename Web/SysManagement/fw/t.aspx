<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t.aspx.cs" Inherits="Web.SysManagement.user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户管理</title>
    <script src="../Common/check.js" type="text/javascript" charset="gb2312"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 264px;
        }
        .style3
        {
            width: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="工号"></asp:Label>
                    <asp:TextBox ID="TextTNO" runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonQuery" runat="server" 
                        Text="查 询" Width="49px" />
                </td>
                <td>
                    <asp:Button ID="ButtonAdd" runat="server" onclick="ButtonAdd_Click" 
                        Text=" 新 增 " style="width: 69px" />
                    <asp:Button ID="ButtonModify" runat="server" Text=" 修 改 " 
                        onclick="ButtonModify_Click" />
                    <asp:Button ID="ButtonDelete" runat="server" Text=" 删 除 " 
                        onclick="ButtonDelete_Click" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td colspan="8">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Check" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TNO" HeaderText="工号" />
                            <asp:BoundField DataField="TName" HeaderText="姓名" />
                            <asp:BoundField DataField="TSex" HeaderText="性别" />
                            <asp:BoundField DataField="TAge" HeaderText="年龄" />
                            <asp:BoundField DataField="TAddress" HeaderText="住址" />
                            <asp:HyperLinkField DataNavigateUrlFields="TNO" 
                                DataNavigateUrlFormatString="teacherEdit.aspx?id={0}" HeaderText="操作" 
                                Text="编辑">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td colspan="8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
