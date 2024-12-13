<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="13_textbox_autocomplete_gridview.aspx.cs" Inherits="WebApplication1._13_textbox_autocomplete_gridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
            <asp:GridView ID="gvResults" runat="server" AutoGenerateColumns="True"></asp:GridView>
        </div>
    </form>
</body>
</html>
