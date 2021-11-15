using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateDetail(int headerId, int statusId, string token)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionHeaderId = headerId;
            td.StatusId = statusId;
            td.Token = token;
            return td;
        }
    }
}