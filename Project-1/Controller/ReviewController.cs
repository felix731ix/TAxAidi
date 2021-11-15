using Project_1.Handler;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Controller
{
    public class ReviewController
    {
        public static List<Review> getAllReviewById(int showId)
        {
            return ReviewHandler.getAllReviewById(showId);
        }

        public static string checkRate(string rate)
        {
            int intRate;
            string response = "";
            if (int.TryParse(rate, out intRate) == true)
            {
                if (intRate < 1 || intRate > 5)
                {
                    response = "Must be numeric and at least 1 and at most 5";
                }
            }
            else
            {
                response = "Must be numeric and at least 1 and at most 5";
            }
            return response;
        }

        public static string chekDescRate(string desc)
        {
            if (desc == "")
            {
                return "Must be filled";
            }
            return "";
        }

        public static Review getReviewByToken(string token)
        {
            return ReviewHandler.getReviewByToken(token);
        }

        public static bool checkInputValidation(string errRate, string errDescRate)
        {
            if (errRate == "" && errDescRate == "")
            {
                return true;
            }
            return false;
        }

        public static bool addReview(int tdId, int rate, string desc)
        {
            return ReviewHandler.addReview(tdId, rate, desc);
        }

        public static bool setTokenUsed(string token)
        {
            return ReviewHandler.setTokenUsed(token);
        }

        public static bool updateReview(int tdId, int rating, string desc)
        {
            return ReviewHandler.updateReview(tdId, rating, desc);
        }

        public static bool deleteReview(int tdId, int rating, string desc)
        {
            return ReviewHandler.deleteReview(tdId, rating, desc);
        }

        public static bool setTokenNotUsed(string token)
        {
            return ReviewHandler.setTokenNotUsed(token);
        }
    }
}