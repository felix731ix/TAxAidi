using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_1.Models;

namespace Project_1.Factories
{
    public class UserFactory
    {
        //roleId, perlu di convert dari string -> id pada controller
        public static User Create(string name, string username, string password, int roleId)
        {
            User newUsers = new User();
            newUsers.Username = username;
            newUsers.Name = name;
            newUsers.Password = password;
            newUsers.RoleId = roleId;
            return newUsers;
        }
    }
}