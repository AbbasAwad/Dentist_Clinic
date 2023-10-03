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
    public class BussPatients
    {
        public static Patients getEmptyPatient() => new Patients("", "", DateTime.Now, "", "", "", "", "", "", DateTime.Now, 0, 0, 0);
        public static Patients Find(string pateint_tc)
        {
            Patients patient = DataPatients.GetPateint(pateint_tc);

            if (patient != null)
                return patient;
            else
                return null;
        }
        public static Patients Find(int pateintid)
        {
            Patients patient = DataPatients.GetPateint(pateintid);

            if (patient != null)
                return patient;
            else
                return null;
        }
        public static int AddNewPatient(Patients patient)
        {
            patient.ID = DataPatients.AddNewPatient(patient);

            return patient.ID;
        }
        public static bool UpdatPatient(Patients patient)
        {
            return DataPatients.UpDatePatient(patient);
        }
        public static bool DeletePatient(string pateint_tc)
        {
            Patients patient = BussPatients.Find(pateint_tc);
            if (patient != null)
            {
                DataPatients.DeletePatient(patient.Patients_TC);
                return true;
            }
            return false;
        }
        public static DataTable GetAllPateints()
        {
            return DataPatients.GetPatients();
        }
        public static bool isExsist(string pateint_tc) => BussPatients.isExsist(pateint_tc);
        public static int GetTotalPatients()
        {
            return DataPatients.CountPateints();
        }

        public static DataTable Search(string Search)
        {
            return DataPatients.SearchPatients(Search);
        }
    }
}
