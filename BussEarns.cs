using Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_Layer
{
    public class BussEarns
    {
        public static decimal GetIncomes()
        {
            return DataEarns.GetAllIncomes();
        }

        public static decimal GetExpences()
        {
            return DataEarns.GetAllExpences();
        }

        public static DataTable GetEarns()
        {
            return DataEarns.GetEarns();
        }

        public static DataTable GetExp()
        {
            return DataEarns.GetExpences();
        }
        public static DataTable Earns(DateTime DateForm, DateTime DateTo)
        {
            return DataEarns.Earns(DateForm,DateTo);
        }
        public static DataTable Expences(DateTime DateForm, DateTime DateTo)
        {
            return DataEarns.Expences(DateForm, DateTo);
        }
        public static DataTable Debtes()
        {
            return DataEarns.Debtes();
        }
    }
}
