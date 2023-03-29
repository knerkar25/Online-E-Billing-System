<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeFile="RawMaterials.aspx.cs" Inherits="RawMaterials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    RAW MATERIAL
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="nav-justified">
        <tr>
            <td style="width: 202px" class="text-right">
                <asp:Label ID="Lbl_pcd" runat="server" Text="Code"></asp:Label>
            </td>
            <td style="width: 472px">
                &nbsp;&nbsp;
                <asp:TextBox ID="TextBox_pcd" runat="server" Width="200px" OnTextChanged="TextBox_pcd_TextChanged"></asp:TextBox>
                <br />
&nbsp;&nbsp;
                </td>
            <td rowspan="6" class="text-left">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PID" 
                    CellPadding="5" ForeColor="#333333" GridLines="None" Height="280px" style="margin-left: 9px" Width="550px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" PageSize="5">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>                      
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkBtn_edt" runat="server" CommandName="edt" CommandArgument='<% # Eval("PID") %>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkBtn_del" runat="server" CommandName="del" CommandArgument='<% # Eval("PID") %>'>Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PCode" HeaderText="Product Code" SortExpression="PCode" />
                        <asp:BoundField DataField="PName" HeaderText="Product Name" SortExpression="PName" />
                        <asp:BoundField DataField="PPrice" HeaderText="Product Price" SortExpression="PPrice" />
                        <%--<asp:BoundField DataField="PImage" HeaderText="Product Image" SortExpression="PImage" />    --%>                                           
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<% # Eval("PImage") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 202px" class="text-right">
                <asp:Label ID="Lbl_pnm" runat="server" Text="Name"></asp:Label>
            </td>
            <td style="width: 472px">
                &nbsp;&nbsp;
                <asp:TextBox ID="TextBox_pnm" runat="server" Width="200px"></asp:TextBox>
                <br />
&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style="width: 202px" class="text-right">
                <asp:Label ID="Lbl_ppr" runat="server" Text="Price"></asp:Label>
            </td>
            <td style="width: 472px">
                &nbsp;&nbsp;
                <asp:TextBox ID="TextBox_ppr" runat="server" Width="200px"></asp:TextBox>
                <br />
&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td style="width: 202px" class="text-right">&nbsp;</td>
            <td style="width: 472px">&nbsp;<div class="text-left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                </div>
                </td>
        </tr>
        <tr>
            <td style="width: 202px" class="text-right">&nbsp;</td>
            <td style="width: 472px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 202px">&nbsp;</td>
            <td style="width: 472px">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-left" style="width: 202px">
            &nbsp;</td>
            <td colspan="2">
                <asp:Button ID="Btn_Insert" runat="server" Font-Bold="True" class="btn btn-success" Font-Italic="True" Font-Underline="False" Text="Insert" OnClick="Btn_Insert_Click" />
            &nbsp; <asp:Button ID="Btn_Update" runat="server" Font-Bold="True" class="btn btn-info" Font-Italic="True" Font-Underline="False" Text="Update" OnClick="Btn_Update_Click" />
            &nbsp; <asp:Button ID="Btn_Reset" runat="server" Font-Bold="True" class="btn btn-basic" Font-Italic="True" Font-Underline="False" Text="Reset" OnClick="Btn_Reset_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

