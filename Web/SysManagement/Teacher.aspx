<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="Web.SysManagement.Teacher" %>

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
            width: 10px;
        }
        .style2
        {
            width: 264px;
        }
        .auto-style1 {
            width: 354px;
        }
        .auto-style2 {
            width: 128px;
        }
        .auto-style3 {
            width: 157px;
        }
        .auto-style4 {
            width: 1px;
        }
        .auto-style5 {
            width: 91px;
        }
        .auto-style6 {
            width: 102px;
        }
        .auto-style7 {
            width: 426px;
        }
        .auto-style8 {
            width: 19px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
                    <asp:TextBox ID="BoxTNO" runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonQuery" runat="server" onclick="ButtonQuery_Click" 
                        Text="查 询" />
                </td>
                <td class="auto-style4">
                    <asp:Button ID="ButtonAdd" runat="server" onclick="ButtonAdd_Click" 
                        Text=" 新 增 " />
                </td>
                <td class="auto-style5">
                    <asp:Button ID="ButtonModify" runat="server" Text=" 修 改 " 
                        onclick="ButtonModify_Click" />
                </td>
                <td class="auto-style6">
                    <asp:Button ID="ButtonDelete" runat="server" Text=" 删 除 " 
                        onclick="ButtonDelete_Click" />
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="auto-style7">
                    &nbsp;</td>
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td colspan="10">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField HeaderText="选择">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Check" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TNO" HeaderText="教工号" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TName" HeaderText="姓名" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TAge" HeaderText="年龄">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TSex" HeaderText="性别" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TAddress" HeaderText="住址" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="TNO" 
                                DataNavigateUrlFormatString="TeacherEdit.aspx?id={0}" HeaderText="操作" Text="编辑">
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
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td colspan="10">
                    &nbsp;</td>
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
