<%@ Page Title="" Language="C#" MasterPageFile="~/NavBar.Master" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="ProyectoOK.Membership.ManageRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row mt-4"> 
           <div class="col-md-6 offset-md-3">

    <h1>Create new Role</h1>

    <div class="form-group">
        <asp:Label ID="lblNewRoleName" runat="server" CssClass="form-label" Text="New Role Name"></asp:Label>
    <asp:TextBox ID="txtNewRoleName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="text-center mt-3">
        <asp:Button ID="btnCreateRole" runat="server" Text="Create Role" CssClass="btn btn-primary" OnClick="btnCreateRole_Click" />
    </div>

    <div class="mt-5" >
        <h2 class="text-center">Role List</h2>
        <asp:GridView ID="dgvRoleList" runat="server" CssClass="table table-bordered table-striped">
            <Columns>

            </Columns>
        </asp:GridView>
    </div>
          </div>
</div>


    <br />
    <hr />

      <div class="row mt-4">
                <div class="col-md-6 offset-md-3">

    <h1 class="text-center mb-4">Assign Role</h1>

    <div class="form-group mb-3">
        <asp:Label ID="lblUserName" runat="server" CssClass="form-label" Text="User Name"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
    </di>

    <div class="form-group mb-3">
        <asp:Label ID="lblRoleList" runat="server" Text="Role List" CssClass="form-label"></asp:Label>
        <asp:DropDownList ID="ddlRoleList" runat="server" CssClass="form-select"></asp:DropDownList>
    </div>

    <div class="text-center mt-3">
        <asp:Button ID="btnAssignRole" runat="server" Text="Assign Role" CssClass="btn btn-primary"  OnClick="btnAssignRole_Click"/>
    </div>

    <div class="mt-4">
        <asp:Label ID="lblResultRoleExist" runat="server" Text="The role does not exist" Visible="false"  CssClass="text-danger d-block" ></asp:Label>
        <asp:Label ID="lblResultIsUserInRole" runat="server" Text="The user already exists in this role." Visible="false"  CssClass="text-warning d-block" ></asp:Label>
    </div>

        </div>
                    </div>

</asp:Content>
