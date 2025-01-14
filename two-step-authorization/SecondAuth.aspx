<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecondAuth.aspx.cs" Inherits="WebApplication1.two_step_authorization.SecondAuth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
       <form id="form1" runat="server">
        <h2>Second Authorization</h2>
        <label for="secondAuthCode">Enter Authorization Code:</label>
        <asp:TextBox ID="txtSecondAuthCode" runat="server" CssClass="input-box"></asp:TextBox><br/>
        <asp:Button ID="btnAuthorize" runat="server" Text="Authorize" OnClick="btnAuthorize_Click" CssClass="btn" />
        <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
    </form>
</body>
</html>
