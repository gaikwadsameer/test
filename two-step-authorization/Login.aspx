<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.two_step_authorization.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <h2>Login</h2>
        <label for="username">Username:</label>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="input-box"></asp:TextBox><br/>
        <label for="password">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="input-box" TextMode="Password"></asp:TextBox><br/>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn" />
        <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
    </form>
</body>
</html>
