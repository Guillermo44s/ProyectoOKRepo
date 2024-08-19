<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="UnauthorizedAccess.aspx.cs" Inherits="ProyectoOK.UnauthorizedAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblUnauthorizedAccessMessage" runat="server" Text="You were not allowed to access that page. If you are an administrator, please log in.
If you are an administrator and still cannot access it, please consult." ></asp:Label>
</asp:Content>
