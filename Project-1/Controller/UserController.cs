using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Project_1.Handler;
using Project_1.Models;

namespace Project_1.Controller
{
    public class UserController
    {
        //Register Page
        public static string checkName(string name)
        {
            string checkName = "";
            if (name == "")
                checkName = "Name cannot be empty!";

            else if ((name.Length < 1 || name.Length > 30) || !name.Contains(" "))
                checkName = "Length must be between 1 and 30 and must contains white space";

            return checkName;
        }

        public static string checkUsername(string username)
        {
            string checkUsername = "";
            if (username == "")
                checkUsername = "Username cannot be empty";

            else if ((username.Length < 6 || username.Length > 20) || !(username.Contains(" ") || username.Contains("_")))
                checkUsername = "Length must be between 6 and 20, alphanumeric with space or underscore";

            return checkUsername;
        }

        public static string checkPassword(string password)
        {
            string checkPassword = "";
            if (password == "")
                checkPassword = "Password cannot be empty";

            else if (password.Length < 6)
                checkPassword = "Length must be at least 6 characters, alphanumeric";
            return checkPassword;
        }

        public static string checkConfirmPassword(string password, string confirmPassword)
        {
            string checkConfirmPassword = "";

            if (confirmPassword == "")
                checkConfirmPassword = "Confirm password cannot be empty";

            else if (password != confirmPassword)
            {
                checkConfirmPassword = "Password doesn't match";
            }

            return checkConfirmPassword;
        }

        public static int rolesConverter(string role)
        {
            if (role == "Seller")
                return 1;
            return 2;
        }

        public static bool registrationValidation(string errName, string errUsername, string errPassword, string errConfirmPassword)
        {
            if (errName == "" && errUsername == "" && errPassword == "" && errConfirmPassword == "")
            {
                return true;
            }
            return false;
        }

        public static bool addData(string name, string username, string password, int roleId)
        {
            UserHandler.insertNewUser(name, username, password, roleId);
            return true;
        }

        //Login Page
        public static string checkUsernameLogin(string username)
        {
            string checkUsername = "";
            if (username == "")
                checkUsername = "Username must be filled";
            return checkUsername;
        }

        public static string checkPasswordLogin(string password)
        {
            string checkPassword = "";
            if (password == "")
                checkPassword = "Password must be filled";
            return checkPassword;
        }

        public static bool loginValidation(string errUsername, string errPassword)
        {
            if (errUsername == "" && errPassword == "")
                return true;
            return false;
        }

        public static string checkLogin(string username, string password)
        {
            User user = UserHandler.login(username, password);
            if (user != null)
                return "";
            return "Invalid username or password";
        }

        public static int getUserId(string username, string password)
        {
            User user = UserHandler.login(username, password);
            if (user != null)
                return user.Id;
            return -1;
        }

        public static int getUserRole(int userId)
        {
            User user = UserHandler.loggedIn(userId);
            if (user != null)
                return user.RoleId;
            return -1;
        }

        public static string getUserName(int userId)
        {
            User user = UserHandler.loggedIn(userId);
            if(user != null)
            {
                return user.Name;
            }
            return "Guest";
        }

        //Update Page
        public static string checkOldPassword(string password, int userId)
        {
            User user = UserHandler.loggedIn(userId);
            string checkConfirmPassword = "";
            if (user != null && password == user.Password)
            {
                return checkConfirmPassword;
            }
            return "Old Password is incorrect!";
        }

        public static bool updateValidation(string errName, string errOldPassword, string errConfirmPassword)
        {
            if (errName == "" && errOldPassword == "" && errConfirmPassword == "")
            {
                return true;
            }
            return false;
        }

        public static bool UpdateDataUser(int userId, string name, string newPassword)
        {
            UserHandler.UpdateUser(userId, name, newPassword);
            return true;
        }


    }
}