using Esercitazione_17.Models;
using System.Data;
using System.Data.SqlClient;

namespace Esercitazione_17.Data
{
    public class UserDao
    {
        private readonly string connectionString;

        public UserDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Users WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Password = reader.GetString(reader.GetOrdinal("Password"))
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}
