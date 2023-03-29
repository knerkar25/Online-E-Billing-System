<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Invoice.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" 
    Inherits="Invoice" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <%-- <h1 class="invoice-id" style="text-align: left">INVOICE 
        <asp:Label ID="Lbl_orderno" runat="server" Text="order num"></asp:Label>
    </h1>
    <div class="text-left">Date of Invoice:
        <asp:Label ID="Lbl_date" runat="server" Text="date"></asp:Label>
    </div>--%>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <%--class="text-left"--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:Panel ID="Panel1" runat="server">
  
       <h1 class="invoice-id" style="text-align: left">INVOICE 
        <asp:Label ID="Lbl_orderno" runat="server" Text="order num"></asp:Label>
    </h1>
    <div class="text-left">Date of Invoice :
        <asp:Label ID="Lbl_date" runat="server" Text="date"></asp:Label>
        &nbsp;| Payment Type :&nbsp;
        <asp:Label ID="Lbl_paytyp" runat="server" Text="ptyp"></asp:Label>
    </div>
       <table border="0" cellspacing="0" cellpadding="0">
        <thead>
          <%--  <tr>
                <th class="text-left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PRODUCT&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PRICE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; QUANITIY&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TOTAL</th>
              <th class="text-center">PRICE</th>
                <th class="text-right">QUANTITY</th>
                <th class="text-right">TOTAL</th>
            </tr>--%>
        </thead>
        <tbody>
            <tr class="text-center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="PRODUCT" DataField="PName" SortExpression="PName" HeaderStyle-BackColor="#00ccff" HeaderStyle-ForeColor="#000066" HeaderStyle-Font-Bold="true"/><%--class="text-left"--%>
                        <asp:BoundField HeaderText="PRICE" DataField="PPrice" SortExpression="PPrice" HeaderStyle-BackColor="#00ccff" HeaderStyle-ForeColor="#000066" HeaderStyle-Font-Bold="true"/><%--class="unit"--%>
                        <asp:BoundField HeaderText="QUANTITY" DataField="Quantity" SortExpression="Quantity" HeaderStyle-BackColor="#00ccff" HeaderStyle-ForeColor="#000066" HeaderStyle-Font-Bold="true"/><%-- class="qty"--%>
                        <asp:BoundField HeaderText="PRODUCT TOTAL" DataField="ProductTotal" SortExpression="ProductTotal" HeaderStyle-BackColor="#00ccff" HeaderStyle-ForeColor="#000066" HeaderStyle-Font-Bold="true"/> <%--class="total"--%>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="font-size:large; text-align:right">SUBTOTAL</td>
                <td style="font-size:large; text-align:right">
                    Rs <asp:Label ID="Lbl_total" runat="server" Text="Label"></asp:Label>/-</td>
            </tr>              
        </tbody>
        <tfoot  >
            <tr>              
                <td>     
                    <br />
                    <br />                 
                </td>
                    <td style="font-size:large; text-align:right">&nbsp;</td>
                    <td style="font-size:large; text-align:right">
                        &nbsp;</td>
                </tr>                 
         </tfoot>
    </table>
        <asp:Button runat="server" Text="Export to PDF"  ID="Btn_PDF" class="btn btn-info" OnClick="Btn_PDF_Click"/>
         <asp:Button runat="server" Text="Print" id="Btb_printInvoice" class="btn btn-info" OnClick="Btb_printInvoice_Click" style="height: 46px"/>    
        </asp:Panel>
</asp:Content>

