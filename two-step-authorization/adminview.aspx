<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminview.aspx.cs" Inherits="WebApplication1.two_step_authorization.adminview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage User Roles</h2>
        <asp:DropDownList ID="ddlUsers" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlRoles" runat="server"></asp:DropDownList>
        <asp:Button ID="btnAssignRole" runat="server" Text="Assign Role" OnClick="btnAssignRole_Click" />

        <h2>Manage Permissions</h2>
        <asp:DropDownList ID="ddlPages" runat="server">
            <asp:ListItem Text="Data Entry" Value="DataEntryPage"></asp:ListItem>
        </asp:DropDownList>
        <asp:CheckBox ID="chkView" runat="server" Text="Can View" />
        <asp:CheckBox ID="chkEdit" runat="server" Text="Can Edit" />
        <asp:Button ID="btnSavePermission" runat="server" Text="Save Permission" OnClick="btnSavePermission_Click" />

    </form>
</body>
</html>
