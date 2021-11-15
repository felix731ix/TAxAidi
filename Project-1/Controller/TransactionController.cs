using Project_1.Handler;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Controller
{
    public class TransactionController
    {

        public static bool insertTransactionHeader(int buyerId, int showId, DateTime showTime, DateTime createdAt, int qty)
        {
            TransactionHandler.insertTransactionHeader(buyerId, showId, showTime, createdAt, qty);
            return true;
        }
        
        public static List<TransactionsList> getAllTransactions(int userId)
        {
            return TransactionHandler.getAllTransaction(userId);
        }

        public static bool checkTokenUsed(string token)
        {
            return TransactionHandler.checkTokenUsed(token);
        }

        public static List<TransactionHeader> getHeaderList(int userId)
        {
            return TransactionHandler.getHeaderList(userId);
        }

        public static int getHeaderBuyerByID(int headerId)
        {
            return TransactionHandler.getHeaderBuyerByID(headerId);
        }

        public static bool isPastShowTime(string token)
        {
            return TransactionHandler.isPastShowTime(token);
        }

        public static int getTdIdByToken(string token)
        {
            return TransactionHandler.getTdIdByToken(token);
        }

        public static bool isShowTimeNow(string token)
        {
            return TransactionHandler.isShowTimeNow(token);
        }

        public static List<TokenList> getTokenListByHeaderId(int headerId)
        {
            return TransactionHandler.getTokenListByHeaderId(headerId);
        }

        public static bool isCancelValid(int headerId)
        {
            return TransactionHandler.isCancelValid(headerId);
        }

        public static List<TransactionDetail> getDetailListByHeaderId(int headerId)
        {
            return TransactionHandler.getDetailListByHeaderId(headerId);
        }

        public static bool cancelTransaction(int headerId)
        {
            return TransactionHandler.cancelTransaction(headerId);
        }

        public static string getTokenStatus(bool used)
        {
            return TransactionHandler.getTokenStatus(used);
        }
    }
}