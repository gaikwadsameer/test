<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminVerify.aspx.cs" Inherits="WebApplication1.two_step_authorization.AdminVerify" %>

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
        </div>
    </form>
</body>
</html>
