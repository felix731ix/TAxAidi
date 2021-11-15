using Project_1.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("HomePage.aspx?id=" + Request.QueryString["id"]);
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            int roleId = UserController.rolesConverter(txtRoles.Text);

            //errName.Text = "";
            errUsername.Text = "";
            errPassword.Text = "";
            errConfirmPassword.Text = "";

            errName.Text = UserController.checkName(name);
            errUsername.Text = UserController.checkUsername(username);
            errPassword.Text = UserController.checkPassword(password);
            errConfirmPassword.Text = UserController.checkConfirmPassword(password, confirmPassword);



            if (UserController.registrationValidation(errName.Text, errUsername.Text, errPassword.Text, errConfirmPassword.Text) == true)
            {
                UserController.addData(name, username, password, roleId);
                Response.Redirect("LoginPage.aspx");
            }

        }
    }
}