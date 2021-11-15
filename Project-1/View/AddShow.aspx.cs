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
    public partial class AddShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["id"]) == null || UserController.getUserRole(int.Parse(Request.QueryString["id"])) != 1)
            {
                Response.Redirect("HomePage.aspx?id=" + (Request.QueryString["id"]));
            }
        }

        protected void btnAddShows_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string URL = txtUrl.Text;
            string Description = txtDescription.Text;
            int price = int.Parse(txtPrice.Text);

            errName.Text = ShowController.checkShowName(Name);
            errDescription.Text = ShowController.checkDescription(Description);
            errPrice.Text = ShowController.checkPrice(price);

            if(ShowController.addShowValidation(errName.Text, errDescription.Text, errPrice.Text) == true)
            {
                int sellerId= int.Parse(Request.QueryString["id"]); 
                ShowController.insertShow(sellerId,Name, URL, Description, price);
                lblSuccess.Text = "Data Added and Saved";
            }
            
        }
    }
}