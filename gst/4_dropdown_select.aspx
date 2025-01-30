<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="4_dropdown_select.aspx.cs" Inherits="WebApplication1.two_step_authorization._4_dropdown_select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager1" />
        
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddlCategory1" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlCategory1_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlCategory2" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlCategory2_SelectedIndexChanged" Visible="false">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlCategory3" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlCategory3_SelectedIndexChanged" Visible="false">
                </asp:DropDownList>

                <asp:DropDownList ID="ddlCategory4" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlCategory4_SelectedIndexChanged" Visible="false">
                </asp:DropDownList>

                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="true" Visible="false"></asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
