using Project_1.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if ((Request.QueryString["id"]) == null || UserController.getUserRole(int.Parse(Request.QueryString["id"])) != 2)
            {
                Response.Redirect("HomePage.aspx?id=" + (Request.QueryString["id"]));
            }
            else
            {
                int userId = int.Parse(Request.QueryString["id"]);
                int roleId = UserController.getUserRole(userId);
                int showId = int.Parse(Request.QueryString["showId"]);
                int headerId = int.Parse(Request.QueryString["headerId"]);
                int transactionBuyer = TransactionController.getHeaderBuyerByID(headerId);
                //Buyer
                if (roleId == 1 || headerId == -1 || (transactionBuyer != userId))
                {
                    Response.Redirect("HomePage.aspx?id=" + userId);
                }
                else
                {
                    //Isi Detail Film Dipilih
                    fillShowDetail(showId);
                    //Isi Review
                    fillGrid(headerId);
                }
            }          
        }

        protected void fillShowDetail(int showId)
        {
            showName.Text = ShowController.showNameByID(showId);
            showDesc.Text = ShowController.showDescByID(showId);
            showAvg.Text = ShowController.showAvgByID(showId).ToString();
        }

        protected void fillGrid(int headerId)
        {
            grdView.DataSource = TransactionController.getTokenListByHeaderId(headerId);
            grdView.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            int headerId = int.Parse(Request.QueryString["headerId"]);

            if (TransactionController.isCancelValid(headerId) == true)
            {
                if(TransactionController.cancelTransaction(headerId) == true)
                {
                    errCancel.Text = "Your transaction is canceled";
                }
                else
                {
                    errCancel.Text = "Your transaction cancelation is failed";
                }
            }
            else
            {
                errCancel.Text = "Your transaction cannot be canceled";
            }

        }
    }
}