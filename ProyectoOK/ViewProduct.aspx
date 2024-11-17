<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="ProyectoOK.ViewProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5"> <!-- contenedor -->
    <h1  class="text-center mb-4">View Product</h1>

         <div class="row">

    <div class="col-12 mb-3">
        <asp:Label ID="lblProduct"  CssClass="fw-bold fs-5 d-block" runat="server" ></asp:Label>
    </div>

    <div class="col-12 mb-3">
        <asp:Label ID="lblDescription" CssClass="text-muted" runat="server"></asp:Label>
    </div>

    <div class="col-12 mb-3">
        <asp:Label ID="lblPrice" CssClass="fw-bold fs-4 text-primary" runat="server"></asp:Label>
    </div>

             </div>

        <div class="row mb-4">

    <div class="col-12 text-center">

    <asp:Panel ID="panelShowImageCover" CssClass="border rounded shadow-sm p-3 bg-light" runat="server"></asp:Panel>

    </div>

            </div>


        <div class="row mb-4">

             <div class="col-12">

        <asp:Panel ID="panelShowTheImagePorduct" CssClass="d-flex flex-wrap gap-2" runat="server"></asp:Panel>


                 </div>


            </div>


        <div class="row">

            <div class="col-12 text-center">

    <asp:LoginView ID="LoginView1" runat="server">
<LoggedInTemplate>
    <asp:Button ID="btnAddToCart" runat="server" CssClass="btn btn-success px-4 py-2" Text="Add To Cart" OnClick="btnAddToCart_Click" />
</LoggedInTemplate>
    </asp:LoginView>

                </div>

            </div>


        </div> <!-- fin del contenedor -->

</asp:Content>
