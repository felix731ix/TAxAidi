using Project_1.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class UpdateShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["id"]) == null || UserController.getUserRole(int.Parse(Request.QueryString["id"])) != 1)
            {
                Response.Redirect("HomePage.aspx?id=" + (Request.QueryString["id"]));
            }
            else if (!this.IsPostBack)
            {
                int showId = int.Parse(Request.QueryString["showId"]);
                string showSellerName = ShowController.showSellerByID(showId);
                string userName = UserController.getUserName(int.Parse(Request.QueryString["id"]));
                if (userName != showSellerName)
                {
                    Response.Redirect("HomePage.aspx?id=" + (Request.QueryString["id"]));
                }
                else
                {
                    txtName.Text = ShowController.showNameByID(showId);
                    txtUrl.Text = ShowController.showUrlByID(showId);
                    txtDescription.Text = ShowController.showDescByID(showId);
                    txtPrice.Text = ShowController.showPriceByID(showId).ToString();
                }            
            }
        }

        protected void btnUpdateShow_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string URL = txtUrl.Text;
            string Description = txtDescription.Text;
            int price = int.Parse(txtPrice.Text);
            int showId = int.Parse(Request.QueryString["showId"]);
            //check update show name beda sama check name buat add show
            errName.Text = ShowController.checkUpdateShowName(Name, showId);
            errDescription.Text = ShowController.checkDescription(Description);
            errPrice.Text = ShowController.checkPrice(price);

            if (ShowController.addShowValidation(errName.Text, errDescription.Text, errPrice.Text) == true)
            {
                ShowController.updateShow(showId, Name, URL, Description, price);
                lblSuccess.Text = "Data Updated and Saved";
                Response.Redirect("HomePage.aspx?id=" + int.Parse(Request.QueryString["id"]));
            }
        }
    }
}