using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.Services
{
    public class TrainService
    {
        private readonly string constr;

        public TrainService(string connectionString)
        {
            constr = connectionString;
        }

        public List<Train> GetTrainsBetweenStations(string source, string destination)
        {
            var trains = new List<Train>();
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Trains WHERE Sources = @Source AND Destination = @Destination", connection);
                command.Parameters.AddWithValue("@Source", source);
                command.Parameters.AddWithValue("@Destination", destination);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trains.Add(new Train
                        {
                            TrainNumber = (string)reader["TrainNumber"],
                            TrainName = (string)reader["TrainName"],
                            Source = (string)reader["Sources"],
                            Destination = (string)reader["Destination"],
                            AcTicketPrice = (decimal)reader["AcTicketPrice"],
                            GeneralTicketPrice = (decimal)reader["GeneralTicketPrice"]
                        });
                    }
                }
            }
            
            return trains;
        }

        public List<Train> GetAllTrainDetails()
        {
            var trains = new List<Train>();

            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Trains", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read()) // Iterate through all rows in the result set
                    {
                        trains.Add(new Train
                        {
                            TrainNumber = reader["TrainNumber"].ToString(),
                            TrainName = reader["TrainName"].ToString(),
                            Source = reader["Sources"].ToString(),
                            Destination = reader["Destination"].ToString(),
                            AcTicketPrice = (decimal)reader["AcTicketPrice"],
                            GeneralTicketPrice = (decimal)reader["GeneralTicketPrice"],
                            isActive = (bool)reader["IsActive"]
                        });
                    }
                }
            }

            return trains;
        }

        public Train GetTrainDetails(string identifier)
        {
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Trains WHERE TrainNumber = @Identifier OR TrainName = @Identifier", connection);
                command.Parameters.AddWithValue("@Identifier", identifier);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Train
                        {
                            TrainNumber = (string)reader["TrainNumber"],
                            TrainName = (string)reader["TrainName"],
                            Source = (string)reader["Sources"],
                            Destination = (string)reader["Destination"],
                            AcTicketPrice = (decimal)reader["AcTicketPrice"],
                            GeneralTicketPrice = (decimal)reader["GeneralTicketPrice"],
                            isActive = (Boolean)reader["isActive"]
                        };
                    }
                }
            }
            return null;
        }

        public void DeleteTrain(string identifier)
        {
            try
            {
                using (var connection = new SqlConnection(constr))
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM Trains WHERE TrainNumber = @Trainnumber", connection);
                    command.Parameters.AddWithValue("@Trainnumber", identifier);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Train does not exist");
                    }
                    else
                    {
                        Console.WriteLine($"Train {identifier} deleted successfully");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public void UpdateTrain(string identifier)
        {
            try
            {
                using (var connection = new SqlConnection(constr))
                {
                    connection.Open();
                    var command = new SqlCommand("UPDATE Trains SET IsActive = 0 WHERE TrainNumber = @Trainnumber", connection);
                    command.Parameters.AddWithValue("@Trainnumber", identifier);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("Train does not exist");
                    }
                    else
                    {
                        Console.WriteLine($"Train {identifier} modified and set to inactive successfully");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public void AddTrain(Train train)
        {
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Trains (TrainNumber, TrainName, Sources, Destination, AcTicketPrice, GeneralTicketPrice) VALUES (@TrainNumber, @TrainName, @Source, @Destination, @AcTicketPrice, @GeneralTicketPrice)", connection);
                command.Parameters.AddWithValue("@TrainNumber", train.TrainNumber);
                command.Parameters.AddWithValue("@TrainName", train.TrainName);
                command.Parameters.AddWithValue("@Source", train.Source);
                command.Parameters.AddWithValue("@Destination", train.Destination);
                command.Parameters.AddWithValue("@AcTicketPrice", train.AcTicketPrice);
                command.Parameters.AddWithValue("@GeneralTicketPrice", train.GeneralTicketPrice);

                command.ExecuteNonQuery();
            }
        }
    }
}
