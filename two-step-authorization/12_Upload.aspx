<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="12_Upload.aspx.cs" Inherits="WebApplication1._12_Upload" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload PDF</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Upload PDF</h2>
            <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name:"></asp:Label>
            <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
            <br />
            <asp:FileUpload ID="fileUpload" runat="server" />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>

