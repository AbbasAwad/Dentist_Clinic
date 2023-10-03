using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Expance
    {
        public int ID { get; set; }
        public string Expance_No { get; set; }
        public string Expance_Name { get; set; }
        public decimal Expance_Value { get; set; }
        public string Expance_Note { get; set; }
        public string Exoance_FileName { get; set; }
        public DateTime Expance_Data { get; set; }

        public Expance( string expance_No, string expance_Name, decimal expance_Value,
                        string expance_Note, string exoance_FileName, DateTime expance_Data)
        {
            Expance_No = expance_No;
            Expance_Name = expance_Name;
            Expance_Value = expance_Value;
            Expance_Note = expance_Note;
            Exoance_FileName = exoance_FileName;
            Expance_Data = expance_Data;
        }
        public Expance (int iD,string expance_No,string expance_Name,decimal expance_Value,
                        string expance_Note, string exoance_FileName, DateTime expance_Data)
        {
            ID = iD;
            Expance_No = expance_No;
            Expance_Name = expance_Name;
            Expance_Value = expance_Value;
            Expance_Note = expance_Note;
            Exoance_FileName = exoance_FileName;
            Expance_Data = expance_Data;
        }
    }
}
