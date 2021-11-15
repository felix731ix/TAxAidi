using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Repository
{
    public class ReviewRepository
    {
        private static DatabaseTAxAidiEntities1 db = new DatabaseTAxAidiEntities1();

        public static List<Review> getAllReviewById(int showId)
        {
            var q = (from review in db.Reviews
                     join td in db.TransactionDetails
                     on review.TransactionDetailId equals td.Id
                     join th in db.TransactionHeaders
                     on td.TransactionHeaderId equals th.Id
                     where th.ShowId == showId
                     orderby review.Rating descending
                     select new
                     {
                         Description = review.Description,
                         Rating = review.Rating
                     }).ToList().Select(x => new Review
                     {
                         Description = x.Description,
                         Rating = x.Rating
                     }).ToList();
            return q;
        }

        public static Review getReviewByToken(string token)
        {
            Review rvw = (from td in db.TransactionDetails
                          join review in db.Reviews on td.Id equals review.TransactionDetailId
                          where token == td.Token
                          select review).FirstOrDefault();
            if (rvw != null)
            {
                return rvw;
            }
            return null;
        }

        public static bool updateReview(Review reviewToUpdate)
        {
            if (reviewToUpdate != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool deleteReview(Review reviewToDelete)
        {
            if (reviewToDelete != null)
            {
                db.Reviews.Remove(reviewToDelete);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static Review getReviewByTdId(int tdId)
        {
            Review rvw = (from td in db.TransactionDetails
                          join review in db.Reviews on td.Id equals review.TransactionDetailId
                          where tdId == td.Id
                          select review).FirstOrDefault();
            if (rvw != null)
            {
                return rvw;
            }
            return null;
        }

        public static bool addReview(Review newReview)
        {
            if (newReview != null)
            {
                db.Reviews.Add(newReview);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}