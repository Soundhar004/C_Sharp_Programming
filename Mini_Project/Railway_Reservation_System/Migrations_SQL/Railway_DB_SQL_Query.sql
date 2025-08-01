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

INSERT INTO Users (Username, PhoneNumber, Email, PasswordHash, UserType, RegistrationDate)
VALUES ('soundhar',877827832,'dcdfddv@gmail.com',12345,'Passenger',GETDATE());