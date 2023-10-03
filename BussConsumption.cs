using Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_Layer
{
    public class BussConsumption
    {
        public static DataTable GetConsumption()
        {
            return DataConsumption.GetConsumption();
        }
            
        public static double GetTotalPayed()
        {
            return DataConsumption.GetPayed();
        }
        public static double GetTotalRemind()
        {
            return DataConsumption.GetRemind();
        }

        public static int GetTotalPatients()
        {
            return DataConsumption.GetPatients();
        }

        public static DataTable Search(string Search)
        {
          return  DataConsumption.SearchConsumption(Search);
        }
    }
}
