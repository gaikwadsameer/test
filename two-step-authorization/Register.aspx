<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.two_step_authorization.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Register User</h2>
        <label for="txtUserId">UserId:</label>
        <asp:TextBox ID="txtUserId" runat="server"></asp:TextBox><br />
        <br />

        <label for="txtUsername">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        <br />

        <label for="txtPassword">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />

        <label for="txtRoleId">RoleId:</label>
        <asp:TextBox ID="txtRoleId" runat="server"></asp:TextBox><br />
        <br />

        <label for="txtFirstAuthCode">First Auth Code:</label>
        <asp:TextBox ID="txtFirstAuthCode" runat="server"></asp:TextBox><br />
        <br />

        <label for="txtSecondAuthCode">Second Auth Code:</label>
        <asp:TextBox ID="txtSecondAuthCode" runat="server"></asp:TextBox><br />
        <br />

        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
