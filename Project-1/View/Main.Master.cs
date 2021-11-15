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
    public partial class Main : System.Web.UI.MasterPage
    {
        int globalUserId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Non=-logged in user
            btnHome.Visible = true;
            btnRedeemToken.Visible = true;
            userName.Text = "Guest";

            if (Session["user"] == null)
            {
                btnLogin.Visible = true;
                btnRegister.Visible = true;
            }
            //Logged User
            else
            { 
                int userId = int.Parse(Request.QueryString["id"]);
                globalUserId = userId;
                int roleId = UserController.getUserRole(userId);
                btnLogout.Visible = true;
                btnAccount.Visible = true;
                userName.Text = UserController.getUserName(userId);
                //Seller
                if (roleId == 1)
                {
                    btnAddShows.Visible = true;
                    btnReports.Visible = true;
                }
                //Buyer
                else
                {
                    btnTransactions.Visible = true;
                }

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnAddShows_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddShow.aspx?id="+globalUserId);
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx?id="+globalUserId);
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfilePage.aspx?id="+globalUserId);
        }

        protected void btnTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionsPage.aspx?id=" + globalUserId);
        }

        protected void btnRedeemToken_Click(object sender, EventArgs e)
        {
            Response.Redirect("RedeemToken.aspx?id=" + globalUserId);
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            Response.Redirect("HomePage.aspx?id=" + globalUserId + "&search=" + search);          
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session.Abandon();
            if(Request.Cookies["cookies"] != null){
                HttpCookie cookie = new HttpCookie("cookies");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                
            }
            Response.Redirect("HomePage.aspx");
        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportPage.aspx?id=" + globalUserId);
        }
    }
}