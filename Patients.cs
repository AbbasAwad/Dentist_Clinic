using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Patients : Person
    {
        public new int ID { get; set; }
        public string Patients_TC { get; set; }
        public string State { get; set; }
        public DateTime StateDate { get; set; }
        public decimal Cast { get; set; }
        public decimal Payed { get; set; }
        public decimal Remind { get; set; }
        public int Person_ID { get; set; }

        public Patients(string firstName, string lastName, DateTime dateofbitth, string gender,
                        string email, string phone, string images,string patients_tc,string state,
                        DateTime statedate,decimal cast,decimal payed,decimal remind)
                        : base(firstName, lastName, dateofbitth, gender, email, phone, images)
        {
            Patients_TC = patients_tc;
            State = state;
            StateDate = statedate;
            Cast = cast;
            Payed = payed;
            Remind = remind;
        }

        public Patients(int id,string firstName, string lastName, DateTime dateofbitth, string gender,
                        string email, string phone, string images, string patients_tc, string state,
                        DateTime statedate, decimal cast, decimal payed, decimal remind)
                        : base(firstName, lastName, dateofbitth, gender, email, phone, images)
        {
            ID = id;
            Patients_TC = patients_tc;
            State = state;
            StateDate = statedate;
            Cast = cast;
            Payed = payed;
            Remind = remind;
        }
    }
}
