<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2XlXS1_download.aspx.cs" Inherits="WebApplication1._2XlXS1_download" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <form id="form1" runat="server">
        <div>
            <h2>Upload Two Excel Files</h2>

            <asp:Label ID="lblFile1" runat="server" Text="File 1:"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" /><br />

            <asp:Label ID="lblFile2" runat="server" Text="File 2:"></asp:Label>
            <asp:FileUpload ID="FileUpload2" runat="server" /><br /><br />

            <asp:Button ID="btnCompare" runat="server" Text="Compare & Download" OnClick="btnCompare_Click" />

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" /><br /><br />

            <asp:HyperLink ID="DownloadLink" runat="server" Text="Download Result" Visible="false" />
        </div>
    </form>
</body>
</html>
