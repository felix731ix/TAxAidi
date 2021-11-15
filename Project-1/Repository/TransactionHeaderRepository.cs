using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_1.Repository
{
    public class TransactionHeaderRepository
    {

        private static DatabaseTAxAidiEntities1 db = new DatabaseTAxAidiEntities1();

        public static bool insertTransactionHeader(TransactionHeader th)
        {
            if (th != null)
            {
                db.TransactionHeaders.Add(th);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<TransactionsList> getAllTransaction(int userId)
        {

            var q = (from th
                     in db.TransactionHeaders
                     join show in db.Shows on th.ShowId equals show.Id
                     join td in db.TransactionDetails on th.Id equals td.TransactionHeaderId
                     orderby th.Id ascending
                     where th.BuyerId == userId
                     group new { th.Id, show, td } by th into grp
                     select new
                     {
                         HeaderId = grp.Select(x => x.Id).FirstOrDefault(),
                         CreatedAt = grp.Key.CreatedAt,
                         ShowName = grp.Select(x => x.show.Title).FirstOrDefault(),
                         ShowTime = grp.Key.ShowTime,
                         Quantity = grp.Select((x => x.td.TransactionHeaderId)).Count(),
                         TotalPrice = grp.Select((x => x.show.Price)).FirstOrDefault()
                     }).ToList().Select(x => new TransactionsList
                     {
                         HeaderId = x.HeaderId,
                         CreatedAt = x.CreatedAt,
                         ShowName = x.ShowName,
                         ShowTime = x.ShowTime,
                         Quantity = x.Quantity,
                         TotalPrice = ((x.TotalPrice) * (x.Quantity))
                     }).ToList();
            return q;

        }

        public static int getHeaderBuyerByID(int headerId)
        {
            TransactionHeader th = (from x in db.TransactionHeaders where headerId == x.Id select x).FirstOrDefault();
            if (th != null)
            {
                return th.BuyerId;
            }
            return -1;
        }

        public static List<TransactionHeader> getHeaderList(int userId)
        {
            List<TransactionHeader> th = (from x in db.TransactionHeaders
                                          join sh in db.Shows on x.ShowId equals sh.Id
                                          where sh.SellerId == userId
                                          select x).ToList();
            if (th != null)
            {
                return th;
            }
            return null;
        }

        public static bool isPastShowTime(string token)
        {
            TransactionHeader th = (from x in db.TransactionHeaders
                                    join td in db.TransactionDetails on x.Id equals td.TransactionHeaderId
                                    where td.Token == token
                                    select x).FirstOrDefault();
            //Udah lewat show time
            if (th != null)
            {
                if (DateTime.Now > th.ShowTime.AddHours(1))
                {
                    return true;
                }
                //belum lewat show time
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool isShowTimeNow(string token)
        {
            TransactionHeader th = (from x in db.TransactionHeaders
                                    join td in db.TransactionDetails on x.Id equals td.TransactionHeaderId
                                    where td.Token == token
                                    select x).FirstOrDefault();
            //Masih di Show Time
            if (th != null)
            {
                if (th.ShowTime < DateTime.Now && th.ShowTime.AddHours(1) > DateTime.Now)
                {
                    return true;
                }
                //Bukan di show time
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool deleteHeader(TransactionHeader th)
        {
            if (th != null)
            {
                db.TransactionHeaders.Remove(th);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool isCancelValid(int headerId)
        {
            //Check is time valid
            TransactionHeader th = (from x in db.TransactionHeaders where x.ShowTime > DateTime.Now where x.Id == headerId select x).FirstOrDefault();
            if (th != null)
            {
                return true;
            }
            return false;
        }

        public static TransactionHeader getHeaderbyId(int headerId)
        {
            TransactionHeader th = (from x in db.TransactionHeaders where x.Id == headerId select x).FirstOrDefault();
            if (th != null)
            {
                return th;
            }
            return null;
        }


    }
}