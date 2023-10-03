using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access_Layer
{
    public class DataExpences
    {
        public static int AddNewExpence(Expance expance)
        {
            int ExpanceID = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO Expences(Expence_No,Expence_Name,Expence_Value,Expence_Note,Expence_FileName,Expence_Date)
                           VALUES (@expance_No,@expence_Name,@expence_Value,@expence_Note,@expence_FileName,@expence_Date)
                           SELECT SCOPE_IDENTITY();";

                if (expance.Expance_No != "")
                    cmd.Parameters.AddWithValue("@expance_No", expance.Expance_No);
                else
                    cmd.Parameters.AddWithValue("@expance_No", System.DBNull.Value);

                if (expance.Expance_Name != "")
                    cmd.Parameters.AddWithValue("@expence_Name", expance.Expance_Name);
                else
                    cmd.Parameters.AddWithValue("@expence_Name", System.DBNull.Value);

                if (expance.Expance_Value != 0)
                    cmd.Parameters.AddWithValue("@expence_Value", expance.Expance_Value);
                else
                    cmd.Parameters.AddWithValue("@expence_Value", System.DBNull.Value);

                if (expance.Expance_Note != "")
                    cmd.Parameters.AddWithValue("@expence_Note", expance.Expance_Note);
                else
                    cmd.Parameters.AddWithValue("@expence_Note", System.DBNull.Value);

                if (expance.Exoance_FileName != "")
                    cmd.Parameters.AddWithValue("@expence_FileName", expance.Exoance_FileName);
                else
                    cmd.Parameters.AddWithValue("@expence_FileName", System.DBNull.Value);

                    cmd.Parameters.AddWithValue("@expence_Date", expance.Expance_Data);

                con.Open();

                object result = cmd.ExecuteScalar();
                int.TryParse(result.ToString(), out int insertedPersonID);
                ExpanceID = insertedPersonID;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return ExpanceID;
        }

        public static bool UpDateExpence(Expance expance)
        {
            int rowsAffected = 0;
            int Expenceid = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE Expences
                                  set
                                  Expence_No = @expence_No,
                                  Expence_Name = @expence_Name,
                                  Expence_Value = @expence_Value,
                                  Expence_Note = @expence_Note,
                                  Expence_FileNamem = @expence_FileName,
                                  Expence_Date = @expence_Date
                                  WHERE ID=@id;";

                cmd.Parameters.AddWithValue("@id", expance.ID);

                if (expance.Expance_Name != "")
                    cmd.Parameters.AddWithValue("@expance_Name", expance.Expance_Name);
                else
                    cmd.Parameters.AddWithValue("@expance_Name", System.DBNull.Value);

                if (expance.Expance_Value != 0)
                    cmd.Parameters.AddWithValue("@expance_Value", expance.Expance_Value);
                else
                    cmd.Parameters.AddWithValue("@expance_Value", System.DBNull.Value);

                if (expance.Expance_Note != "")
                    cmd.Parameters.AddWithValue("@expance_Note", expance.Expance_Note);
                else
                    cmd.Parameters.AddWithValue("@expance_Note", System.DBNull.Value);

                if (expance.Exoance_FileName != "")
                    cmd.Parameters.AddWithValue("@exoance_FileName", expance.Exoance_FileName);
                else
                    cmd.Parameters.AddWithValue("@exoance_FileName", System.DBNull.Value);

                cmd.Parameters.AddWithValue("@exoance_Date", expance.Expance_Data);

                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);
        }

        public static DataTable GetExpences()
        {
            DataTable Expences = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT Expence_No,Expence_Name,Expence_Value,Expence_Note,Expence_FileName,
                                    Expence_Date
                            FROM Expences ;";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Expences.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Expences;
        }

        public static Expance GetExpance(int ExpanceID)
        {
            Expance expance = new Expance(0,"","",0,"","",DateTime.Now);

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Expence_No,Expence_Name,Expence_Value,Expence_Note,Expence_FileNamem,
                                    Expence_Date
                            FROM Expences
                            WHERE ID=@ExpanceID;";

            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@ExpanceID", ExpanceID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    expance.ID = (int)reader["ID"];

                    if (reader["Expance_No"] != DBNull.Value)
                        expance.Expance_No = (string)reader["Expance_No"];
                    else expance.Expance_No = "";

                    if (reader["Expance_Name"] != DBNull.Value)
                        expance.Expance_Name = (string)reader["Expance_Name"];
                    else expance.Expance_Name = "";

                    if (reader["Expance_Value"] != DBNull.Value)
                        expance.Expance_Value= (decimal)reader["Expance_Value"];
                    else expance.Expance_Value = 0;

                    if (reader["Expance_Note"] != DBNull.Value)
                        expance.Expance_Note = (string)reader["Expance_Note"];
                    else expance.Expance_Note = "";

                    if (reader["Exoance_FileName"] != DBNull.Value)
                        expance.Exoance_FileName = (string)reader["Exoance_FileName"];
                    else expance.Exoance_FileName = "";

                    if (reader["Expance_Data"] != DBNull.Value)
                        expance.Expance_Data = (DateTime)reader["Expance_Data"];
                    else expance.Expance_Data = DateTime.Now;

                    reader.Close();
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return expance;
        }

        public static decimal TotalExpences()
        {
            decimal total = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"select sum(Expence_Value) From Expences;";

            SqlCommand cmd = new SqlCommand(Query, con);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                decimal.TryParse(result.ToString(), out decimal insertedPersonID);
                total = insertedPersonID;
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return total;

        }

        public static DataTable searchExpences(string Search)
        {
            DataTable Expences = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT Expence_No,Expence_Name,Expence_Value,Expence_Note,Expence_FileName,
                                    Expence_Date
                            FROM Expences 
                            where Expence_FileName like @search+'%';";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@search", Search);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Expences.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Expences;
        }
    }
}
