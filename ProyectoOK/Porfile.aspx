<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="Porfile.aspx.cs" Inherits="ProyectoOK.Porfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link  rel="stylesheet" href="Content/MeStyle.css"/> 

    <div class="container mt-5">

        <div class="row">

         <div class="col-12 text-center mb-4">

    <asp:Label ID="lblUserName" CssClass="h4" runat="server" ></asp:Label>

         </div>

    <asp:Panel ID="showProductImageCover" CssClass="product-container" runat="server"></asp:Panel>

</asp:Content>
