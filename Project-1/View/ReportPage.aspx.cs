using Project_1.Controller;
using Project_1.DataSets;
using Project_1.Models;
using Project_1.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_1.View
{
    public partial class ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["id"]) == null || UserController.getUserRole(int.Parse(Request.QueryString["id"])) != 1)
            {
                Response.Redirect("HomePage.aspx?id=" + (Request.QueryString["id"]));
            }
            else
            {
                TransactionsReport tr = new TransactionsReport();
                reportViewTransaction.ReportSource = tr;
                tr.SetDataSource(GetData());
            }
        }

        protected DataSetTAxAidi GetData()
        {
            List<TransactionHeader> listHeader = TransactionController.getHeaderList(int.Parse(Request.QueryString["id"]));
            DataSetTAxAidi ds = new DataSetTAxAidi();
            var ds_header = ds.TransactionHeader;
            var ds_detail = ds.TransactionDetail;

            foreach(var header in listHeader)
            {
                var newRow = ds_header.NewRow();
                newRow["Id"] = header.Id;
                newRow["BuyerId"] = header.BuyerId;
                newRow["PaymentDate"] = header.CreatedAt;
                newRow["ShowTime"] = header.ShowTime;
                newRow["ShowId"] = header.ShowId;
                newRow["BuyerName"] = UserController.getUserName(header.BuyerId);
                newRow["Price"] = ShowController.getShowPriceByShowId(header.ShowId);
                newRow["Quantity"] = TransactionController.getTokenListByHeaderId(header.Id).Count();
                newRow["ShowName"] = ShowController.showNameByID(header.ShowId);
                ds_header.Rows.Add(newRow);

                List<Models.TransactionDetail> listDetail = TransactionController.getDetailListByHeaderId(header.Id);
                foreach(var detail in listDetail)
                {
                    var newRowDetail = ds_detail.NewRow();
                    newRowDetail["TransactionId"] = detail.TransactionHeaderId;                  
                    newRowDetail["Token"] = detail.Token;
                    newRowDetail["TokenStatus"] = TransactionController.getTokenStatus(TransactionController.checkTokenUsed(detail.Token));
                    ds_detail.Rows.Add(newRowDetail);
                }
            }
            return ds;
        }
    }
}