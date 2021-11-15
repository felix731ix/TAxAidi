using Project_1.Factories;
using Project_1.Models;
using Project_1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_1.Handler
{
    public class UserHandler
    {
        public static bool insertNewUser(string name, string username, string password, int roleId)
        {
            User user = UserFactory.Create(name, username, password, roleId);
            return UserRepository.insertUser(user);
        }

        public static User login(string username, string password)
        {
            return UserRepository.getUser(username, password);

        }

        public static User loggedIn(int userId)
        {
            return UserRepository.getUserById(userId);
        }

        public static bool UpdateUser(int userId, string name, string newPassword)
        {
            User user = UserRepository.getUserById(userId);

            if (user != null)
            {
                user.Name = name;
                user.Password = newPassword;
                return UserRepository.UpdateUser(user);
            }
            return false;
        }
    }
}