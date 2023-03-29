<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeFile="DemoSales.aspx.cs" Inherits="DemoSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    SALES......
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" CellSpacing="15" Height="221px" OnItemCommand="DataList1_ItemCommand" Width="912px">
        <ItemTemplate>
            <div class="text-center">
                <asp:Image ID="Pimage" runat="server" ImageUrl='<%#Eval("PImage")%>' Height="50px" Width="50px" />
                <br />
                <asp:Label ID="Lbl_Pname" runat="server" Text='<%#Eval("PName")%>'></asp:Label>
                <br />
                Rs
                <asp:Label ID="Lbl_Pprice" runat="server" Text='<%#Eval("PPrice")%>'></asp:Label>
                /-<br />
                <br />
                <asp:Button ID="Btn_add" runat="server" Text="Add To Cart" />
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

