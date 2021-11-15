using Project_1.Controller;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;

namespace Project_1.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["search"] != null)
            {
                string search = Request.QueryString["search"];
                grdView.DataSource = ShowController.searchShows(search);
                grdView.DataBind();
            }
            else
            {
                fillGrid();
            }
        }

        protected void fillGrid()
        {
            grdView.DataSource = ShowController.getAllShows();
            grdView.DataBind();
        }

        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "showDetail")
            {
                int row;
                row = Convert.ToInt32(e.CommandArgument.ToString());
                string showTitle = grdView.Rows[row].Cells[0].Text;
                int showId = ShowController.getShowId(showTitle);
                Response.Redirect("ShowDetailPage.aspx?showId=" + showId + "&" + "id=" + Request.QueryString["id"]);
            }
        }     
    }
}