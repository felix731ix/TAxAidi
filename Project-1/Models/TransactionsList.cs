using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Models
{
    public class TransactionsList
    {
        public int? HeaderId { get; set; }
        public DateTime CreatedAt { get; set; }

        public string ShowName { get; set; }

        public DateTime ShowTime { get; set; }
        
        public int? Quantity { get; set; }

        public int TotalPrice { get; set; }

    }
}