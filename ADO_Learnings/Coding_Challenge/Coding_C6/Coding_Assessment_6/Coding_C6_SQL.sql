use SQL_Assessment


CREATE TABLE Employee_Details (
    EmpId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Salary DECIMAL(10, 2),
    Gender VARCHAR(10)
);

CREATE PROCEDURE Insert_Employee_Details
    @Name VARCHAR(100),
    @givenSalary DECIMAL(10, 2),
    @Gender VARCHAR(10),
    @GeneratedEmpId INT OUTPUT,         -- Output parameter to return the generated EmpId
    @CalculatedSalary DECIMAL(10, 2) OUTPUT -- Output parameter to return the calculated Salary
AS
BEGIN
    SET NOCOUNT ON; -- Suppresses the message indicating the number of rows affected.

    -- Calculate the actual salary (givenSalary - 10%)
    SET @CalculatedSalary = @givenSalary * 0.90;

    -- Insert the new record into the Employee_Details table
    INSERT INTO Employee_Details (Name, Salary, Gender)
    VALUES (@Name, @CalculatedSalary, @Gender);

    -- Retrieve the auto-generated EmpId for the newly inserted row
    SET @GeneratedEmpId = SCOPE_IDENTITY();

    -- You can also select the inserted data if you prefer, but output parameters are better for ADO.NET
    -- SELECT EmpId, Name, Salary, Gender FROM Employee_Details WHERE EmpId = @GeneratedEmpId;
END;
GO

select * from Employee_Details


CREATE PROCEDURE Update_Employee_Salary
    @EmpId INT,
    @UpdatedSalary FLOAT OUTPUT
AS
BEGIN
    -- Update salary
    UPDATE Employee_Details
    SET Salary = Salary + 100
    WHERE EmpId = @EmpId;

    -- Return updated salary
    SELECT @UpdatedSalary = Salary FROM Employee_Details WHERE EmpId = @EmpId;
END;




