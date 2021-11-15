using Project_1.Factories;
using Project_1.Factory;
using Project_1.Models;
using Project_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Handler
{
    public class ShowHandler
    {
        public static bool insertShows(int sellerId, string name, string url, string description, int price)
        {
            Show show = ShowFactory.Create(sellerId, name, url, description, price);
            return ShowRepository.insertShow(show);
        }

        public static bool checkRegisteredShows(string name)
        {
            return ShowRepository.getShowsName(name);
        }

        public static int getShowIdbyToken(string token)
        {
            return ShowRepository.getShowIdbyToken(token);
        }

        public static int getShowId(string name)
        {
            return ShowRepository.getShowId(name);
        }
        public static List<Show> getAllShows()
        {
            return ShowRepository.getAllShows();

        }
        public static List<Show> searchShows(string showName)
        {
            return ShowRepository.searchShows(showName);

        }

        public static string getShowURLByToken(string token)
        {
            return ShowRepository.getShowURLByToken(token);
        }

        //Show Detail Page Start Here

        public static int getSellerByShowId (int showId)
        {
            return ShowRepository.getSellerByShowId(showId);
        }

        public static string showNameByID(int showId)
        {
            return ShowRepository.showNameByID(showId);
        }

        public static string getShowPriceByShowId(int showId)
        {
            return ShowRepository.getShowPriceByShowId(showId);
        }

        public static int showPriceByID(int showId)
        {
            return ShowRepository.showPriceByID(showId);
        }
        public static string showSellerByID(int showId)
        {
            return ShowRepository.showSellerByID(showId);
        }

        public static string showDescByID(int showId)
        {
            return ShowRepository.showDescByID(showId);
        }

        public static double showAvgByID(int showId)
        {
            return ShowRepository.showAvgByID(showId);
        }

        public static string showUrlByID(int showId)
        {
            return ShowRepository.showUrlByID(showId);
        }

        public static bool updateShow(int showId, string name, string url, string description, int price)
        {
            Show show = ShowRepository.getShowById(showId);
            if(show != null)
            {
                show.Title = name;
                show.URL = url;
                show.Description = description;
                show.Price = price;
                return ShowRepository.updateShow(show);
            }
            return false;
        }
        //Show Detail Page End Here

        public static bool checkIfBought(DateTime show, int userId, int showId)
        {
            return ShowRepository.checkifBought(show, userId, showId);
        }
    }
}