<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoOK.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login</h1>

    <div>
        <asp:Label ID="lblUserName" runat="server" Text="User"></asp:Label>
<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </div>

      <div>
          <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
          <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
  </div>

    <div>
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text ="Login" />
    </div>

    <div>
        <asp:Label ID="lblInvalidCredentialsMessage" Visible="false" runat="server" ></asp:Label>
    </div>

</asp:Content>
