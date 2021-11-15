using Project_1.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("HomePage.aspx?id=" + (Request.QueryString["id"]));
            }
            else if (!this.IsPostBack)
            {
                int userId = int.Parse(Request.QueryString["id"]);
                txtName.Text = UserController.getUserName(userId);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            errName.Text = "";
            errOldPassword.Text = "";
            errConfirmPassword.Text = "";

            errName.Text = UserController.checkName(name);
            errOldPassword.Text = UserController.checkOldPassword(oldPassword, int.Parse(Request.QueryString["id"]));
            errConfirmPassword.Text = UserController.checkConfirmPassword(newPassword, confirmPassword);



            if (UserController.updateValidation(errName.Text, errOldPassword.Text, errConfirmPassword.Text) == true)
            {
                UserController.UpdateDataUser(int.Parse(Request.QueryString["id"]), name, newPassword);
                Response.Redirect("HomePage.aspx?id=" + int.Parse(Request.QueryString["id"]));
            }
        }
    }
}