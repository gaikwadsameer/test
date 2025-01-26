<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gridview_button.aspx.cs" Inherits="adminpanel.gridview_button" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvdata" runat="server" OnRowCommand="gvdata_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="ID" />
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:BoundField DataField="UserType" HeaderText="UserType" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button runat="server" CommandName="add" CommandArgument='<%# Eval("Password") %>' Text="add" />
                            <asp:Button runat="server" CommandName="deletes" CommandArgument='<%# Eval("Password") %>' Text="deletes" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
