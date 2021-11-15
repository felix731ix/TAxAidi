using Project_1.Controller;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class ReviewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["url"] != null)
                {
                    string url = Request.QueryString["url"];
                    Page.ClientScript.RegisterStartupScript(
                    this.GetType(), "OpenWindow", "window.open('" + url + "','_newtab');", true);
                }

                string token = Request.QueryString["token"];
                int showId = int.Parse(Request.QueryString["showId"]);
                fillShowDetail(showId);


                //setting button berdasarkan token
                if (TransactionController.checkTokenUsed(token) == true)
                {
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    Review review = ReviewController.getReviewByToken(token);
                    if (review != null)
                    {
                        txtRate.Text = review.Rating.ToString();
                        txtDescRate.Text = review.Description;
                    }
                    
                }
                else
                {
                    btnRate.Visible = true;
                }

            }

        }

        protected void checkValidation()
        {
            string rate = txtRate.Text;
            string desc = txtDescRate.Text;

            errRate.Text = "";
            errDescRate.Text = "";

            errRate.Text = ReviewController.checkRate(rate);
            errDescRate.Text = ReviewController.chekDescRate(desc);
        }


        protected void fillShowDetail(int showId)
        {
            showName.Text = ShowController.showNameByID(showId);
            showSeller.Text = ShowController.showSellerByID(showId);
            showDesc.Text = ShowController.showDescByID(showId);
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {
            checkValidation();
            string token = Request.QueryString["token"];
            int showId = int.Parse(Request.QueryString["showId"]);
            int tdId = TransactionController.getTdIdByToken(token);
            if (ReviewController.checkInputValidation(errRate.Text, errDescRate.Text) == true)
            {
                if ((ReviewController.addReview(tdId, int.Parse(txtRate.Text), txtDescRate.Text)) == true)
                {
                    if (ReviewController.setTokenUsed(token) == true)
                    {
                        reviewConfirm.Text = "Your review has been submitted!";
                        Response.Redirect("ShowDetailPage.aspx?showId=" + showId + "&id=" + Request.QueryString["id"]);
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int rating = int.Parse(txtRate.Text);
            string desc = txtDescRate.Text;
            checkValidation();
            string token = Request.QueryString["token"];
            int tdId = TransactionController.getTdIdByToken(token);
            int showId = int.Parse(Request.QueryString["showId"]);
            if (ReviewController.checkInputValidation(errRate.Text, errDescRate.Text) == true)
            {               
                if ((ReviewController.updateReview(tdId, rating, desc)) == true)
                {
                    reviewConfirm.Text = "Your review has been updated!";
                    Response.Redirect("ShowDetailPage.aspx?showId=" + showId + "&id=" + Request.QueryString["id"]);
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            checkValidation();
            string token = Request.QueryString["token"];
            int tdId = TransactionController.getTdIdByToken(token);
            int showId = int.Parse(Request.QueryString["showId"]);
            if (ReviewController.checkInputValidation(errRate.Text, errDescRate.Text) == true)
            {
                if ((ReviewController.deleteReview(tdId, int.Parse(txtRate.Text), txtDescRate.Text)) == true)
                {
                    reviewConfirm.Text = "Your review has been deleted!";
                    ReviewController.setTokenNotUsed(token);
                    Response.Redirect("ShowDetailPage.aspx?showId=" + showId + "&id=" + Request.QueryString["id"]);
                }
            }
        }
    }
}