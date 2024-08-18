<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="CreateUserAccounts.aspx.cs" Inherits="ProyectoOK.CreateUserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Create User Account </h1>

    <div>
        <asp:Label ID="lblNewUser" runat="server" Text="User"></asp:Label>
        <asp:TextBox ID="txtNewUser" runat="server"></asp:TextBox>
    </div>

      <div>
          <asp:Label ID="lblNewPassword" runat="server" Text="Password"></asp:Label>
          <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
  </div>

      <div>
          <asp:Label ID="lblNewEmail" runat="server" Text="Email"></asp:Label>
          <asp:TextBox ID="txtNewEmail" runat="server"></asp:TextBox>
  </div>

    <div>
        <asp:Button ID="btnCreateUserAccount" runat="server" OnClick="btnCreateUserAccount_Click" Text="Create" />
    </div>

    <div>
        <asp:Label ID="lblCreateAccountResults" runat="server" Text="Label"></asp:Label>
    </div>

</asp:Content>
