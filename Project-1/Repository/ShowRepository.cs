using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Repository
{

    public class ShowRepository
    {
        private static DatabaseTAxAidiEntities1 db = new DatabaseTAxAidiEntities1();

        public static bool insertShow(Show show)
        {
            if (show != null)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool getShowsName(string showName)
        {
            Show show = (from x in db.Shows where showName == x.Title select x).FirstOrDefault();
            if (show != null)
            {
                return true;
            }
            return false;
        }

        public static int getShowIdbyToken(string token)
        {
            Show show = (from td in db.TransactionDetails
                         join th in db.TransactionHeaders on td.TransactionHeaderId equals th.Id
                         join sh in db.Shows on th.ShowId equals sh.Id
                         where token == td.Token
                         select sh).FirstOrDefault();
            if (show != null)
            {
                return show.Id;
            }
            return -1;
        }

        public static int getShowId(string showName)
        {
            Show show = (from x in db.Shows where showName == x.Title select x).FirstOrDefault();
            if (show != null)
            {
                return show.Id;
            }
            return -1;
        }

        public static string getShowURLByToken(string token)
        {
            Show show = (from td in db.TransactionDetails
                         join th in db.TransactionHeaders on td.TransactionHeaderId equals th.Id
                         join sh in db.Shows on th.ShowId equals sh.Id
                         where token == td.Token
                         select sh).FirstOrDefault();
            if (show != null)
            {
                return show.URL;
            }
            return null;
        }

        public static string getShowPriceByShowId(int showId)
        {
            Show show = (from sh in db.Shows
                         join th in db.TransactionHeaders on sh.Id equals th.ShowId
                         select sh).FirstOrDefault();
            if (show != null)
            {
                return show.Price.ToString();
            }
            return null;
        }

        //Show Detail Page Start Here

        public static int getSellerByShowId(int showId)
        {
            Show show = (from x in db.Shows where showId == x.Id select x).FirstOrDefault();
            if (show != null)
            {
                return show.SellerId;
            }
            return -1;
        }

        public static string showNameByID(int showId)
        {
            Show show = (from x in db.Shows where showId == x.Id select x).FirstOrDefault();
            if (show != null)
            {
                return show.Title;
            }
            return null;
        }

        public static int showPriceByID(int showId)
        {
            Show show = (from x in db.Shows where showId == x.Id select x).FirstOrDefault();
            if (show != null)
            {
                return show.Price;
            }
            return -1;
        }

        public static string showSellerByID(int showId)
        {
            Show show = (from x in db.Shows where showId == x.Id select x).FirstOrDefault();
            User user = (from x in db.Users where show.SellerId == x.Id select x).FirstOrDefault();
            if (user != null)
            {
                return user.Name;
            }
            return null;
        }

        public static string showDescByID(int showId)
        {
            Show show = (from x in db.Shows where showId == x.Id select x).FirstOrDefault();
            if (show != null)
            {
                return show.Description;
            }
            return null;
        }

        public static double showAvgByID(int showId)
        {
            var q = (from review in db.Reviews
                     join td in db.TransactionDetails
                     on review.TransactionDetailId equals td.Id
                     join th in db.TransactionHeaders
                     on td.TransactionHeaderId equals th.Id
                     where th.ShowId == showId
                     select review).ToList();
            double result = 0;
            if (q.Count > 0)
            {
                result = q.Average(x => x.Rating);
            }
            return result;
        }

        public static string showUrlByID(int showId)
        {
            Show show = (from x in db.Shows where showId == x.Id select x).FirstOrDefault();
            if (show != null)
            {
                return show.URL;
            }
            return null;
        }

        public static Show getShowById(int showId)
        {
            Show show = (from x in db.Shows where showId == x.Id select x).FirstOrDefault();
            if (show != null)
            {
                return show;
            }
            return null;
        }

        public static bool updateShow(Show show)
        {
            if (show != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        //Show Detail Page End Here

        public static List<Show> getAllShows()
        {
            var q = (from show in db.Shows
                     join user in db.Users on show.SellerId equals user.Id
                     orderby show.Title ascending
                     select new
                     {
                         Title = show.Title,
                         Price = show.Price,
                         Name = user.Name,
                         Description = show.Description
                     }).ToList()
                          .Select(x =>
                          new Show
                          {
                              Title = x.Title,
                              Price = x.Price,
                              Name = x.Name,
                              Description = x.Description
                          }).ToList();
            return q;
        }

        public static List<Show> searchShows(string showName)
        {
            var q = (from show in db.Shows
                     join user in db.Users on show.SellerId equals user.Id
                     where show.Title.Contains(showName)
                     orderby show.Title ascending
                     select new
                     {
                         Title = show.Title,
                         Price = show.Price,
                         Name = user.Name,
                         Description = show.Description
                     }).ToList()
                        .Select(x =>
                        new Show
                        {
                            Title = x.Title,
                            Price = x.Price,
                            Name = x.Name,
                            Description = x.Description
                        }).ToList();
            return q;
        }

        public static bool checkifBought(DateTime show, int userId, int showId)
        {
            if ((from x in db.TransactionHeaders where userId == x.BuyerId select x).FirstOrDefault() != null)
            {
                if ((from x in db.TransactionHeaders where showId == x.ShowId select x).FirstOrDefault() != null)
                {
                    if ((from x in db.TransactionHeaders where show == x.ShowTime select x).FirstOrDefault() != null)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

    }
}