<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MMM_YYYY_dropdown.aspx.cs" Inherits="WebApplication1.two_step_authorization.MMM_YYYY_dropdown" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="dropdownMonthYear" runat="server"></asp:DropDownList>
<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    </form>
</body>
</html>
