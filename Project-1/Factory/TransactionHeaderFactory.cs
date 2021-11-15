using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Factory
{
    public class TransactionHeaderFactory
    { 
        public static TransactionHeader CreateHeader(int buyerId, int showId, DateTime showTime, DateTime createdAt)
        {
            TransactionHeader th = new TransactionHeader();
            th.BuyerId = buyerId;
            th.ShowId = showId;
            th.ShowTime = showTime;
            th.CreatedAt = DateTime.Now;
            return th;
        }
    }
}