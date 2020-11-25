<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Web.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #000066; color: #66FF33">
    
        <asp:TreeView ID="TreeView1" runat="server" Height="100%" Width="184px">
            <HoverNodeStyle ForeColor="White" />
            <Nodes>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="~/SysManagement/user.aspx" Text="用户管理" Value="新建节点" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
                <asp:TreeNode Text="新建节点" Value="新建节点"></asp:TreeNode>
            </Nodes>
            <NodeStyle ForeColor="#00CC00" NodeSpacing="6px" />
            <SelectedNodeStyle BackColor="#FF6600" ForeColor="#00CC00" NodeSpacing="6px" />
        </asp:TreeView>
    
        <table class="style1">
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
