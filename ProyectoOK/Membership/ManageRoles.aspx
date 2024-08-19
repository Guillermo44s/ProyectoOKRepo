<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="ProyectoOK.Membership.ManageRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Create new Role</h1>
    <div>
        <asp:Label ID="lblNewRoleName" runat="server" Text="New Role Name"></asp:Label>
    <asp:TextBox ID="txtNewRoleName" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="btnCreateRole" runat="server" Text="Create Role" OnClick="btnCreateRole_Click" />
    </div>

    <div>
        <asp:GridView ID="dgvRoleList" runat="server">
            <Columns>

            </Columns>
        </asp:GridView>
    </div>

    <br />
    <hr />

    <h1>Assign Role</h1>

    <div>
        <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="lblRoleList" runat="server" Text="Role List"></asp:Label>
        <asp:DropDownList ID="ddlRoleList" runat="server"></asp:DropDownList>
    </div>

    <div>
        <asp:Button ID="btnAssignRole" runat="server" Text="Assign Role"  OnClick="btnAssignRole_Click"/>
    </div>

    <div>
        <asp:Label ID="lblResultRoleExist" runat="server" Text="The role does not exist" Visible="false"></asp:Label>
        <asp:Label ID="lblResultIsUserInRole" runat="server" Text="The user already exists in this role." Visible="false"></asp:Label>
    </div>

</asp:Content>
