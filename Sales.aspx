<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeFile="Sales.aspx.cs" Inherits="Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image1" runat="server" Height="30px" ImageUrl="~/Image/user.png" Width="30px" />
    <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Welcome"></asp:Label>
    <asp:Label ID="Lbl_unm" runat="server" Font-Size="Medium"></asp:Label>
&nbsp;
    <asp:ImageButton ID="Imgbtn_cart"  runat="server" Height="30px" ImageUrl="~/Image/FullBag.png" Width="30px" OnClick="Imgbtn_cart_Click"/>
    <asp:Label ID="lbl_CartItems" runat="server" Font-Size="Small" Text="View My Cart" Visible="false" Font-Bold="True"  ForeColor="#33CCFF"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table class="nav-justified">
        <tr>
            <td>
                <br />
                <br />
                Search Product
                <asp:TextBox ID="TxtBox_search" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Btn_search" runat="server" OnClick="Btn_search_Click" Text="Search" class="btn btn-info"/>
    &nbsp; <asp:Button ID="Btn_clear" runat="server" Text="Clear" class="btn btn-primary" OnClick="Btn_clear_Click"/>
    <asp:DataList ID="DataList1" runat="server" Font-Names="Comic Sans MS" OnItemCommand="DataList1_ItemCommand" RepeatColumns="5" RepeatDirection="Horizontal" Height="305px" Width="839px" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
        <AlternatingItemStyle />
        <ItemTemplate>
            <div class="text-center">
                <br />
                <br />
                <asp:ImageButton ID="ImageButton_pimg" runat="server" Height="60px" ImageUrl='<%#Eval("PImage")%>' Width="60px" />
                <br />
                <br />
                <asp:Label ID="Label_pnm" runat="server" Text='<%#Eval("PName") %>'></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Rs"></asp:Label>
                &nbsp;<asp:Label ID="Label_ppr" runat="server" Text='<%#Eval("PPrice") %>'></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="/-"></asp:Label>
                &nbsp;&nbsp;
                <asp:Button ID="Btn_addtocart" runat="server" Text="Add To Cart" class="btn btn-info" ToolTip='<%#Eval("PID") %>'  CommandName="cmdnm_AddToCart" CommandArgument='<%#Eval("PID")%>'/>
                <br />
                <br />
            </div>
        </ItemTemplate>
    </asp:DataList>
            &nbsp;</td>
        </tr>
    </table>
</asp:Content>

