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
    public class DataEarns
    {
        public static decimal GetAllIncomes()
        {
            decimal TotalComes = 0;

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"Select sum(Patients.Cast) from Patients;";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null && decimal.TryParse(Result.ToString(), out decimal insertedID))
                    TotalComes = insertedID;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return TotalComes;
        }

        public static decimal GetAllExpences()
        {
            decimal TotalExpences = 0;

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"Select sum(Expence_Value) from Expences;";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null && decimal.TryParse(Result.ToString(), out decimal insertedID))
                    TotalExpences = insertedID;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return TotalExpences;
        }

        public static DataTable GetEarns()
        {
            DataTable Earn = new DataTable();

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"select Persons.FirstName +' '+Persons.LastName As Name ,Patients.StateDate as Date, Patients.Payed 
                             from Patients 
                             inner join Persons on Patients.Person_ID = Persons.ID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Earn.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Earn;
        }

        public static DataTable GetExpences()
        {
            DataTable Expence = new DataTable();

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"select Expences.Expence_Name,Expences.Expence_Date,Expences.Expence_Value from Expences";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Expence.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Expence;
        }
        public static DataTable Earns(DateTime DateFrom, DateTime DateTo)
        {
            DataTable Earn = new DataTable(); 

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"select Persons.FirstName +' '+Persons.LastName As Name ,Patients.StateDate as Date, Patients.Payed 
                             from Patients 
                             inner join Persons on Patients.Person_ID = Persons.ID
                             where Patients.StateDate = @DateFrom OR Patients.StateDate Between @DateFrom AND @DateTo";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", DateTo);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Earn.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Earn;
        }

        public static DataTable Expences(DateTime DateFrom, DateTime DateTo)
        {
            DataTable Expence = new DataTable();

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"select Expences.Expence_Name,Expences.Expence_Date,Expences.Expence_Value from Expences
                             Where Expences.Expence_Date = @DateFrom OR Expences.Expence_Date Between @DateFrom AND @DateTo";
            SqlCommand cmd = new SqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@DateFrom", DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", DateTo);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Expence.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Expence;
        }

        public static DataTable Debtes()
        {
            DataTable Debte = new DataTable();

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"select Patient_TC,Persons.FirstName +' '+Persons.LastName As Name ,Gender,Phone,Patients.State,Patients.StateDate as Date,Patients.Cast, Patients.Payed ,Patients.Remind
                             from Patients 
                             inner join Persons on Patients.Person_ID = Persons.ID";
                            
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Debte.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Debte;
        }
    }
}
