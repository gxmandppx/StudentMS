<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="Web.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #006699">
    
        <asp:TreeView ID="TreeView1" runat="server" Width="154px" Height="100%">
            <Nodes>
                <asp:TreeNode Text="用户管理" Value="新建节点" NavigateUrl="~/SysManagement/user.aspx" 
                    Target="mainFrame"></asp:TreeNode>
                <asp:TreeNode Text="教师档案查询" Value="新建节点" NavigateUrl="~/SysManagement/Teacher.aspx" 
                    Target="mainFrame"></asp:TreeNode>
                <asp:TreeNode Text="学生档案查询" Value="新建节点" NavigateUrl="~/SysManagement/Student.aspx" 
                    Target="mainFrame"></asp:TreeNode>
            </Nodes>
            <NodeStyle ForeColor="#99FF66" NodeSpacing="6px" />
            <SelectedNodeStyle BackColor="#000066" ForeColor="#66CCFF" NodeSpacing="6px" />
        </asp:TreeView>
    
    </div>
    </form>
</body>
</html>
