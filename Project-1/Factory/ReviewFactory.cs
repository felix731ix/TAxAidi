using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Factory
{
    public class ReviewFactory
    {
        public static Review Create(int tdId, int rate, string desc)
        {
            Review newReview = new Review();
            newReview.TransactionDetailId = tdId;
            newReview.Rating = rate;
            newReview.Description = desc;
            return newReview;
        }
    }
}