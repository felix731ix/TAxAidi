using Project_1.Factory;
using Project_1.Models;
using Project_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Handler
{
    public class TransactionHandler
    {
        private static Random rd = new Random();

        public static bool insertTransactionHeader(int buyerId, int showId, DateTime showTime, DateTime createdAt, int qty)
        {
            TransactionHeader th = TransactionHeaderFactory.CreateHeader(buyerId, showId, showTime, createdAt);
            if (TransactionHeaderRepository.insertTransactionHeader(th) == true)
            {
                int headerId = th.Id;

                for (int i = 0; i < qty; i++)
                {
                    TransactionDetail td = TransactionDetailFactory.CreateDetail(headerId, 1, CreateToken());
                    TransactionDetailRepository.insertTransactionDetail(td);
                }

                return true;
            }

            return false;

        }

        public static List<TransactionHeader> getHeaderList(int userId)
        {
            return TransactionHeaderRepository.getHeaderList(userId);
        }

        public static int getHeaderBuyerByID(int headerId)
        {
            return TransactionHeaderRepository.getHeaderBuyerByID(headerId);
        }

        public static bool isPastShowTime(string token)
        {
            return TransactionHeaderRepository.isPastShowTime(token);
        }

        public static int getTdIdByToken(string token)
        {
            return TransactionDetailRepository.getTdIdByToken(token);
        }

        public static bool checkTokenUsed(string token)
        {
            return TransactionDetailRepository.checkTokenUsed(token);
        }

        public static bool isShowTimeNow(string token)
        {
            return TransactionHeaderRepository.isShowTimeNow(token);
        }

        public static bool isCancelValid(int headerId)
        {
            bool timeValid = TransactionHeaderRepository.isCancelValid(headerId);
            bool tokenValid = TransactionDetailRepository.isCancelValid(headerId);

            return (timeValid && tokenValid);
        }

        public static List<TransactionDetail> getDetailListByHeaderId(int headerId)
        {
            return TransactionDetailRepository.getDetailListByHeaderId(headerId);
        }

        public static string getTokenStatus(bool used)
        {
            return TransactionDetailRepository.getTokenStatus(used);
        }

        public static bool cancelTransaction(int headerId)
        {          
            //delete detail with same header
            List<TransactionDetail> tdListByHeaderId = TransactionDetailRepository.getTdListByHeaderId(headerId);
            bool deleteDetail = false;
            for (int i = 0; i < tdListByHeaderId.Count; i++)
            {
                deleteDetail = TransactionDetailRepository.deleteDetail(tdListByHeaderId[i]);
            }

            //delete header
            TransactionHeader th = TransactionHeaderRepository.getHeaderbyId(headerId);
            bool deleteHeader = TransactionHeaderRepository.deleteHeader(th);


            return deleteHeader && deleteDetail;
        }

        public static string CreateToken()
        {
            int length = 6;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rd.Next(s.Length)]).ToArray());
        }

        public static List<TransactionsList> getAllTransaction(int userId)
        {
            return TransactionHeaderRepository.getAllTransaction(userId);
        }


        public static List<TokenList> getTokenListByHeaderId(int headerId)
        {
            return TransactionDetailRepository.getTokenListByHeaderId(headerId);
        }

    }
}