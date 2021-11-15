using Project_1.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["cookies"] != null)
            {
                int userId = -1;
                if (Session["user"] == null)
                {
                    userId = int.Parse(Request.Cookies["cookies"].Value);
                    Session["user"] = userId;
                }
                Response.Redirect("HomePage.aspx?id=" + userId);
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string response = UserController.checkLogin(username, password);
            errUsername.Text = UserController.checkUsernameLogin(username);
            errPassword.Text = UserController.checkPasswordLogin(password);

            if (UserController.loginValidation(errUsername.Text, errPassword.Text) == true)
            {
                if (response == "")
                {
                    int userId = UserController.getUserId(username, password);
                    Session["user"] = userId;
                    if (checkRememberMe.Checked)
                    {
                        HttpCookie newCookie = new HttpCookie("cookies");
                        newCookie.Value = userId.ToString();
                        newCookie.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Add(newCookie);

                    }
                    Response.Redirect("HomePage.aspx?id=" + userId);
                }

                else
                    lblError.Text = response;
            }

        }
    }
}