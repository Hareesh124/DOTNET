using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TrainReservationSystem.Models;
using TrainReservationSystem.Services;

namespace TrainReservationSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public string TrainNumber { get; set; }
        public int CoachId { get; set; }
        public string PassengerName { get; set; }
        public int PassengerAge { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime JourneyDate { get; set; }
        public decimal fare { get; set; }
    }

    public class InvalidJourneyDateException : Exception
    {
        public InvalidJourneyDateException(string message) : base(message) { }
    }
}

namespace TrainReservationSystem.Services
{

    public class BookingService
    {
        private readonly string constr;

        public BookingService(string connectionString)
        {
            constr = connectionString;
        }

        public int BookTicket(Booking booking, int flag)
        {
            try
            {
                // Check if the journey date is in the past
                if (booking.JourneyDate < DateTime.UtcNow.Date)
                {
                    throw new InvalidJourneyDateException("The journey date cannot be in the past.");
                }

                using (var connection = new SqlConnection(constr))
                {
                    connection.Open();
                    var command = new SqlCommand("INSERT INTO Bookings (UserId, TrainNumber, CoachId, PassengerName, PassengerAge, BookingDate, JourneyDate, Fare ) VALUES (@UserId, @TrainNumber, @CoachId, @PassengerName, @PassengerAge, @BookingDate, @JourneyDate, @Fare)", connection);
                    command.Parameters.AddWithValue("@UserId", booking.UserId);
                    command.Parameters.AddWithValue("@TrainNumber", booking.TrainNumber);
                    command.Parameters.AddWithValue("@CoachId", booking.CoachId);
                    command.Parameters.AddWithValue("@PassengerName", booking.PassengerName);
                    command.Parameters.AddWithValue("@PassengerAge", booking.PassengerAge);
                    command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                    command.Parameters.AddWithValue("@JourneyDate", booking.JourneyDate); 
                    command.Parameters.AddWithValue("@Fare", booking.fare);


                    command.ExecuteNonQuery();
                }
            }
            catch (InvalidJourneyDateException ex)
            {
                // Handle invalid journey date error
                Console.WriteLine($"Invalid entry: {ex.Message}. Please ensure the journey date is in the future.");
                flag = 1;
            }

            catch (Exception ex)
            {
                // Handle general errors
                Console.WriteLine($"An unexpected error occurred: {ex.Message}. Please try again later.");
                flag = 1;
            }
            return flag;
        }

        public List<Booking> GetAllBookings()
        {
            var bookings = new List<Booking>();
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Bookings", connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("The Bookings table is empty.");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            bookings.Add(NewMethod(reader));
                        }
                    }
                    
                }
               
            }

            // Display bookings with formatted date
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingId}, Train Number: {booking.TrainNumber}, Journey Date: {booking.JourneyDate.ToString("yyyy-MM-dd")}");
            }

            return bookings;
        }

        private static Booking NewMethod(SqlDataReader reader)
        {
            return new Booking
            {
                BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                TrainNumber = reader.GetString(reader.GetOrdinal("TrainNumber")),
                CoachId = reader.GetInt32(reader.GetOrdinal("CoachId")),
                PassengerName = reader.GetString(reader.GetOrdinal("PassengerName")),
                PassengerAge = reader.GetInt32(reader.GetOrdinal("PassengerAge")),
                BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                JourneyDate = reader.GetDateTime(reader.GetOrdinal("JourneyDate")) 

            };
        }

        public void CancelBooking(int bookingId)
        {
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var cancel = new CancellationService(constr);
                cancel.CancelBooking(bookingId);
                //var command = new SqlCommand("DELETE FROM Bookings WHERE BookingId = @BookingId", connection);
                //command.Parameters.AddWithValue("@BookingId", bookingId);

                //int rowsAffected = command.ExecuteNonQuery();

                //if (rowsAffected == 0)
                //{
                //    Console.WriteLine("Invalid Booking ID");
                //}
                //else
                //{
                //    var cancel = new CancellationService(constr);
                //    cancel.CancelBooking(bookingId);
                //    //Console.WriteLine("Booking cancelled successfully.It  will get refunded soon");
                //}
            }
        }

        public List<Booking> GetBookingsByUser(int userId)
        {
            var bookings = new List<Booking>();
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Bookings WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", userId);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("You don't havee any bookings!!!");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            bookings.Add(new Booking
                            {
                                BookingId = reader.GetInt32(reader.GetOrdinal("BookingId")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                TrainNumber = reader.GetString(reader.GetOrdinal("TrainNumber")),
                                CoachId = reader.GetInt32(reader.GetOrdinal("CoachId")),
                                PassengerName = reader.GetString(reader.GetOrdinal("PassengerName")),
                                PassengerAge = reader.GetInt32(reader.GetOrdinal("PassengerAge")),
                                BookingDate = reader.GetDateTime(reader.GetOrdinal("BookingDate")),
                                JourneyDate = reader.GetDateTime(reader.GetOrdinal("JourneyDate")),
                                fare = reader.GetDecimal(reader.GetOrdinal("Fare"))
                            });
                        }
                    }                    
                }
            }

            // Display bookings with formatted date
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingId}, Train Number: {booking.TrainNumber}, Journey Date: {booking.JourneyDate.ToString("yyyy-MM-dd")},Fare: {booking.fare}");
            }

            return bookings;
        }
    }
}
