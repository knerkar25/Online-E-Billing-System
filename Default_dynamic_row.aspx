<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_dynamic_row.aspx.cs" Inherits="Default_dynamic_row" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <div>
            <asp:Button ID="btnsaveinfo" runat="server" Text="Save info" Visible="false" /><%--OnClick="btnsaveinfo_Click"--%>            
        </div>
        <div>
            <asp:GridView ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false"

                GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Qualification"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Batch"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="Branch"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <hr />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New Row" />
                            <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" OnClick="LinkButton1_Click">Remove</asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <table>
                <asp:GridView ID="gvqualification" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Qualification">
                            <ItemTemplate>
                                <%# Eval("qualification")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Batch">
                            <ItemTemplate>
                                <%# Eval("batch")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Branch">
                            <ItemTemplate>
                                <%# Eval("branch")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </table>
        </div>
        <div>
            <asp:LinkButton ID="lnkshowall" runat="server"  Text="Show All"></asp:LinkButton><%--OnClick="lnkshowall_Click"--%>
        </div>
    </form>
</body>
</html>
