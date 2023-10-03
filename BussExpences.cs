using Access_Layer;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_Layer
{
    public class BussExpences
    {
        public static int AddNewExpence(Expance expance)
        {
            return DataExpences.AddNewExpence(expance);
        }
        public static bool UpdateExpence(Expance expance)
        {
            return DataExpences.UpDateExpence(expance);
        }
        public static DataTable GetAllExpences()
        {
            return DataExpences.GetExpences();
        }

        public static Expance Find(int ExpenceID)
        {
            Expance expance = DataExpences.GetExpance(ExpenceID);
            if(expance != null)
                return expance;
            return null;
        }
        public static Expance GetExpences(int ExpenceID)
        {
            return DataExpences.GetExpance(ExpenceID);
        }

        public static decimal GetTotalExpences()
        { return DataExpences.TotalExpences(); }
    }
}
