using Project_1.Handler;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Project_1.Controller
{
    public class ShowController
    {
        public static bool insertShow(int sellerId, string name, string url, string description, int price)
        {
            ShowHandler.insertShows(sellerId, name, url, description, price);
            return true;
        }

        public static int getShowIdbyToken(string token)
        {
            return ShowHandler.getShowIdbyToken(token);
        }

        public static string checkShowName(string name)
        {
            string lblError = "";
            if (name != "")
            {
                if (ShowHandler.checkRegisteredShows(name) == true)
                {
                    lblError = "Name's shows must be unique among the seller’s shows";
                }
            }
            else
            {
                lblError = "Name must be filled";
            }
            return lblError;
        }

        public static string getShowURLByToken(string token)
        {
            return ShowHandler.getShowURLByToken(token);
        }

        public static string checkDescription(string description)
        {
            string lblError = "";
            if (description == "")
            {
                lblError = "Description must be filled";
            }
            return lblError;
        }

        public static string getShowPriceByShowId(int showId)
        {
            return ShowHandler.getShowPriceByShowId(showId);
        }

        public static string checkPrice(int price)
        {
            string lblError = "";
            if (price < 1000)
            {
                lblError = "Price must at least 1000";
            }
            return lblError;
        }

        public static int getShowId(string name)
        {
            return ShowHandler.getShowId(name);
        }

        public static List<Show> getAllShows()
        {
            return ShowHandler.getAllShows();
        }

        public static List<Show> searchShows(string showName)
        {
            return ShowHandler.searchShows(showName);
        }


        public static bool addShowValidation(string errName, string errDescription, string errPrice)
        {
            if (errName == "" && errDescription == "" && errPrice == "")
            {
                return true;
            }
            return false;
        }

        //Show Detail Page Start Here  //Update Show Page Start Here

        public static int getSellerByShowId(int showId)
        {
            return ShowHandler.getSellerByShowId(showId);
        }

        public static string showNameByID(int showId)
        {
            return ShowHandler.showNameByID(showId);
        }
        public static int showPriceByID(int showId)
        {
            return ShowHandler.showPriceByID(showId);
        }
        public static string showSellerByID(int showId)
        {
            return ShowHandler.showSellerByID(showId);
        }
        public static string showDescByID(int showId)
        {
            return ShowHandler.showDescByID(showId);
        }
        public static double showAvgByID(int showId)
        {
            return ShowHandler.showAvgByID(showId);
        }

        public static string showUrlByID(int showId)
        {
            return ShowHandler.showUrlByID(showId);
        }

        //checkUpdateShowName
        public static string checkUpdateShowName(string name, int showId)
        {
            string lblError = "";
            if (name != null)
            {
                if (getShowId(name) != showId)
                {
                    if (ShowHandler.checkRegisteredShows(name) == true)
                    {
                        lblError = "Name's shows must be unique among the seller’s shows";
                    }
                }
            }
            else
            {
                lblError = "Name must be filled";
            }
            return lblError;
        }

        public static bool updateShow(int showId, string name, string url, string description, int price)
        {
            ShowHandler.updateShow(showId, name, url, description, price);
            return true;
        }

        //Show Detail Page End Here  //Update Show Page End Here

        //Order Page
        public static string checkQty(string strQty)
        {
            int intQty;
            string lblError = "";
            if (int.TryParse(strQty, out intQty) == true)
            {
                if (intQty < 1)
                {
                    lblError = "Must be numeric and at least 1";
                }
            }
            else
            {
                lblError = "Quantity format is not valid!";
            }

            return lblError;
        }

        public static bool orderValidation(string errQty)
        {
            if (errQty == "")
            {
                return true;
            }
            return false;
        }

        public static bool checkIfBought(DateTime show, int userId, int showId)
        {
            return ShowHandler.checkIfBought(show, userId, showId);
        }


    }


}