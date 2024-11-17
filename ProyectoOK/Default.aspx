<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoOK.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="Content/MeStyle.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div class="row">

    <asp:Panel ID="showAvailableProduct" CssClass="product-container"  runat="server" > </asp:Panel>
    </div>


     
</asp:Content>
