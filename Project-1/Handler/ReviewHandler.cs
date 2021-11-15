using Project_1.Factory;
using Project_1.Models;
using Project_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Handler
{
    public class ReviewHandler
    {
        public static List<Review> getAllReviewById(int showId)
        {
            return ReviewRepository.getAllReviewById(showId);
        }

        public static bool addReview(int tdId, int rate, string desc)
        {
            Review newReview = ReviewFactory.Create(tdId, rate, desc);
            return ReviewRepository.addReview(newReview);
        }

        public static bool setTokenUsed(string token)
        {
            TransactionDetail td = TransactionDetailRepository.getTdObjByToken(token);

            if (td != null)
            {
                td.StatusId = 2;
                return TransactionDetailRepository.UpdateToken(td);
            }
            return false;
        }

        public static Review getReviewByToken(string token)
        {
            return ReviewRepository.getReviewByToken(token);
        }

        public static bool updateReview(int tdId, int rating, string desc)
        {
            Review reviewToUpdate = ReviewRepository.getReviewByTdId(tdId);

            if (reviewToUpdate != null)
            {
                reviewToUpdate.Rating = rating;
                reviewToUpdate.Description = desc;
                return ReviewRepository.updateReview(reviewToUpdate);
            }
            return false;
        }

        public static bool deleteReview(int tdId, int rating, string desc)
        {
            Review reviewToDelete = ReviewRepository.getReviewByTdId(tdId);

            if (reviewToDelete != null)
            {
                return ReviewRepository.deleteReview(reviewToDelete);
            }
            return false;
        }

        public static bool setTokenNotUsed(string token)
        {
            TransactionDetail td = TransactionDetailRepository.getTdObjByToken(token);

            if (td != null)
            {
                td.StatusId = 1;
                return TransactionDetailRepository.UpdateToken(td);
            }
            return false;
        }
    }
}