using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Person
    {
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Gender { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Images { set; get; }
        public Person(string firstName, string lastName,DateTime dateofbitth,string gender, string email,
                      string phone,string images)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateofbitth;
            Email = email;
            Phone = phone;
            Images = images;
        }
    }
}
