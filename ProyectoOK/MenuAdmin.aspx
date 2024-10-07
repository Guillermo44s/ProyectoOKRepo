<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="ProyectoOK.MenuAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvProduct" runat="server" DataKeyNames="IdProduct" AutoGenerateColumns="true" CssClass="table"  OnSelectedIndexChanged="dgvProduct_SelectedIndexChanged">

        <Columns>
            <asp:BoundField HeaderText="Product" DataField="Product"/>
            <asp:CommandField  ShowSelectButton="true" HeaderText="Modificar" SelectText="Select"/>
        </Columns>

    </asp:GridView>

    <asp:Button ID="btnGoFormProduct" runat="server" Text="Add" OnClick="btnGoFormProduct_Click" />
</asp:Content>
