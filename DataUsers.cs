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
    public class DataUsers
    {
        private static int getPersonId(string userName)
        {
            int personId = -1;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataAccessSettings.ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select Persons.ID from Persons join Users on Users.Person_ID = Persons.ID where Users.UserName = @userName";
                cmd.Parameters.AddWithValue("@userName", userName);

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
        private static int getPersonIdByUserID(int id)
        {
            int personId = -1;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = DataAccessSettings.ConnectionString;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select Persons.ID from Persons join Users on Users.Person_ID = Persons.ID where Users.ID = @id";
                cmd.Parameters.AddWithValue("@id", id);

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
        public static DataTable GetUsers()
        {
            DataTable Users = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT Users.ID, Persons.FirstName +' '+Persons.LastName as Full_Name,
                            Users.UserName ,Users.Password,Users.UserType,Persons.DateOfBirth,
                            Persons.Gender,Persons.Email,Persons.Phone,Persons.Images 
                            FROM Users
                            INNER JOIN Persons on Users.Person_ID = Persons.ID ;";
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

       public static int AddNewUser(User user) 
        {
            int UserID = -1;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO Persons(FirstName,LastName,DateOfBirth,Gender,Email,Phone,Images)
                           VALUES (@firstname,@lastname,@dateofbirth,@gender,@email,@phone,@images)
                           SELECT SCOPE_IDENTITY();";
                if (user.FirstName != "")
                    cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                else
                    cmd.Parameters.AddWithValue("@firstname", System.DBNull.Value);
                if (user.LastName != "")
                    cmd.Parameters.AddWithValue("@lastname", user.LastName);
                else
                    cmd.Parameters.AddWithValue("@lastname", System.DBNull.Value);

                cmd.Parameters.AddWithValue("@dateofbirth", user.DateOfBirth);

                if (user.Gender != "")
                    cmd.Parameters.AddWithValue("@gender", user.Gender);
                else
                    cmd.Parameters.AddWithValue("@gender", System.DBNull.Value);
                if (user.Email != "")
                    cmd.Parameters.AddWithValue("@email", user.Email);
                else
                    cmd.Parameters.AddWithValue("@email", System.DBNull.Value);
                if (user.Phone != "")
                    cmd.Parameters.AddWithValue("@phone", user.Phone);
                else
                    cmd.Parameters.AddWithValue("@phone", System.DBNull.Value);

                if (user.Images != "")
                    cmd.Parameters.AddWithValue("@images", user.Images);
                else
                    cmd.Parameters.AddWithValue("@images", System.DBNull.Value);

                con.Open();

                object result = cmd.ExecuteScalar();
                int.TryParse(result.ToString(), out int insertedPersonID);

                cmd.CommandText = @"INSERT INTO Users(UserName,Password,UserType,Person_ID)
                           VALUES (@username,@password,@usertype,@person_id)
                           SELECT SCOPE_IDENTITY();";

                if (user.UserName != "")
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                else
                    cmd.Parameters.AddWithValue("@UserName", System.DBNull.Value);

                if (user.Password != "")
                    cmd.Parameters.AddWithValue("@PassWord", user.Password);
                else
                    cmd.Parameters.AddWithValue("@PassWord", System.DBNull.Value);

                if (user.UserType != "")
                    cmd.Parameters.AddWithValue("@UserType", user.UserType);
                else
                    cmd.Parameters.AddWithValue("@UserType", System.DBNull.Value);

                cmd.Parameters.AddWithValue("@Person_ID", insertedPersonID);

                object result1 = cmd.ExecuteScalar();
                if (result1 != null && int.TryParse(result1.ToString(), out int insertedID))
                    UserID = insertedID;
            }

            catch (Exception ex) { }
            finally { con.Close(); }
            return UserID;
        }
        public static bool DeleteUser(string userName)
        {
            int rowsAffected = 0;

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            int personId = getPersonId(userName);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con ;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM Users WHERE UserName=@userName;";
                cmd.Parameters.AddWithValue("userName", userName);

                con.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"DELETE FROM Persons WHERE ID = @personId";
                cmd.Parameters.AddWithValue("personId", personId);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);
        }

        public static bool UpDateUser(User user)
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
                                  Gender=@gender
                                  Email=@email,
                                  Phone=@phone,
                                  Images=@images
                                  WHERE ID=@personid;";

                cmd.Parameters.AddWithValue("personid", getPersonIdByUserID(user.Id));

                if (user.FirstName != "")
                    cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                else
                    cmd.Parameters.AddWithValue("@firstname", System.DBNull.Value);
                if (user.LastName != "")
                    cmd.Parameters.AddWithValue("@lastname", user.LastName);
                else
                    cmd.Parameters.AddWithValue("@lastname", System.DBNull.Value);

                cmd.Parameters.AddWithValue("@dateofbirth", user.DateOfBirth);

                if (user.Gender != "")
                    cmd.Parameters.AddWithValue("@gender", user.Gender);
                else
                    cmd.Parameters.AddWithValue("@gender", System.DBNull.Value);
                if (user.Email != "")
                    cmd.Parameters.AddWithValue("@email", user.Email);
                else
                    cmd.Parameters.AddWithValue("@email", System.DBNull.Value);
                if (user.Phone != "")
                    cmd.Parameters.AddWithValue("@phone", user.Phone);
                else
                    cmd.Parameters.AddWithValue("@phone", System.DBNull.Value);

                if (user.Images != "")
                    cmd.Parameters.AddWithValue("@images", user.Images);
                else
                    cmd.Parameters.AddWithValue("@images", System.DBNull.Value);

                con.Open();

                cmd.ExecuteNonQuery();

                cmd.CommandText = @"UPDATE Users 
                                  SET
                                  UserName=@username,
                                  Password=@password,
                                  UserType=@usertype
                                  WHERE ID=ID;";

                cmd.Parameters.AddWithValue("ID", user.Id);
                if (user.UserName != "")
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                else
                    cmd.Parameters.AddWithValue("@UserName", System.DBNull.Value);

                if (user.Password != "")
                    cmd.Parameters.AddWithValue("@PassWord", user.Password);
                else
                    cmd.Parameters.AddWithValue("@PassWord", System.DBNull.Value);

                if (user.UserType != "")
                    cmd.Parameters.AddWithValue("@UserType", user.UserType);
                else
                    cmd.Parameters.AddWithValue("@UserType", System.DBNull.Value);
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return (rowsAffected > 0);
        }
        public static User GetUsers(string username)
        {
            User user = new User("", "", DateTime.Now, "", "", "", "", "", "", "");

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

             string Query = @"SELECT Users.ID, Persons.FirstName ,Persons.LastName ,
                            Users.UserName ,Users.Password,Users.UserType,Persons.DateOfBirth,
                            Persons.Gender,Persons.Email,Persons.Phone,Persons.Images 
                            FROM Users
                            INNER JOIN Persons on Users.Person_ID = Persons.ID
                            WHERE Users.UserName=username;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("username",username);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    if (reader["FirstName"] != DBNull.Value)
                        user.FirstName = (string)reader["FirstName"];
                    else user.FirstName = "";

                    if (reader["LastName"] != DBNull.Value)
                        user.LastName = (string)reader["LastName"];
                    else user.LastName = "";

                    if (reader["DateOfBirth"] != DBNull.Value)
                        user.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else user.DateOfBirth = DateTime.Now;

                    if (reader["Gender"] != DBNull.Value)
                        user.Gender = (string)reader["Gender"];
                    else user.Gender = "";

                    if (reader["Email"] != DBNull.Value)
                        user.Email = (string)reader["Email"];
                    else user.Email = "";

                    if (reader["Phone"] != DBNull.Value)
                        user.Phone = (string)reader["Phone"];
                    else user.Phone = "";

                    if (reader["Images"] != DBNull.Value)
                        user.Images = (string)reader["Images"];
                    else user.Images = "";

                    if (reader["UserName"] != DBNull.Value)
                    { user.UserName = (string)reader["UserName"]; }
                    else user.UserName = "";

                    if (reader["Password"] != DBNull.Value)
                    { user.Password = (string)reader["Password"]; }
                    else user.Password = "";

                    if (reader["UserType"] != DBNull.Value)
                    { user.UserType = (string)reader["UserType"]; }
                    else user.UserType = "";
                    reader.Close(); 
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return user;
        }
        public static User GetUsers(int UserID)
        {
            User user = new User("", "", DateTime.Now, "", "", "", "", "", "", "");

            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"SELECT Users.ID, Persons.FirstName ,Persons.LastName ,
                            Users.UserName ,Users.Password,Users.UserType,Persons.DateOfBirth,
                            Persons.Gender,Persons.Email,Persons.Phone,Persons.Images 
                            FROM Users
                            INNER JOIN Persons on Users.Person_ID = Persons.ID
                            WHERE Users.ID=@UserID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.ID = (int)reader["ID"];

                    if (reader["FirstName"] != DBNull.Value)
                        user.FirstName = (string)reader["FirstName"];
                    else user.FirstName = "";

                    if (reader["LastName"] != DBNull.Value)
                        user.LastName = (string)reader["LastName"];
                    else user.LastName = "";

                    if (reader["DateOfBirth"] != DBNull.Value)
                        user.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    else user.DateOfBirth = DateTime.Now;

                    if (reader["Gender"] != DBNull.Value)
                        user.Gender = (string)reader["Gender"];
                    else user.Gender = "";

                    if (reader["Email"] != DBNull.Value)
                        user.Email = (string)reader["Email"];
                    else user.Email = "";

                    if (reader["Phone"] != DBNull.Value)
                        user.Phone = (string)reader["Phone"];
                    else user.Phone = "";

                    if (reader["Images"] != DBNull.Value)
                        user.Images = (string)reader["Images"];
                    else user.Images = "";

                    if (reader["UserName"] != DBNull.Value)
                    { user.UserName = (string)reader["UserName"]; }
                    else user.UserName = "";

                    if (reader["Password"] != DBNull.Value)
                    { user.Password = (string)reader["Password"]; }
                    else user.Password = "";

                    if (reader["UserType"] != DBNull.Value)
                    { user.UserType = (string)reader["UserType"]; }
                    else user.UserType = "";
                    reader.Close();
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }
            return user;
        }
        public static bool Login(string Username, string Password)
        {
            if (String.IsNullOrEmpty(Username))
                return false;

            User user = GetUsers(Username);
            return user.UserName == Username && user.Password == Password ? true : false;
        }

        public static bool isExsist(string userName) => String.IsNullOrEmpty(GetUsers(userName).UserName) ? false : true;

        public static int CountUsers()
        {
            int TotalUsers = 0;
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);

            string Query = @"select count(ID) As TotalUsers from Users";

            SqlCommand cmd = new SqlCommand(Query, con);

            try
            {
                con.Open();
                object result1 = cmd.ExecuteScalar();
                if (result1 != null && int.TryParse(result1.ToString(), out int insertedID))
                    TotalUsers = insertedID;
            }

            catch (Exception ex) { }
            finally { con.Close(); }
            return TotalUsers;
        }

        public static DataTable SearchUsers(string search)
        {
            DataTable Users = new DataTable();
            SqlConnection con = new SqlConnection(DataAccessSettings.ConnectionString);
            string Query = @"SELECT Users.ID, Persons.FirstName +' '+Persons.LastName as Full_Name,
                            Users.UserName ,Users.Password,Users.UserType,Persons.DateOfBirth,
                            Persons.Gender,Persons.Email,Persons.Phone,Persons.Images 
                            FROM Users
                            INNER JOIN Persons on Users.Person_ID = Persons.ID 
                            where Persons.FirstName Like  @SEARCH+'%'";
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
