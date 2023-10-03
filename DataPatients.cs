using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Access_Layer
{
    public class DataPatients
    {
        private static int getPersonId(string patient_tc)
        {
            int personId = -1;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataAccessSettings.ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select Persons.ID from Persons join Patients on Patients.Person_ID = Persons.ID where Patients.Patient_TC = @patient_tc";
                cmd.Parameters.AddWithValue("@patient_tc", patient_tc);

                con.Open();
                personId = (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return personId;
        }
        private static int getPersonIdByPatientID(int id)
        {
            int personId = -1;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataAccessSettings.ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select Persons.ID from Persons join Patients on Patients.Person_ID = Persons.ID where Patients.ID = @id";
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                personId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return personId;
        }
        public static DataTable GetPatients()
        {
            DataTable Users = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT Patients.ID,Patients.Patient_TC,Persons.FirstName +' '+Persons.LastName as Full_Name,
                            Persons.Gender,Persons.DateOfBirth,Persons.Email,Persons.Phone,Patients.State,
                            Patients.StateDate,Patients.Cast,Patients.Payed,Patients.Remind,Persons.Images
                            FROM Patients
                            INNER JOIN Persons on Patients.Person_ID = Persons.ID ;";
            SqlCommand cmd = new SqlCommand(Query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Users.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Users;
        }
        public static int AddNewPatient(Patients patient)
        {
            int patientID = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO Persons(FirstName,LastName,DateOfBirth,Gender,Email,Phone,Images)
                           VALUES (@firstname,@lastname,@dateofbirth,@gender,@email,@phone,@images)
                           SELECT SCOPE_IDENTITY();";
                if (patient.FirstName != "")
                    cmd.Parameters.AddWithValue("@firstname", patient.FirstName);
                else
                    cmd.Parameters.AddWithValue("@firstname", System.DBNull.Value);
                if (patient.LastName != "")
                    cmd.Parameters.AddWithValue("@lastname", patient.LastName);
                else
                    cmd.Parameters.AddWithValue("@lastname", System.DBNull.Value);

                cmd.Parameters.AddWithValue("@dateofbirth", patient.DateOfBirth);

                if (patient.Gender != "")
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                else
                    cmd.Parameters.AddWithValue("@gender", System.DBNull.Value);
                if (patient.Email != "")
                    cmd.Parameters.AddWithValue("@email", patient.Email);
                else
                    cmd.Parameters.AddWithValue("@email", System.DBNull.Value);
                if (patient.Phone != "")
                    cmd.Parameters.AddWithValue("@phone", patient.Phone);
                else
                    cmd.Parameters.AddWithValue("@phone", System.DBNull.Value);

                if (patient.Images != "")
                    cmd.Parameters.AddWithValue("@images", patient.Images);
                else
                    cmd.Parameters.AddWithValue("@images", System.DBNull.Value);

                con.Open();

                object result = cmd.ExecuteScalar();
                int.TryParse(result.ToString(), out int insertedPersonID);

                cmd.CommandText = @"INSERT INTO Patients(Patient_TC,State,StateDate,Cast,Payed,Remind,Person_ID)
                                    VALUES (@patient_tc,@state,@statedate,@cast,@payed,@remind,@person_ID)
                                    SELECT SCOPE_IDENTITY();";

                if (patient.Patients_TC != "")
                    cmd.Parameters.AddWithValue("@patient_tc", patient.Patients_TC);
                else
                    cmd.Parameters.AddWithValue("@patient_tc", System.DBNull.Value);

                if (patient.State != "")
                    cmd.Parameters.AddWithValue("@state", patient.State);
                else
                    cmd.Parameters.AddWithValue("@state", System.DBNull.Value);

                    cmd.Parameters.AddWithValue("@statedate", patient.StateDate);

                if (patient.Cast != 0)
                    cmd.Parameters.AddWithValue("@cast", patient.Cast);
                else
                    cmd.Parameters.AddWithValue("@cast", System.DBNull.Value);

                if (patient.Payed != 0)
                    cmd.Parameters.AddWithValue("@payed", patient.Payed);
                else
                    cmd.Parameters.AddWithValue("@payed", System.DBNull.Value);

                if (patient.Remind != 0)
                    cmd.Parameters.AddWithValue("@remind", patient.Remind);
                else
                    cmd.Parameters.AddWithValue("@remind", System.DBNull.Value);

                cmd.Parameters.AddWithValue("@person_ID", insertedPersonID);

                object result1 = cmd.ExecuteScalar();
                if (result1 != null && int.TryParse(result1.ToString(), out int insertedID))
                    patientID = insertedID;
            }

            catch (Exception ex) { }
            finally { con.Close(); }
            return patientID;
        }
        public static bool DeletePatient(string patient_tc)
        {
            int rowsAffected = 0;

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            int personId = getPersonId(patient_tc);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM Patients WHERE Patient_TC=@patient_tc;";
                cmd.Parameters.AddWithValue("patient_tc", patient_tc);

                con.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"DELETE FROM Persons WHERE ID = @personId";
                cmd.Parameters.AddWithValue("personId", personId);
                rowsAffected =Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);
        }
        public static bool UpDatePatient(Patients patient)
        {
            int rowsAffected = 0;
            int personid = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE Persons
                                  set
                                  FirstName=@firstname,
                                  LastName=@lastname,
                                  DateOfBirth=@dateofbirth,
                                  Gender=@gender,
                                  Email=@email,
                                  Phone=@phone,
                                  Images=@images
                                  WHERE ID=@personid;";

                cmd.Parameters.AddWithValue("personid", getPersonIdByPatientID(patient.ID));

                if (patient.FirstName != "")
                    cmd.Parameters.AddWithValue("@firstname", patient.FirstName);
                else
                    cmd.Parameters.AddWithValue("@firstname", System.DBNull.Value);
                if (patient.LastName != "")
                    cmd.Parameters.AddWithValue("@lastname", patient.LastName);
                else
                    cmd.Parameters.AddWithValue("@lastname", System.DBNull.Value);

                cmd.Parameters.AddWithValue("@dateofbirth", patient.DateOfBirth);

                if (patient.Gender != "")
                    cmd.Parameters.AddWithValue("@gender", patient.Gender);
                else
                    cmd.Parameters.AddWithValue("@gender", System.DBNull.Value);
                if (patient.Email != "")
                    cmd.Parameters.AddWithValue("@email", patient.Email);
                else
                    cmd.Parameters.AddWithValue("@email", System.DBNull.Value);
                if (patient.Phone != "")
                    cmd.Parameters.AddWithValue("@phone", patient.Phone);
                else
                    cmd.Parameters.AddWithValue("@phone", System.DBNull.Value);

                if (patient.Images != "")
                    cmd.Parameters.AddWithValue("@images", patient.Images);
                else
                    cmd.Parameters.AddWithValue("@images", System.DBNull.Value);

                con.Open();

                cmd.ExecuteNonQuery();

                cmd.CommandText = @"UPDATE Patients 
                                  SET
                                  Patient_TC=@patient_tc,
                                  State=@state,
                                  StateDate=@statedate,
                                  Cast=@cast,
                                  Payed=@payed,
                                  Remind=@remind
                                  WHERE ID=ID;";

                cmd.Parameters.AddWithValue("ID", patient.ID);

                if (patient.Patients_TC != "")
                    cmd.Parameters.AddWithValue("@patient_tc", patient.Patients_TC);
                else
                    cmd.Parameters.AddWithValue("@patient_tc", System.DBNull.Value);

                if (patient.State != "")
                    cmd.Parameters.AddWithValue("@state", patient.State);
                else
                    cmd.Parameters.AddWithValue("@state", System.DBNull.Value);

                    cmd.Parameters.AddWithValue("@statedate", patient.StateDate);

                if (patient.Cast != 0)
                    cmd.Parameters.AddWithValue("@cast", patient.Cast);
                else
                    cmd.Parameters.AddWithValue("@cast", System.DBNull.Value);

                if (patient.Payed != 0)
                    cmd.Parameters.AddWithValue("@payed", patient.Payed);
                else
                    cmd.Parameters.AddWithValue("@payed", System.DBNull.Value);

                if (patient.Remind != 0)
                    cmd.Parameters.AddWithValue("@remind", patient.Remind);
                else
                    cmd.Parameters.AddWithValue("@remind", System.DBNull.Value);
               
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);
        }
        public static Patients GetPateint(string patient_tc)
        {
         Patients patient = new Patients("", "", DateTime.Now, "", "", "", "", "", "", DateTime.Now,0,0,0);

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Patients.ID,Patients.Patient_TC, Persons.FirstName ,Persons.LastName ,
                             Persons.DateOfBirth,Persons.Gender,Persons.Email,Persons.Phone,Patients.State,
                             Patients.StateDate,Patients.Cast,Patients.Payed,Patients.Remind,Persons.Images
                             FROM Patients
                             INNER JOIN Persons on Patients.Person_ID = Persons.ID
                             WHERE Patients.Patient_TC=@patient_tc;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@patient_tc", patient_tc);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["FirstName"] != DBNull.Value)
                        patient.FirstName = (string)reader["FirstName"];
                    else patient.FirstName = "";

                    if (reader["LastName"] != DBNull.Value)
                        patient.LastName = (string)reader["LastName"];
                    else patient.LastName = "";

                    if (reader["DateOfBirth"] != DBNull.Value)
                        patient.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else patient.DateOfBirth = DateTime.Now;

                    if (reader["Gender"] != DBNull.Value)
                        patient.Gender = (string)reader["Gender"];
                    else patient.Gender = "";

                    if (reader["Email"] != DBNull.Value)
                        patient.Email = (string)reader["Email"];
                    else patient.Email = "";

                    if (reader["Phone"] != DBNull.Value)
                        patient.Phone = (string)reader["Phone"];
                    else patient.Phone = "";

                    if (reader["Images"] != DBNull.Value)
                        patient.Images = (string)reader["Images"];
                    else patient.Images = "";

                    if (reader["Patient_TC"] != DBNull.Value)
                    { patient.Patients_TC = (string)reader["Patient_TC"]; }
                    else patient.Patients_TC = "";

                    if (reader["State"] != DBNull.Value)
                    { patient.State = (string)reader["State"]; }
                    else patient.State = "";

                    if (reader["StateDate"] != DBNull.Value)
                    { patient.StateDate = (DateTime)reader["StateDate"]; }
                    else patient.StateDate = DateTime.Now;

                    if (reader["Cast"] != DBNull.Value)
                    { patient.Cast = (decimal)reader["Cast"]; }
                    else patient.Cast = 0;

                    if (reader["Payed"] != DBNull.Value)
                    { patient.Payed = (decimal)reader["Payed"]; }
                    else patient.Payed = 0;

                    if (reader["Remind"] != DBNull.Value)
                    { patient.Remind = (decimal)reader["Remind"]; }
                    else patient.Remind = 0;

                    reader.Close();
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return patient;
        }
        public static Patients GetPateint(int PateintID)
        {
            Patients patient = new Patients("", "", DateTime.Now, "", "", "", "", "", "", DateTime.Now, 0, 0, 0);

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Patients.ID,Patients.Patient_TC, Persons.FirstName ,Persons.LastName ,
                             Persons.DateOfBirth,Persons.Gender,Persons.Email,Persons.Phone,Patients.State,
                             Patients.StateDate,Patients.Cast,Patients.Payed,Patients.Remind,Persons.Images
                             FROM Patients
                             INNER JOIN Persons on Patients.Person_ID = Persons.ID
                             WHERE Patients.ID=@PateintID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@PateintID", PateintID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patient.ID = (int)reader["ID"];

                    if (reader["FirstName"] != DBNull.Value)
                        patient.FirstName = (string)reader["FirstName"];
                    else patient.FirstName = "";

                    if (reader["LastName"] != DBNull.Value)
                        patient.LastName = (string)reader["LastName"];
                    else patient.LastName = "";

                    if (reader["DateOfBirth"] != DBNull.Value)
                        patient.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else patient.DateOfBirth = DateTime.Now;

                    if (reader["Gender"] != DBNull.Value)
                        patient.Gender = (string)reader["Gender"];
                    else patient.Gender = "";

                    if (reader["Email"] != DBNull.Value)
                        patient.Email = (string)reader["Email"];
                    else patient.Email = "";

                    if (reader["Phone"] != DBNull.Value)
                        patient.Phone = (string)reader["Phone"];
                    else patient.Phone = "";

                    if (reader["Images"] != DBNull.Value)
                        patient.Images = (string)reader["Images"];
                    else patient.Images = "";

                    if (reader["Patient_TC"] != DBNull.Value)
                    { patient.Patients_TC = (string)reader["Patient_TC"]; }
                    else patient.Patients_TC = "";

                    if (reader["State"] != DBNull.Value)
                    { patient.State = (string)reader["State"]; }
                    else patient.State = "";

                    if (reader["StateDate"] != DBNull.Value)
                    { patient.StateDate = (DateTime)reader["StateDate"]; }
                    else patient.StateDate = DateTime.Now;

                    if (reader["Cast"] != DBNull.Value)
                    { patient.Cast = (decimal)reader["Cast"]; }
                    else patient.Cast = 0;

                    if (reader["Payed"] != DBNull.Value)
                    { patient.Payed = (decimal)reader["Payed"]; }
                    else patient.Payed = 0;

                    if (reader["Remind"] != DBNull.Value)
                    { patient.Remind = (decimal)reader["Remind"]; }
                    else patient.Remind = 0;

                    reader.Close();
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return patient;
        }
        public static bool isExsist(string patient_tc) => GetPateint(patient_tc).ID != 0;
        public static int CountPateints()
        {
            int TotalPateints = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"select count(ID) As TotalUsers from Patients";

            SqlCommand cmd = new SqlCommand(Query, con);

            try
            {
                con.Open();
                object result1 = cmd.ExecuteScalar();
                if (result1 != null && int.TryParse(result1.ToString(), out int insertedID))
                    TotalPateints = insertedID;
            }

            catch (Exception ex) { }
            finally { con.Close(); }
            return TotalPateints;
        }
        public static DataTable SearchPatients(string search)
        {
            DataTable Users = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT Patients.ID,Patients.Patient_TC,Persons.FirstName +' '+Persons.LastName as Full_Name,
                            Persons.Gender,Persons.DateOfBirth,Persons.Email,Persons.Phone,Patients.State,
                            Patients.StateDate,Patients.Cast,Patients.Payed,Patients.Remind,Persons.Images
                            FROM Patients
                            INNER JOIN Persons on Patients.Person_ID = Persons.ID
                            where Persons.FirstName Like @SEARCH+'%';";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@SEARCH", search);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Users.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return Users;
        }
    }
}
