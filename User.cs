using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class User : Person
    {
        public new int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int PsersonId { get; set; }

        public User(string firstName, string lastName, DateTime dateofbitth, string gender, string email,
                      string phone, string images, string userName, string password, string usertype)
                   : base(firstName, lastName, dateofbitth,gender, email, phone,images)
        {
            UserName = userName;
            Password = password;
            UserType = usertype;
        }

        public User(int id,string firstName, string lastName, DateTime dateofbitth, string gender, string email,
                      string phone, string images, string userName, string password, string usertype)
                   : base(firstName, lastName, dateofbitth, gender, email, phone, images)
        {
            Id = id;
            UserName = userName;
            Password = password;
            UserType = usertype;
        }
    }
}
