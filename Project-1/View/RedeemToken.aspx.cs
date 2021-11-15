using Project_1.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class RedeemToken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRedeem_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text;
            int showId = ShowController.getShowIdbyToken(token);
            //kalau token udah pernah dipake, dan udah lewat jam tayang

            if (TransactionController.checkTokenUsed(token) == true && TransactionController.isPastShowTime(token) == true)
            {
                Response.Redirect("ReviewPage.aspx?id=" + Request.QueryString["id"] + "&showId=" + showId + "&token=" + token);
            }
            //kalo belum kepake, cek dulu jamnya bukan?
            else if (TransactionController.isShowTimeNow(token) == true)
            {
                //Open review and Show URL
                string url = ShowController.getShowURLByToken(token);
                Response.Redirect("ReviewPage.aspx?id=" + Request.QueryString["id"]  + "&url=" + url + "&showId=" + showId + "&token=" + token);
            }
            //kalo token salah atau bukan jam nntonnya maka
            else
            {
                errToken.Text = "Token is invalid or it's not on the show time";
            }
        }
    }
}