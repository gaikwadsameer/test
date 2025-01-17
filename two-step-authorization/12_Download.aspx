<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="12_Download.aspx.cs" Inherits="WebApplication1._12_Download" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Download PDF</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Download PDF</h2>
            <asp:Label ID="lblDocumentId" runat="server" Text="Document ID:"></asp:Label>
            <asp:TextBox ID="txtDocumentId" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>

