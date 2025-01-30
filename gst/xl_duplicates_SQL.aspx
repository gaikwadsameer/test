<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xl_duplicates_SQL.aspx.cs" Inherits="WebApplication1.two_step_authorization.xl_duplicates_SQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Excel File</title>
    <style>
        body { font-family: Arial, sans-serif; padding: 20px; }
        .container { max-width: 600px; margin: auto; text-align: center; }
        .grid-container { margin-top: 20px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Upload Excel File</h2>
            
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload & Insert" OnClick="btnUpload_Click" />
            
            <br /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <div class="grid-container">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" BorderWidth="1"
                    CssClass="table table-bordered" />
            </div>
        </div>
    </form>
</body>
</html>
