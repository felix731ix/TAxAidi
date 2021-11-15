using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Factory
{
    public class ShowFactory
    {
        public static Show Create(int sellerId,string name, string url, string description, int price)
        {
            Show newShow = new Show();
            newShow.SellerId = sellerId;
            newShow.Title = name;
            newShow.URL = url;
            newShow.Description = description;
            newShow.Price = price;
            return newShow;
        }
    }
}