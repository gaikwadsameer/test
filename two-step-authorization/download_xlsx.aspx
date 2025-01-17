<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="download_xlsx.aspx.cs" Inherits="WebApplication1.two_step_authorization.download_xlsx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        
        <asp:Label runat="server" Text="From Date:" />
        <asp:TextBox ID="txtFromDate" runat="server" type="date"></asp:TextBox>
        <%--<asp:CalendarExtender TargetControlID="txtFromDate" runat="server" Format="yyyy-MM-dd" />--%>

        <asp:Label runat="server" Text="To Date:" />
        <asp:TextBox ID="txtToDate" runat="server" type="date"></asp:TextBox>
        <%--<asp:CalendarExtender TargetControlID="txtToDate" runat="server" Format="yyyy-MM-dd" />--%>

        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
        <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="grid-view" />

    </form>
</body>
</html>
