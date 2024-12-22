using System;
using System.Data.SqlClient;
using TrainReservationSystem.Models;

namespace TrainReservationSystem.Services
{
    public class CancellationService
    {
        private readonly string constr;

        public CancellationService(string connectionString)
        {
            constr = connectionString;
        }

        public void CancelBooking(int bookingId)
        {
            var booking = GetBookingById(bookingId);
            //Console.WriteLine(booking);
            if (booking == null)
            {
                throw new Exception("Booking not found.");
            }

            // Check if the journey date is in the past
            if (booking.JourneyDate < DateTime.Now.Date)
            {
                throw new InvalidOperationException("Cannot cancel a past booking.");
            }


            try
            {
                var refundAmount = CalculateRefund(booking.JourneyDate, booking.fare);
                using (var connection = new SqlConnection(constr))
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM Bookings WHERE BookingId = @BookingId", connection);
                    command.Parameters.AddWithValue("@BookingId", bookingId);

                    command.ExecuteNonQuery();

                    var cancellationCommand = new SqlCommand("INSERT INTO Cancellations (BookingId, CancellationDate, RefundAmount) VALUES (@BookingId, @CancellationDate, @RefundAmount)", connection);
                    cancellationCommand.Parameters.AddWithValue("@BookingId", bookingId);
                    cancellationCommand.Parameters.AddWithValue("@CancellationDate", DateTime.Now);
                    cancellationCommand.Parameters.AddWithValue("@RefundAmount", refundAmount);

                    cancellationCommand.ExecuteNonQuery();
                    if(refundAmount == booking.fare)
                    {
                        Console.WriteLine("Booking cancelled successfully.Full refund soon");
                    }
                    else
                    {
                        Console.WriteLine("Booking cancelled successfully.Only 75% will be refunded as the date of journey is closer than 5 days");
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

        private Booking GetBookingById(int bookingId)
        {
            using (var connection = new SqlConnection(constr))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Bookings WHERE BookingId = @BookingId", connection);
                command.Parameters.AddWithValue("@BookingId", bookingId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Booking
                        {
                            BookingId = (int)reader["BookingId"],
                            UserId = (int)reader["UserId"],
                            TrainNumber = (string)reader["TrainNumber"],
                            CoachId = (int)reader["CoachId"],
                            PassengerName = (string)reader["PassengerName"],
                            PassengerAge = (int)reader["PassengerAge"],
                            BookingDate = (DateTime)reader["BookingDate"],
                            JourneyDate = (DateTime)reader["JourneyDate"],
                            fare = (decimal)reader["Fare"]
                        };
                    }
                }
            }
            return null;
        }

        private decimal CalculateRefund(DateTime journeyDate, decimal fare)
        {
            var daysBetween = (journeyDate - DateTime.Now).Days;
            decimal calfare = fare;
            if (daysBetween < 0)
            {
                throw new Exception("Cannot cancel a past booking.");
            }

            if (daysBetween >= 10)
            {
                return calfare; // 100% refund
            }
            else
            {
                calfare = calfare - (calfare * 0.25m); //75% refund
                return calfare;
            }
        }
    }
}
