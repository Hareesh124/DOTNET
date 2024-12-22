using System;
using System.Collections.Generic;
using TrainReservationSystem.Models;
using TrainReservationSystem.Services;

namespace TrainReservationSystem
{
    class Program
    {
        static string constr = "data source=ICS-LT-GSRQ4D3;initial catalog=Miniproject;Trusted_Connection=True";
        static int flag = 0;
        static void Main(string[] args)
        {
            var userService = new UserService(constr);
            var trainService = new TrainService(constr);
            var coachService = new CoachService(constr);
            var bookingService = new BookingService(constr);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Welcome to Indian Railways [server may be down anytime book ASAP :) ]");
                Console.WriteLine("If you are a new user, please register. If you have already registered, please log in.");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Login(userService, trainService, coachService, bookingService);
                }
                else if (choice == "2")
                {
                    Register(userService);
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }

        private static void Login(UserService userService, TrainService trainService, CoachService coachService, BookingService bookingService)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            var user = userService.Authenticate(username, password);

            if (user == null)
            {
                Console.WriteLine("Invalid username or password.");
                return;
            }

            if (user.IsAdmin)
            {
                AdminMenu(userService, trainService, coachService, bookingService);
            }
            else
            {
                UserMenu(user, trainService, coachService, bookingService);
            }
        }

        private static void Register(UserService userService)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            Console.Write("Are you an admin? (yes/no): ");
            var isAdmin = Console.ReadLine().ToLower() == "yes";

            userService.Register(username, password, isAdmin);

            Console.WriteLine("Registration successful.");
        }

        private static void AdminMenu(UserService userService, TrainService trainService, CoachService coachService, BookingService bookingService)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. View trains between two stations");
                Console.WriteLine("2. View train details");
                Console.WriteLine("3. Add train");
                Console.WriteLine("4. Add coach to train");
                Console.WriteLine("5. View all bookings");
                Console.WriteLine("6. Cancel booking");
                Console.WriteLine("7. Logout");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter source station: ");
                    var source = Console.ReadLine();
                    Console.Write("Enter destination station: ");
                    var destination = Console.ReadLine();
                    var trains = trainService.GetTrainsBetweenStations(source, destination);
                    int isEmpty = trains.Count;
                    //var train = new List<Train>();

                    // Access and modify flag through the property
                    if (isEmpty == 0)
                    {
                        Console.WriteLine("Sorry there are no trains running in the current source and destination");

                    }
                    else
                    {
                        foreach (var train in trains)
                        {
                            Console.WriteLine($"Train Number: {train.TrainNumber}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, AC Price: {train.AcTicketPrice}, General Price: {train.GeneralTicketPrice}");
                        }
                    }
                    //foreach (var train in trains)
                    //    {
                    //        if (train.Flag == 0)
                    //        {
                    //            Console.WriteLine($"Train Number: {train.TrainNumber}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, AC Price: {train.AcTicketPrice}, General Price: {train.GeneralTicketPrice}");
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("Sorry there is no available trains for the given route");
                            
                    //        }
                            
                    //    }                                           
                }
                else if (choice == "2")
                {
                    Console.Write("Enter train number or name: ");
                    var identifier = Console.ReadLine();
                    var train = trainService.GetTrainDetails(identifier);
                    if (train != null)
                    {
                        Console.WriteLine($"Train Number: {train.TrainNumber}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, AC Price: {train.AcTicketPrice}, General Price: {train.GeneralTicketPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Train not found.");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter train number: ");
                    var trainNumber = Console.ReadLine();
                    Console.Write("Enter train name: ");
                    var trainName = Console.ReadLine();
                    Console.Write("Enter source station: ");
                    var source = Console.ReadLine();
                    Console.Write("Enter destination station: ");
                    var destination = Console.ReadLine();
                    Console.Write("Enter AC ticket price: ");
                    var acTicketPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter General ticket price: ");
                    var generalTicketPrice = decimal.Parse(Console.ReadLine());

                    trainService.AddTrain(new Train
                    {
                        TrainNumber = trainNumber,
                        TrainName = trainName,
                        Source = source,
                        Destination = destination,
                        AcTicketPrice = acTicketPrice,
                        GeneralTicketPrice = generalTicketPrice
                    });

                    Console.WriteLine("Train added successfully.");
                }
                else if (choice == "4")
                {
                    Console.Write("Enter train number: ");
                    var trainNumber = Console.ReadLine();
                    Console.Write("Enter coach type (AC/General): ");
                    var coachType = Console.ReadLine();
                    Console.Write("Enter seat count: ");
                    var seatCount = int.Parse(Console.ReadLine());
                    Console.Write("Enter available seats: ");
                    var availableSeats = int.Parse(Console.ReadLine());

                    coachService.AddCoach(new Coach
                    {
                        TrainNumber = trainNumber,
                        CoachType = coachType,
                        SeatCount = seatCount,
                        AvailableSeats = availableSeats
                    });

                    Console.WriteLine("Coach added successfully.");
                }
                else if (choice == "5")
                {
                    var bookings = bookingService.GetAllBookings();
                    foreach (var booking in bookings)
                    {
                        Console.WriteLine($"Booking ID: {booking.BookingId}, Train Number: {booking.TrainNumber}, Coach ID: {booking.CoachId}, Passenger Name: {booking.PassengerName}, Age: {booking.PassengerAge}, Booking Date: {booking.BookingDate}, Journey Date: {booking.JourneyDate}");
                    }
                }
                else if (choice == "6")
                {
                    Console.Write("Enter booking ID to cancel: ");
                    var bookingId = int.Parse(Console.ReadLine());
                    try
                    {
                        bookingService.CancelBooking(bookingId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error cancelling booking: {ex.Message}");
                    }
                }
                else if (choice == "7")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }

        private static void UserMenu(User user, TrainService trainService, CoachService coachService, BookingService bookingService)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("1. View trains between two stations");
                Console.WriteLine("2. View train details");
                Console.WriteLine("3. Book ticket");
                Console.WriteLine("4. Cancel ticket");
                Console.WriteLine("5. View your bookings");
                Console.WriteLine("6. Logout");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter source station: ");
                    var source = Console.ReadLine();
                    Console.Write("Enter destination station: ");
                    var destination = Console.ReadLine();
                    var trains = trainService.GetTrainsBetweenStations(source, destination);
                    int isEmpty = trains.Count;
                    //var train = new List<Train>();

                    // Access and modify flag through the property
                    if (isEmpty == 0)
                    {
                        Console.WriteLine("Sorry there are no trains running in the given source and destination");

                    }
                    else
                    {
                        foreach (var train in trains)
                        {
                            Console.WriteLine($"Train Number: {train.TrainNumber}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, AC Price: {train.AcTicketPrice}, General Price: {train.GeneralTicketPrice}");
                        }
                    }
                    //foreach (var train in trains)
                    //{
                    //    if(train.Flag == 0)
                    //    {
                    //        Console.WriteLine(train.Flag);
                    //        Console.WriteLine($"Train Number: {train.TrainNumber}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, AC Price: {train.AcTicketPrice}, General Price: {train.GeneralTicketPrice}");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine(train.Flag);
                    //        Console.WriteLine("Sorry there are no trains running in the current ");
                    //    }
                    //}
                }
                else if (choice == "2")
                {
                    Console.Write("Enter train number or name: ");
                    var identifier = Console.ReadLine();
                    var train = trainService.GetTrainDetails(identifier);
                    if (train != null)
                    {
                        Console.WriteLine($"Train Number: {train.TrainNumber}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, AC Price: {train.AcTicketPrice}, General Price: {train.GeneralTicketPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Train not found.");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter train number: ");
                    var trainNumber = Console.ReadLine();
                    Console.Write("Enter number of tickets to book: ");
                    var ticketCount = int.Parse(Console.ReadLine());

                    for (int i = 0; i < ticketCount; i++)
                    {
                        Console.Write("Enter passenger name: ");
                        var passengerName = Console.ReadLine();
                        Console.Write("Enter passenger age: ");
                        var passengerAge = int.Parse(Console.ReadLine());
                        Console.Write("Enter coach type (AC/General): ");
                        var coachType = Console.ReadLine();

                        var train = trainService.GetTrainDetails(trainNumber);
                        if (train == null)
                        {
                            Console.WriteLine("Train not found.");
                            return;
                        }

                        var ticketPrice = coachType.Equals("AC", StringComparison.OrdinalIgnoreCase) ? train.AcTicketPrice : train.GeneralTicketPrice;
                        decimal tp = ticketPrice;
                        var coach = coachService.GetCoachByTrainNumberAndType(trainNumber, coachType);
                        if (coach == null || coach.AvailableSeats <= 0)
                        {
                            Console.WriteLine("No available seats for the selected coach type.");
                            return;
                        }

                        Console.Write("Enter journey date (yyyy-mm-dd): ");
                        var journeyDate = DateTime.Parse(Console.ReadLine());

                        var booking = new Booking
                        {
                            UserId = user.UserId,
                            TrainNumber = trainNumber,
                            CoachId = coach.CoachId,
                            PassengerName = passengerName,
                            PassengerAge = passengerAge,
                            BookingDate = DateTime.Now,
                            JourneyDate = journeyDate,
                            fare = tp
                        };
                        flag = bookingService.BookTicket(booking,flag);
                        coachService.UpdateAvailableSeats(coach.CoachId, coach.AvailableSeats - 1);
                        if(flag == 0)
                        {
                            //Console.WriteLine(flag);
                            Console.WriteLine($"Ticket booked successfully. Price: {ticketPrice}");
                        }
                 
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Enter booking ID to cancel: ");
                    var bookingId = int.Parse(Console.ReadLine());
                    bookingService.CancelBooking(bookingId);
                    //try
                    //{
                    //    bookingService.CancelBooking(bookingId);
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine($"Error cancelling booking: {ex.Message}");
                    //}
                }
                else if (choice == "5")
                {
                    var bookings = bookingService.GetBookingsByUser(user.UserId);
                    foreach (var booking in bookings)
                    {
                        Console.WriteLine($"Booking ID: {booking.BookingId}, Train Number: {booking.TrainNumber}, Coach ID: {booking.CoachId}, Passenger Name: {booking.PassengerName}, Age: {booking.PassengerAge}, Booking Date: {booking.BookingDate.ToString("yyyy-MM-dd HH:mm:ss")}, Journey Date: {booking.JourneyDate.ToString("yyyy-MM-dd HH:mm:ss")}, Fare: {booking.fare}");
                    }
                }
                else if (choice == "6")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
        }
    }
}
