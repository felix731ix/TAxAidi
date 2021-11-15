using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Repository
{
    public class TransactionDetailRepository
    {

        private static DatabaseTAxAidiEntities1 db = new DatabaseTAxAidiEntities1();

        public static bool insertTransactionDetail(TransactionDetail td)
        {
            if (td != null)
            {
                db.TransactionDetails.Add(td);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<TokenList> getTokenListByHeaderId(int headerId)
        {
            var q = (from th in db.TransactionHeaders
                     join td in db.TransactionDetails on th.Id equals td.TransactionHeaderId
                     join st in db.Statuses on td.StatusId equals st.Id
                     where th.Id == headerId
                     select new
                     {
                         Token = td.Token,
                         Status = st.Name
                     }).ToList().Select(x => new TokenList
                     {
                         Token = x.Token,
                         Status = x.Status
                     }).ToList();

            return q;
        }

        public static bool UpdateToken(TransactionDetail td)
        {
            if (td != null)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static int getTdIdByToken(string token)
        {
            TransactionDetail td = (from x in db.TransactionDetails where token == x.Token select x).FirstOrDefault();
            if (td != null)
            {
                return td.Id;
            }
            return -1;
        }

        public static TransactionDetail getTdObjByToken(string token)
        {
            TransactionDetail td = (from x in db.TransactionDetails where token == x.Token select x).FirstOrDefault();
            if (td != null)
            {
                return td;
            }
            return null;
        }


        public static bool checkTokenUsed(string token)
        {
            TransactionDetail td = (from x in db.TransactionDetails where token == x.Token select x).FirstOrDefault();
            //kalo used return true
            if (td != null && td.StatusId == 2)
            {
                return true;
            }
            //kalo not used return false
            else
            {
                return false;
            }
        }

        public static string getTokenStatus(bool used)
        {
            if (used == true)
            {
                return "Used";
            }
            else
            {
                return "Not Used";
            }
        }

        public static List<TransactionDetail> getDetailListByHeaderId(int headerId)
        {
            return (from x in db.TransactionDetails
                    join th in db.TransactionHeaders
                    on x.TransactionHeaderId equals th.Id
                    where x.TransactionHeaderId == headerId
                    select x).ToList();
        }

        public static bool isCancelValid(int headerId)
        {
            TransactionDetail td = (from x in db.TransactionDetails
                                    where x.TransactionHeaderId == headerId
                                    where x.StatusId == 2
                                    select x).FirstOrDefault();
            if (td == null)
            {
                return true;
            }
            return false;
        }

        public static List<TransactionDetail> getTdListByHeaderId(int headerId)
        {
            return (from x in db.TransactionDetails where x.TransactionHeaderId == headerId select x).ToList();
        }

        public static bool deleteDetail(TransactionDetail td)
        {
            if (td != null)
            {
                db.TransactionDetails.Remove(td);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}