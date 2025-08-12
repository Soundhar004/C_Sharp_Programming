create database Railway_Reservation_DB


---Creating Table user---

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(512), -- Store hashed password
	UserType NVARCHAR(10) NOT NULL CHECK (UserType IN ('Passenger', 'Admin')), -- 'Passenger' or 'Admin'
    RegistrationDate DATETIME DEFAULT GETDATE(), -- Date of registration
    IsDeleted BIT DEFAULT 0     -- For soft delete functionality
);

select * from Users
select * from users where Username='soundhar'

INSERT INTO Users (Username, PhoneNumber, Email, PasswordHash, UserType, RegistrationDate)
VALUES ('soundhar',877827832,'dcdfddv@gmail.com',12345,'Passenger',GETDATE());




---Creating Admin Table---
CREATE TABLE Admins (
    AdminId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL UNIQUE,
	PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(512) NOT NULL,
    UserType NVARCHAR(50) DEFAULT 'Admin', -- optional for roles like SuperAdmin
    RegistrationDate DATETIME DEFAULT GETDATE(),
    IsDeleted BIT DEFAULT 0
);


select * from Admins


---Creating table train---
CREATE TABLE Trains (
    TrainID INT PRIMARY KEY IDENTITY,
    TrainNumber VARCHAR(10) NOT NULL,
    TrainName VARCHAR(100) NOT NULL,
    SourceStation VARCHAR(100) NOT NULL,
    DestinationStation VARCHAR(100) NOT NULL,
    DepartureTime TIME NOT NULL,
    ArrivalTime TIME NOT NULL,
    TravelDate DATE NOT NULL,
    Duration VARCHAR(50),
    TotalSeats INT NOT NULL,
    AvailableSeats INT NOT NULL,
    Fare DECIMAL(10,2) NOT NULL,
    TrainType VARCHAR(50),           -- e.g. Express, Passenger, Superfast
    Status VARCHAR(50)
);
INSERT INTO Trains (
    TrainNumber, TrainName, SourceStation, DestinationStation,
    DepartureTime, ArrivalTime, TravelDate, Duration,
    TotalSeats, AvailableSeats, Fare, TrainType, Status
)
VALUES
-- Train 1
('12001', 'Shatabdi Express', 'New Delhi', 'Lucknow',
 '06:00', '10:00', '2025-08-08', '4h',
 500, 480, 750.00, 'Express', 'On Time')


INSERT INTO Trains (
    TrainNumber, TrainName, SourceStation, DestinationStation,
    DepartureTime, ArrivalTime, TravelDate, Duration,
    TotalSeats, AvailableSeats, Fare, TrainType, Status
)
VALUES (
    '12657', 'Chennai MGR', 'Bengaluru', 'Chennai',
    '22:30', '06:15', '2025-08-06', '7h 45m',
    900, 120, 950.00, 'Superfast', 'On Time'

select * from Trains 

ALTER TABLE Trains
ADD IsDeleted BIT NOT NULL DEFAULT 1;

UPDATE Trains
SET IsDeleted = 0;

SELECT * FROM TrainClasses 
WHERE TrainId = 3 AND ClassType = 'Sleeper' AND IsActive = 1;
select * from Train




---Reservation Table---
CREATE TABLE Reservation (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-incremented ID
    PassengerName VARCHAR(100) NOT NULL,          -- Name of the passenger
	FromStation VARCHAR(50) NOT NULL,        -- Origin station
    ToStation VARCHAR(50) NOT NULL,          -- Destination station
    TravelDate DATETIME NOT NULL,                 -- Date of travel
    SeatNo VARCHAR(10) NOT NULL,                  -- Seat number
	SeatType VARCHAR(50) NOT NULL                 --seat type
);


INSERT INTO Reservation (PassengerName, FromStation, ToStation, TravelDate, SeatNo, SeatType)
VALUES ('Soundhar', 'Madurai', 'Chennai', GETDATE(), '100','Seater');

select * from Reservation
ALTER TABLE Reservation
ADD BookingDate DATETIME DEFAULT GETDATE(),     -- Automatically sets current date/time
    TotalCost DECIMAL(10,2);                    -- Stores cost with 2 decimal places

ALTER TABLE Reservation
ADD IsDeleted BIT DEFAULT 0;

ALTER TABLE Reservation
ADD TrainID INT;

ALTER TABLE Reservation
ADD CONSTRAINT FK_Reservation_Train
FOREIGN KEY (TrainID) REFERENCES Trains(TrainID);

ALTER TABLE Reservation
DROP CONSTRAINT Reservation_Train;


ALTER TABLE Reservation
ADD IsCancelled BIT DEFAULT 0;

ALTER TABLE Reservation
ADD TrainID INT;

ALTER TABLE Reservation
DROP COLUMN TrainID;

ALTER TABLE Reservation
ALTER COLUMN SeatNo INT;

ALTER TABLE Reservation
ADD CONSTRAINT Reservation_Train
FOREIGN KEY (TrainId) REFERENCES Trains(TrainId);

select * from Reservation
SELECT * FROM Reservation WHERE IsDeleted = 0




---Create Table Cancellations---
CREATE TABLE Cancellations (
    CancellationId INT IDENTITY(1,1) PRIMARY KEY,       -- Unique ID for each cancellation
    BookingId INT NOT NULL,                             -- Reference to the booking
    RefundAmount DECIMAL(10, 2) NOT NULL,               -- Refund issued
    CancellationDate DATETIME NOT NULL,                 -- When the cancellation happened
    TicketCancelled BIT NOT NULL                        -- 1 = Cancelled, 0 = Not Cancelled
);

select * from Cancellations




---Create Train Classess--
CREATE TABLE TrainClasses (
    ClassId INT IDENTITY(1,1) PRIMARY KEY,         -- Unique ID for each class entry
    TrainId INT NOT NULL,                          -- Reference to the train
    ClassType VARCHAR(50) NOT NULL,                -- e.g., Sleeper, AC, Chair Car
    MaxSeats INT NOT NULL,                         -- Total seats in this class
    AvailableSeats INT NOT NULL,                   -- Seats currently available
    CostPerSeat DECIMAL(10,2) NOT NULL,            -- Fare per seat
    IsActive BIT DEFAULT 1                         -- 1 = Active, 0 = Inactive
);

DELETE FROM TrainClasses;


SELECT * FROM TrainClasses WHERE TrainId = 1 AND ClassType = 'sleeper' AND IsActive = 1

INSERT INTO TrainClasses(TrainId, ClassType, MaxSeats, AvailableSeats, CostPerSeat, IsActive) VALUES
(1, 'Sleeper', 100, 80, 500.00, 1),
(1, '2nd AC', 50, 45, 1200.00, 1),
(2, '3rd AC', 60, 60, 900.00, 1);

select * from TrainClasses

ALTER TABLE TrainClasses
ADD CONSTRAINT FK_Reservation_Train
FOREIGN KEY (TrainId) REFERENCES Trains(TrainId);

ALTER TABLE Cancellations
ADD CONSTRAINT Cancellations_Reservations
FOREIGN KEY (BookingId) REFERENCES Reservation(BookingId);




---UPDATE TrainClasses 
---SET AvailableSeats = AvailableSeats + 20
---WHERE TrainId =  AND ClassType = @ClassType AND IsActive = 1";


select * from Users

select * from Admins

select * from Trains 

select * from Reservation

select * from Cancellations

select * from TrainClasses