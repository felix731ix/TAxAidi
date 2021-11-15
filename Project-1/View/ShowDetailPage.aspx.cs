using Project_1.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class ShowDetailPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int showId = int.Parse(Request.QueryString["showId"]);
            if (Session["user"] != null)
            {
                int userId = int.Parse(Request.QueryString["id"]);
                int roleId = UserController.getUserRole(userId);
                //Seller
                if (roleId == 1 && userId == ShowController.getSellerByShowId(showId))
                {
                    btnUpdate.Visible = true;
                }
                //Buyer
                else if (roleId == 2)
                {
                    btnOrder.Visible = true;
                }
            }
            //Isi Detail Film Dipilih
            fillShowDetail(showId);
            //Isi Review
            fillGrid();
        }

        protected void fillShowDetail(int showId)
        {
            showName.Text = ShowController.showNameByID(showId);
            showPrice.Text = ShowController.showPriceByID(showId).ToString();
            showSeller.Text = ShowController.showSellerByID(showId);
            showDesc.Text = ShowController.showDescByID(showId);
            showAvg.Text = ShowController.showAvgByID(showId).ToString();
        }


        protected void fillGrid()
        {
            grdView.DataSource = ReviewController.getAllReviewById(int.Parse(Request.QueryString["showId"]));
            grdView.DataBind();
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateShowPage.aspx?showId=" + Request.QueryString["showId"] + "&id=" + int.Parse(Request.QueryString["id"]));
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx?showId=" + Request.QueryString["showId"] + "&id=" + int.Parse(Request.QueryString["id"]));
        }
    }
}