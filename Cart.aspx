<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Admin.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Shopping Bag
    <asp:Image ID="Image2" runat="server" Height="30px" ImageUrl="~/Image/bag-of-groceries.png" Width="25px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <table class="nav-justified">
        <tr>
            <td class="text-center" style="width: 566px">
   
                &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PID" Height="300px" 
                    style="margin-left: 3px" Width="600px" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" 
                    ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" PageSize="5" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>                                            
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl='<% # Eval("PImage") %>' Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:BoundField DataField="PCode" HeaderText="ItemCode" SortExpression="PCode" />
                        <asp:BoundField DataField="PName" HeaderText="Product Name" SortExpression="PName" />
                        <asp:BoundField DataField="PPrice" HeaderText="Product Price" SortExpression="PPrice" />  
                        <asp:TemplateField HeaderText="Qty">
                            <ItemTemplate>
                                <asp:TextBox ID="txtbox_qty" runat="server" Font-Names="Comic Sans MS" TextMode="Number" Width="70px">1</asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>                                       
                      <%--  <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                               <asp:ImageButton ID="ImgBtn_minus" runat="server" Height="10px" OnClientClick="return subtractone(this);" ImageUrl="~/Image/minus.png" OnClick="ImgBtn_minus_Click" CommandName="minus" />
                                &nbsp;<asp:Label ID="lbl_qty" runat="server" Text="1"></asp:Label><%--'<%#Eval("Quantity") %>'
                                &nbsp;<asp:ImageButton ID="ImgBtn_plus" runat="server" Height="10px" OnClientClick="return addone(this);" ImageUrl="~/Image/blue_plus.png" OnClick="ImgBtn_plus_Click" CommandName="plus" />
                                
                                
                                <script>
                                    function subtractone(obj) {
                                        var count = $(obj).parent().find("span[id*='lbl_qty']").text();
                                    //alert(count);
                                    var newcount = parseFloat(count) - 1;
                                    $(obj).parent().find("span[id*='lbl_qty']").text(newcount);
                                    return false;   
                                    }

                                    function addone(obj) {
                                        var count = $(obj).parent().find("span[id*='lbl_qty']").text();
                                    //alert(count);
                                    var newcount = parseFloat(count) + 1;
                                    $(obj).parent().find("span[id*='lbl_qty']").text(newcount);
                                    return false;
                                    }
                            </script>

                                <br />

                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" ImageUrl="~/Image/remove.png" 
                                    Width="20px" CommandName="del" CommandArgument='<% # Eval("PID") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PID" HeaderText="Product ID" SortExpression="PID" />
                        <asp:BoundField DataField="User_ID" HeaderText="User ID" SortExpression="User_ID"  />
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
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="width: 566px">&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" style="width: 566px">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Height="16px" Width="551px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Card</asp:ListItem>
                </asp:RadioButtonList>
                
                <asp:Button ID="btn_continue" runat="server" Text="Shop More" CssClass="btn btn-info" OnClick="btn_continue_Click"/>
                &nbsp;
                <asp:Button ID="btn_checkout" runat="server" Text="Place Order" class="btn btn-success" OnClick="btn_checkout_Click"/>
                &nbsp;
          
                <asp:Image ID="img_success" runat="server" ImageUrl="~/Image/tick2.png" Width="25px" Visible="False" />
                <asp:Label ID="Lbl_status" runat="server" Text="Label" Visible="False"></asp:Label>

                &nbsp;<br />
                <br />
    <asp:Label ID="totaltag" runat="server" Text="Grand Total: Rs" Visible="False"></asp:Label>
    <asp:Label ID="lbl_total" runat="server"></asp:Label>
    &nbsp;
    <asp:HiddenField ID="lbl_todaysdate" runat="server" />
            </td>
    </tr>       
        <tr>
            <td class="text-center" style="width: 566px">
                &nbsp;</td>
    </tr>       
    </table>
    <br />
</asp:Content>

