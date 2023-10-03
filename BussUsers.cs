using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Access_Layer;
using Shared;

namespace business_Layer
{
    public class BussUsers
    {
        public enum enMode { AddMode = 0, UpdatMode = 1 }
        public enMode Mode = enMode.AddMode;

        public static User getEmptyUser() => new User("", "",DateTime.Now,"","", "", "", "", "", "");
        public static User Find(string username)
        {
            User user = DataUsers.GetUsers(username);

            if (user != null)
                return user;
            else
                return null;
        }
        public static User Find(int UserID)
        {
            User user = DataUsers.GetUsers(UserID);

            if (user != null)
                return user;
            else
                return null;
        }
        public static int _AddNewUser(User user)
        {
            user.Id = DataUsers.AddNewUser(user);
                                                
            return user.Id;
        }

        public static bool _UpdatUser(User user)
        {           
            return DataUsers.UpDateUser(user);                                                      
        }

        public static bool DeleteUser(string username)
        {
            User user = BussUsers.Find(username);
            if (user != null)
            {
                DataUsers.DeleteUser(user.UserName);
                return true;
            }
            return false;
        }

        public static DataTable GetAllUses()
        {
            return DataUsers.GetUsers();
        }

        public static User GetUser(string username)
        {
            return DataUsers.GetUsers(username);
        }

        public static DataTable Search(string search)
        {
            return DataUsers.SearchUsers(search);
        }

        public static bool Login(string Username, string Password)
        {
            return DataUsers.Login(Username, Password);
        }

        public static int GetTotalUsers()
        {
            return DataUsers.CountUsers();
        }
        public static bool isExsist(string userName) => BussUsers.isExsist(userName);
    }
}
