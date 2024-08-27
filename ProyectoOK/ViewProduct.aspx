<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="ProyectoOK.ViewProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>View Product</h1>
    <br />
    <div>
        <asp:Label ID="lblProduct" runat="server" ></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblDescription" runat="server"></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblPrice" runat="server"></asp:Label>
    </div>

    <div>
    <asp:Panel ID="panelShowImageCover" runat="server"></asp:Panel>
    </div>

    <div>
        <asp:Panel ID="panelShowTheImagePorduct" runat="server"></asp:Panel>
    </div>


    <asp:LoginView ID="LoginView1" runat="server">
<LoggedInTemplate>
    <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart" OnClick="btnAddToCart_Click" />
</LoggedInTemplate>
    </asp:LoginView>

</asp:Content>
