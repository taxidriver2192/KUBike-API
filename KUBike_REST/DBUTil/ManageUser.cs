using lib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KUBike_REST.DBUTil
{
    public class ManageUser
    {
        private const string connString = @"Server=tcp:mort-db-server.database.windows.net,1433;Initial Catalog = mort - db; Persist Security Info=False;User ID = mort - admin; Password=Secret1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

        private const string GET_ALL_SQL = "select * from Users";
        public IList<User> HentAlle()
        {
            IList<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(GET_ALL_SQL, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(ReadNextUser(reader));
                    }
                }
            
            }
            return users;
        }

        private const string GET_ONE_SQL = "select * from Users where id = @Id";
        public User HentEn(int id)
        {
            User user = new User();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(GET_ONE_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = ReadNextUser(reader);
                    }
                }
            }
            return user;
        }

        private const string INSERT_SQL = "insert into User(user_firstname, user_lastname, user_email, user_password, user_mobile, account_status_id) values (@fname, @lname, @email, @password, @mobile, @asid)";
        public bool OpretUser(User user)
        {
            bool OK = true;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(INSERT_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@fname", user.User_firstname);
                    cmd.Parameters.AddWithValue("@lname", user.User_lastname);
                    cmd.Parameters.AddWithValue("@email", user.User_email);
                    cmd.Parameters.AddWithValue("@password", user.User_password);
                    cmd.Parameters.AddWithValue("@mobile", user.User_mobile);
                    cmd.Parameters.AddWithValue("@asid", user.Account_status_id);

                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        OK = rows == 1;
                    }
                    catch (Exception ex)
                    {
                        OK = false;
                    }
                }
            }
            return OK;
        }
        private User ReadNextUser(SqlDataReader reader)
        {
            User user = new User();

            user.User_id = reader.GetInt32(0);
            user.User_firstname = reader.GetString(1);
            user.User_lastname = reader.GetString(2);
            user.User_email = reader.GetString(3);
            user.User_password = reader.GetString(4);
            user.User_mobile = reader.GetInt32(5);
            user.Account_status_id = reader.GetInt32(6);


            return user;
        }

    }
}
