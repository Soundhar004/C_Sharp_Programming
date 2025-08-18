create database Electricity_Billing_DB

 
USE Electricity_Billing_DB;
GO
 
-- 2. Create Admin table
IF OBJECT_ID('Admin', 'U') IS NOT NULL DROP TABLE Admin;
CREATE TABLE Admin (
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    [Password] VARCHAR(50) NOT NULL  -- Note: For real systems, hash passwords!
);
 
-- 3. Create ElectricityBill table
IF OBJECT_ID('ElectricityBill', 'U') IS NOT NULL DROP TABLE ElectricityBill;
CREATE TABLE ElectricityBill (
    consumer_number VARCHAR(20) NOT NULL PRIMARY KEY,
    consumer_name VARCHAR(50) NOT NULL,
    units_consumed INT NOT NULL,
    bill_amount FLOAT NOT NULL
);
 
-- 4. Insert sample admin
INSERT INTO Admin (Username, [Password]) VALUES ('soundhar', 'soundhar123');
 
-- 5. Insert sample electricity bill records
INSERT INTO ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount) VALUES
('EB10101', 'Ravi Kumar', 85, 0),
('EB10202', 'Anjali Menon', 220, 180.0),
('EB10303', 'Suhas Patil', 480, 950.0),
('EB10404', 'Preeti Singh', 720, 2150.0),
('EB10505', 'Manoj Das', 1200, 7300.0);
 
-- Verify data (optional, for testing)
SELECT * FROM Admin;
SELECT * FROM ElectricityBill;