using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoOK
{
    public partial class CreateUserAccounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUserAccount_Click(object sender, EventArgs e)
        {
          MembershipCreateStatus memberCreateStatus;
            MembershipUser newUser = Membership.CreateUser(txtNewUser.Text,txtNewPassword.Text,txtNewEmail.Text,null,null,true,
                out memberCreateStatus);

            switch (memberCreateStatus)
            {
                case MembershipCreateStatus.Success:
                    lblCreateAccountResults.Text = "The user account was successfully created!";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    lblCreateAccountResults.Text = "There already exists a user with this username.";
                    break;

                case MembershipCreateStatus.DuplicateEmail:
                    lblCreateAccountResults.Text = "There already exists a user with this email address.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    lblCreateAccountResults.Text = "There email address you provided in invalid.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    lblCreateAccountResults.Text = "There security answer was invalid.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    lblCreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";

                    break;
                default:
                    lblCreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }

        }
    }
}