using Project_1.Controller;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class TransactionsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["id"]) == null || UserController.getUserRole(int.Parse(Request.QueryString["id"])) != 2)
            {
                Response.Redirect("HomePage.aspx?id=" + (Request.QueryString["id"]));
            }
            else
            {
                if (!IsPostBack)
                {
                    FillGrid();
                }
            }
            
        }

        protected void FillGrid()
        {
            int userId = int.Parse(Request.QueryString["id"]);
            grdView.DataSource = TransactionController.getAllTransactions(userId);
            grdView.DataBind();
        }


        protected void grdView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdView.Rows)
            {
                if (row.RowIndex == grdView.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    string showName = grdView.SelectedRow.Cells[2].Text;
                    int showId = ShowController.getShowId(showName);
                    string userId = Request.QueryString["id"];
                    //string createdAtTable = grdView.SelectedRow.Cells[1].Text;
                    //DateTime createdAt = DateTime.ParseExact(createdAtTable, "dd/MM/yyyy HH:mm:ss", null);
                    int headerId = int.Parse(grdView.SelectedRow.Cells[0].Text);
                    Response.Redirect("TransactionDetail.aspx?id=" + userId + "&showId=" + showId + "&headerId=" + headerId);
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }           
        }

        protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdView, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.ToolTip = "Click to select this transaction";
            }
        }
    }
}