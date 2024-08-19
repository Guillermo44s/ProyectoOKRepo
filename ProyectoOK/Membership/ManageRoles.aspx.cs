using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoOK.Membership
{
    public partial class ManageRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
             DisplayRoleInGrid();
             DisplayRoleInDropDownList();
            }
        }

        protected void btnCreateRole_Click(object sender, EventArgs e)
        {
            string newRole = txtNewRoleName.Text.Trim();

            if(!Roles.RoleExists(newRole))
            {
                Roles.CreateRole(newRole);
            }
            txtNewRoleName.Text = string.Empty;
            DisplayRoleInGrid();
        }

        public void DisplayRoleInGrid()
        {
            dgvRoleList.DataSource = Roles.GetAllRoles();
            dgvRoleList.DataBind();
        }

        public void DisplayRoleInDropDownList()
        {
            ddlRoleList.DataSource = Roles.GetAllRoles();
            ddlRoleList.DataBind();
        }

        protected void btnAssignRole_Click(object sender, EventArgs e)
        {
            if (!Roles.RoleExists(ddlRoleList.SelectedItem.Text))
            {
                lblResultRoleExist.Visible = true;
            }
            if(!Roles.IsUserInRole(txtUserName.Text,ddlRoleList.SelectedItem.Text))
            {
            Roles.AddUserToRole(txtUserName.Text, ddlRoleList.SelectedItem.Text);          
            }
            else
            {
                lblResultIsUserInRole.Visible = true;
            }
        }
    }
}