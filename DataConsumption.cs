using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Layer
{
    public class DataConsumption
    {
        public static DataTable GetConsumption()
        {
            DataTable consumption = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Persons.FirstName + Persons.LastName AS 'Name' ,
                         Patients.Patient_TC AS 'Patient TC',
                         Patients.StateDate AS 'State Date',
                         Patients.Payed,Patients.Remind 
                         FROM Patients 
                         INNER JOIN Persons ON Patients.Person_ID = Persons.ID ";

            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    consumption.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return consumption;
        }

        public static double GetPayed()
        {
            double TotalPayed = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"select Sum(Patients.Payed) as 'Total Payed' from Patients";

            SqlCommand cmd = new SqlCommand(Query, con);

            try
            {
                con.Open();
                object result1 = cmd.ExecuteScalar();
                if (result1 != null && double.TryParse(result1.ToString(), out double insertedID))
                    TotalPayed = insertedID;
            }

            catch (Exception ex) { }
            finally { con.Close(); }
            return TotalPayed;

        }
        public static double GetRemind()
        {
            double TotalRemind = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"select Sum(Patients.Remind) as 'Total Remind' from Patients";

            SqlCommand cmd = new SqlCommand(Query, con);

            try
            {
                con.Open();
                object result1 = cmd.ExecuteScalar();
                if (result1 != null && double.TryParse(result1.ToString(), out double insertedID))
                    TotalRemind = insertedID;
            }

            catch (Exception ex) { }
            finally { con.Close(); }
            return TotalRemind;

        }
        public static int GetPatients()
        {
            int TotalPatients = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"select count(Patients.Patient_TC) as 'Total Patients' from Patients";

            SqlCommand cmd = new SqlCommand(Query, con);

            try
            {
                con.Open();
                object result1 = cmd.ExecuteScalar();
                if (result1 != null && int.TryParse(result1.ToString(), out int insertedID))
                    TotalPatients = insertedID;
            }

            catch (Exception ex) { }
            finally { con.Close(); }
            return TotalPatients;
        }

        public static DataTable SearchConsumption(string search)
        {
            DataTable consumption = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Persons.FirstName + Persons.LastName AS 'Name' ,
                         Patients.Patient_TC AS 'Patient TC',
                         Patients.StateDate AS 'State Date',
                         Patients.Payed,Patients.Remind 
                         FROM Patients 
                         INNER JOIN Persons ON Patients.Person_ID = Persons.ID
                         where Persons.FirstName like @search+'%'";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@search", search);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    consumption.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return consumption;
        }
    }
}
