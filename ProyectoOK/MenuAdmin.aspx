<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="ProyectoOK.MenuAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5">

         <div class="card shadow">

            <h3 class="mb-0">Products</h3>

         </div>

        <div class="card-body">

    <asp:GridView ID="dgvProduct" runat="server" DataKeyNames="IdProduct" AutoGenerateColumns="true" CssClass="table"  OnSelectedIndexChanged="dgvProduct_SelectedIndexChanged">

        <Columns>
            <asp:BoundField HeaderText="Product" DataField="Product"/>
            <asp:CommandField  ShowSelectButton="true" HeaderText="Modificar" SelectText="Select"/>
        </Columns>

    </asp:GridView>


            <div class="d-flex justify-content-end mt-3">

    <asp:Button ID="btnGoFormProduct" runat="server" Text="Add" OnClick="btnGoFormProduct_Click" CssClass="btn btn-primary" />
                </div>

        </div>


        </div>

    <div class="text-center mt-4">
        <a href="/Membership/ManageRoles.aspx" class="btn btn-outline-primary custom-link-button" > Go Mange Role</a>
    </div>

</asp:Content>
