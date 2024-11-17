<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="CreateUserAccounts.aspx.cs" Inherits="ProyectoOK.CreateUserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5">

        <div class="row justify-content-center">

             <div class="col-md-6 col-lg-4">

    <h1 class="text-center mb-4">Create User Account </h1>

    <div class="form-group mb-3">
        <asp:Label ID="lblNewUser" runat="server" CssClass="form-label" Text="User"></asp:Label>
        <asp:TextBox ID="txtNewUser" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

      <div class="form-group mb-3">
          <asp:Label ID="lblNewPassword" runat="server" CssClass="form-label" Text="Password"></asp:Label>
          <asp:TextBox ID="txtNewPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
  </div>

      <div class="form-group mb-3">
          <asp:Label ID="lblNewEmail" runat="server" CssClass="form-label" Text="Email"></asp:Label>
          <asp:TextBox ID="txtNewEmail" CssClass="form-control" runat="server"></asp:TextBox>
  </div>

    <div class="text-center mb-3">
        <asp:Button ID="btnCreateUserAccount" runat="server" OnClick="btnCreateUserAccount_Click" Text="Create" />
    </div>


    <div class="text-center">
        <asp:Label ID="lblCreateAccountResults" runat="server" Text=""></asp:Label>
    </div>

                 </div>

            </div>


        </div>









</asp:Content>
