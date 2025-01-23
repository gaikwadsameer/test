<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminVerify.aspx.cs" Inherits="adminpanel.AdminVerify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>


    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtData" runat="server"></asp:TextBox>

    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click1" />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>




    


            <asp:Panel ID="adminPanel" runat="server" Visible="false">
     <h2>Welcome Admin</h2>
                <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" OnRowCommand="gvData_RowCommand">
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="ID" />
        <asp:BoundField DataField="DataText" HeaderText="Data" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button runat="server" CommandName="Verify" CommandArgument='<%# Eval("UserID") %>' Text="Verify" />
                <asp:Button runat="server" CommandName="Reject" CommandArgument='<%# Eval("UserID") %>' Text="Reject" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
     <!-- Admin-specific content -->
 </asp:Panel>

 <asp:Panel ID="userPanel" runat="server" Visible="false">
     <h2>Welcome User</h2>
     <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" OnRowCommand="gvUser_RowCommand">
    <Columns>
        <asp:BoundField DataField="UserID" HeaderText="ID" />
        <asp:BoundField DataField="DataText" HeaderText="Data" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button runat="server" CommandName="Verify" CommandArgument='<%# Eval("UserID") %>' Text="Verify" />
                <asp:Button runat="server" CommandName="Reject" CommandArgument='<%# Eval("UserID") %>' Text="Reject" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
     <!-- User-specific content -->
 </asp:Panel>

 <asp:Panel ID="guestPanel" runat="server" Visible="false">
     <h2>Welcome Guest</h2>
     <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
<asp:TextBox ID="DataText" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
     <!-- Guest-specific content -->
 </asp:Panel>
</div>
    </form>
</body>
</html>
