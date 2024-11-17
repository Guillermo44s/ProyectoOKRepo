<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoOK.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container d-flex justify-content-center align-items-center" style="min-height: 100vh;">

 <div class="card p-4" style="max-width: 400px; width: 100%;">

    <h1 class="text-center mb-4" >Login</h1>

    <div class="mb-3">
        <asp:Label ID="lblUserName" CssClass="form-label" runat="server" Text="User"></asp:Label>
<asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

      <div class="mb-3">
          <asp:Label ID="lblPassword" CssClass="form-label"  runat="server" Text="Password"></asp:Label>
          <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
  </div>

    <div class="mb-3">
        <asp:Button ID="btnLogin" runat="server"  CssClass="btn btn-primary" OnClick="btnLogin_Click" Text ="Login" />
    </div>


    <div class="text-center">
        <asp:Label ID="lblInvalidCredentialsMessage" Visible="false" runat="server" >User does not exist.</asp:Label>
    </div>

     </div>

        </div>






</asp:Content>
