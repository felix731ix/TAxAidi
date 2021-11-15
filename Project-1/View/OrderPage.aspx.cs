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
    public partial class OrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["id"]) == null || UserController.getUserRole(int.Parse(Request.QueryString["id"])) != 2)
            {
                Response.Redirect("HomePage.aspx?id=" + (Request.QueryString["id"]));
            }
            else
            {
                if (DatePick.SelectedDate == DateTime.MinValue)
                {
                    DatePick.SelectedDate = DateTime.Today;
                }
                FillGrid();
                fillShowDetail(int.Parse(Request.QueryString["showId"]));
            }          
        }

        private static List<ShowTime> fillShowTime()
        {
            List<ShowTime> dt = new List<ShowTime>();
            dt.Add(new ShowTime { startShow = "00:00" });
            dt.Add(new ShowTime { startShow = "01:00" });
            dt.Add(new ShowTime { startShow = "02:00" });
            dt.Add(new ShowTime { startShow = "03:00" });
            dt.Add(new ShowTime { startShow = "04:00" });
            dt.Add(new ShowTime { startShow = "05:00" });
            dt.Add(new ShowTime { startShow = "06:00" });
            dt.Add(new ShowTime { startShow = "07:00" });
            dt.Add(new ShowTime { startShow = "08:00" });
            dt.Add(new ShowTime { startShow = "09:00" });
            dt.Add(new ShowTime { startShow = "10:00" });
            dt.Add(new ShowTime { startShow = "11:00" });
            dt.Add(new ShowTime { startShow = "12:00" });
            dt.Add(new ShowTime { startShow = "13:00" });
            dt.Add(new ShowTime { startShow = "14:00" });
            dt.Add(new ShowTime { startShow = "15:00" });
            dt.Add(new ShowTime { startShow = "16:00" });
            dt.Add(new ShowTime { startShow = "17:00" });
            dt.Add(new ShowTime { startShow = "18:00" });
            dt.Add(new ShowTime { startShow = "19:00" });
            dt.Add(new ShowTime { startShow = "20:00" });
            dt.Add(new ShowTime { startShow = "21:00" });
            dt.Add(new ShowTime { startShow = "22:00" });
            dt.Add(new ShowTime { startShow = "23:00" });
            return dt;
        }

        protected void fillShowDetail(int showId)
        {
            showName.Text = ShowController.showNameByID(showId);
            showPrice.Text = ShowController.showPriceByID(showId).ToString();
            showSeller.Text = ShowController.showSellerByID(showId);
            showDesc.Text = ShowController.showDescByID(showId);
            showAvg.Text = ShowController.showAvgByID(showId).ToString();
        }

        protected bool refreshOrderButton(string dateAndTime)
        {
            DateTime show;
            bool result = DateTime.TryParse(dateAndTime, out show);
            if (show < DateTime.Now)
            {
                return false;
            }
            else if ((ShowController.checkIfBought(show, int.Parse((Request.QueryString["id"])), int.Parse(Request.QueryString["showId"])) == true))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //protected bool refreshOrderButton(string dateAndTime)
        //{
        //    DateTime show;
        //    bool result = DateTime.TryParse(dateAndTime, out show);
        //    if (show < DateTime.Now)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        protected void FillGrid()
        {
            grdView.DataSource = fillShowTime();
            grdView.DataBind();
        }

        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "order")
            {
                string strQty = txtQty.Text;
                errQty.Text = "";
                errQty.Text = ShowController.checkQty(strQty);
                int row;
                row = Convert.ToInt32(e.CommandArgument.ToString());
                string showTime = grdView.Rows[row].Cells[0].Text;
                string date = DatePick.SelectedDate.ToString("dd/MM/yyyy");
                string dateAndTime = date + " " + showTime;
                if (ShowController.orderValidation(errQty.Text) == true)
                {

                    //Pas klik order button ngapain
                    //Ambil tanggal show nya pake "dateAndTime" yang ada di line 94 (itu udah di format dd/MM/yyyy HH:mm

                    DateTime dateTime = DateTime.Parse(dateAndTime);
                    int buyerId = int.Parse(Request.QueryString["id"]);
                    int showId = int.Parse(Request.QueryString["showId"]);
                    DateTime createdAt = DateTime.Now;

                    //int headerId = int.Parse(Request.QueryString["id"]);
                    //int statusId = 1;
                    //string token = TransactionController.CreateToken();
                    //TransactionController.insertTransactionDetail(headerId, statusId, token);

                    if (TransactionController.insertTransactionHeader(buyerId, showId, dateTime, createdAt, int.Parse(txtQty.Text)) == true)
                    {
                        lblSuccess.Text = "Data Added and Saved";   
                    }
                    else
                    {
                        lblSuccess.Text = "Failed to order!";
                    }

                    Response.Redirect("TransactionsPage.aspx?&id=" + (Request.QueryString["id"]));


                }
            }
        }

        protected void grdView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string showTime = e.Row.Cells[0].Text;
                string date = DatePick.SelectedDate.ToString("dd/MM/yyyy");
                string dateAndTime = date + " " + showTime;
                if (refreshOrderButton(dateAndTime) == false)
                {
                    //Button btnUnavailable = (Button)e.Row.FindControl("btnUnavailable1");
                    //btnUnavailable.Visible = true;
                    //Button btnOrder = (Button)e.Row.FindControl("btnOrder1");
                    //btnOrder.Visible = false;
                    Button bf = (Button)e.Row.Cells[1].Controls[0];
                    bf.Text = "Unavailable";
                    bf.BackColor = System.Drawing.Color.FromArgb(255, 223, 223, 223);
                    bf.ForeColor = System.Drawing.Color.FromArgb(255, 174, 181, 189);
                    bf.Enabled = false;
                }
            }
        }
    }
}