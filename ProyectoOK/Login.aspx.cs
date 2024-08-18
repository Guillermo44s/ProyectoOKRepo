using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoOK
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(Membership.ValidateUser(txtUserName.Text,txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text,false);
            }
            lblInvalidCredentialsMessage.Visible = true;
        }
    }
}