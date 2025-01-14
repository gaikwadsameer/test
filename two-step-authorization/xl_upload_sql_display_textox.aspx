<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xl_upload_sql_display_textox.aspx.cs" Inherits="WebApplication1.two_step_authorization.xl_upload_sql_display_textox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        <br />
        <asp:TextBox ID="txtData1" runat="server" />
        <asp:TextBox ID="txtData2" runat="server" />
       <%-- <asp:TextBox ID="txtData3" runat="server" />--%>

    </form>
</body>
</html>
