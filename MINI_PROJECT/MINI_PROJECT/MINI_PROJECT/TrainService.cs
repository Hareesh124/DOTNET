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
                            GeneralTicketPrice = (decimal)reader["GeneralTicketPrice"]
                        };
                    }
                }
            }
            return null;
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
