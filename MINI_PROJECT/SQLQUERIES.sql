create database Miniproject

 use Miniproject;

-- Create Users table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Pass VARCHAR(50) NOT NULL,
    IsAdmin BIT NOT NULL
);


-- Create Trains table
-- Create Trains table with TrainNumber as the primary key
CREATE TABLE Trains (
    TrainNumber VARCHAR(50)  PRIMARY KEY,
    TrainName VARCHAR(100) NOT NULL,
    Sources VARCHAR(50) NOT NULL,
    Destination VARCHAR(50) NOT NULL,
    AcTicketPrice DECIMAL(10, 2) NOT NULL,
    GeneralTicketPrice DECIMAL(10, 2) NOT NULL
);


-- Create Coaches table
CREATE TABLE Coaches (
    CoachId INT IDENTITY(1,1) PRIMARY KEY,
    TrainNumber VARCHAR(50) FOREIGN KEY REFERENCES Trains(TrainNumber),
    CoachType VARCHAR(10) NOT NULL,
    SeatCount INT NOT NULL,
    AvailableSeats INT NOT NULL
);


-- Create Bookings table
CREATE TABLE Bookings (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    TrainNumber VARCHAR(50) FOREIGN KEY REFERENCES Trains(TrainNumber),
    CoachId INT FOREIGN KEY REFERENCES Coaches(CoachId),
    PassengerName VARCHAR(100) NOT NULL,
    PassengerAge INT NOT NULL,
    BookingDate DATETIME NOT NULL,
    JourneyDate DATETIME NOT NULL
);

CREATE TABLE Cancellations (
    BookingId INT NOT NULL,
	CancellationDate DATETIME,
    RefundAmount INT,
);

ALTER TABLE Bookings
ADD Fare INT;

ALTER TABLE Bookings
DROP COLUMN Fare;

ALTER TABLE Bookings
ADD Fare DECIMAL(10, 2) NOT NULL DEFAULT 0.00;

ALTER TABLE Trains
ADD IsActive BIT NOT NULL DEFAULT 1;


select * from Users
select * from Trains
select * from Coaches
select * from Bookings
select * from Cancellations