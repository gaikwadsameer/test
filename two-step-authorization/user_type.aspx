<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_type.aspx.cs" Inherits="WebApplication1.two_step_authorization.user_type" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        <asp:Button ID="Login" runat="server" Text="Login" OnClick="Login_Click" />

        <asp:Panel ID="adminPanel" runat="server" Visible="false">
            <h2>Welcome Admin</h2>
            <!-- Admin-specific content -->
        </asp:Panel>

        <asp:Panel ID="userPanel" runat="server" Visible="false">
            <h2>Welcome User</h2>
            <!-- User-specific content -->
        </asp:Panel>

        <asp:Panel ID="guestPanel" runat="server" Visible="false">
            <h2>Welcome Guest</h2>
            <!-- Guest-specific content -->
        </asp:Panel>

    </form>
</body>
</html>
