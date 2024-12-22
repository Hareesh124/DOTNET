using System;
using System.Data;
using System.Data.SqlClient;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.Services
{
    public class UserService
    {
        private string constr;

        public UserService(string connectionString)
        {
            constr = connectionString;
        }

        public User Authenticate(string username, string password)
        {
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username AND Pass = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserId = (int)reader["UserId"],
                            Username = (string)reader["Username"],
                            IsAdmin = (bool)reader["IsAdmin"]
                        };
                    }
                }
            }
            return null;
        }

        public void Register(string username, string password, bool isAdmin)
        {
                var connection = new SqlConnection(constr);
                connection.Open();
                var command = new SqlCommand("INSERT INTO Users (Username, Pass, IsAdmin) VALUES (@Username, @Password, @IsAdmin)", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@IsAdmin", isAdmin);

                command.ExecuteNonQuery();
           
        }
    }
}
