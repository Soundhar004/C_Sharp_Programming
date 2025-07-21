

---1. Write a T-SQL Program to find the factorial of a given number---
DECLARE @Number INT = 5;           
DECLARE @Factorial BIGINT = 1;
DECLARE @Counter INT = 1;

WHILE @Counter <= @Number
BEGIN
    SET @Factorial = @Factorial * @Counter;
    SET @Counter = @Counter + 1;
END

PRINT 'Factorial of ' + CAST(@Number AS VARCHAR) + ' is ' + CAST(@Factorial AS VARCHAR);


---2. Create a stored procedure to generate multiplication table that accepts a number and generates up to a given number---
CREATE PROCEDURE GenerateMultiplicationTable
    @BaseNumber INT,
    @Limit INT
AS
BEGIN
    DECLARE @Counter INT = 1;
    DECLARE @Result VARCHAR(50);

    WHILE @Counter <= @Limit
    BEGIN
        SET @Result = CAST(@BaseNumber AS VARCHAR) + ' x ' + 
                      CAST(@Counter AS VARCHAR) + ' = ' + 
                      CAST(@BaseNumber * @Counter AS VARCHAR);

        PRINT @Result;

        SET @Counter = @Counter + 1;
    END
END;

EXEC GenerateMultiplicationTable @BaseNumber = 5, @Limit = 10;


---3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. 
---   Display the data neatly
CREATE TABLE Student (
    Sid INT PRIMARY KEY,
    Sname VARCHAR(50)
);

CREATE TABLE Marks (
    Mid INT PRIMARY KEY,
    Sid INT,
    Score INT
);

INSERT INTO Student VALUES 
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

INSERT INTO Marks VALUES 
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

CREATE FUNCTION GetStudentStatus (@Score INT)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @Status VARCHAR(10);

    IF @Score >= 50
        SET @Status = 'Pass';
    ELSE
        SET @Status = 'Fail';

    RETURN @Status;
END;
GO

SELECT
    S.Sname AS StudentName,
    M.Score AS Score,
    dbo.GetStudentStatus(M.Score) AS Status
FROM
    Student S
JOIN
    Marks M ON S.Sid = M.Sid
ORDER BY
    S.Sname;
