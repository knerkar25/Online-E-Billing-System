<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_Login.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="input-group form-group">
        <div class="input-group-prepend">
            <span class="input-group-text"><i class="fas fa-user"></i></span>
         </div>        
            <asp:TextBox ID="TextBox1_usernm" runat="server" type="text" class="form-control" placeholder="username" OnTextChanged="TextBox1_usernm_TextChanged"></asp:TextBox>        
    </div>
    
    <div class="input-group form-group">
        <div class="input-group-prepend">
            <span class="input-group-text"><i class="fas fa-key"></i></span>
        </div>
        <asp:TextBox ID="TextBox2_upwd" runat="server" type="password" class="form-control" placeholder="password"></asp:TextBox>
        
    </div>
    <div class="row align-items-center remember">
        <asp:CheckBox ID="CheckBox1" runat="server" text="Remember Me"/>
    </div>
    <div class="form-group">
        <asp:Button ID="Button1" runat="server" Text="Login" class="btn float-right login_btn" OnClick="Button1_Click"/>
    </div>
</asp:Content>

