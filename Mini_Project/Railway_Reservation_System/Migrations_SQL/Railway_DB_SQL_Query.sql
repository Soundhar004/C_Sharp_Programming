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
VALUES (
    '12657', 'Chennai MGR', 'Bengaluru', 'Chennai',
    '22:30', '06:15', '2025-08-06', '7h 45m',
    900, 120, 950.00, 'Superfast', 'On Time'

select * from Trains 

ALTER TABLE Trains
ADD IsDeleted BIT NOT NULL DEFAULT 1;

UPDATE Trains
SET IsDeleted = 0;

