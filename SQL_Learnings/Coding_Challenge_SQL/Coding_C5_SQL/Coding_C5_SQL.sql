use SQL_Assessment
use Sql_Learnings

---1. Write a query to display your birthday( day of week)---

CREATE FUNCTION GetDayOfWeek (@date DATE)
RETURNS VARCHAR(10)
AS
BEGIN
    RETURN DATENAME(WEEKDAY, @date)
END;

SELECT dbo.GetDayOfWeek('1995-07-23') AS DayOfWeek;


---2. Write a query to display your age in days---

CREATE FUNCTION GetAgeInDays (@birthdate DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @birthdate, GETDATE());
END;

SELECT dbo.GetAgeInDays('1995-07-23') AS AgeInDays;





---3. Write a query to display all employees information those who joined before 5 years in the current month
---   (Hint : If required update some HireDates in your EMP table of the assignment)

update EMP
set hiredate = '2017-07-01'
where empno =7521;
 
 
select *
from EMP
where 
    datediff(year, hiredate, getdate()) >= 5
    and month(hiredate) = month(getdate());






---4.Create table Employee with empno, ename, sal, doj columns or use your emp table and perform 
---the following operations in a single transaction

BEGIN TRANSACTION;

CREATE TABLE Employee (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    sal DECIMAL(10, 2),
    doj DATE
);

---a. First insert 3 rows
INSERT INTO Employee (empno, ename, sal, doj) VALUES
(101, 'Karthik', 50000, '2021-04-10'),
(102, 'Tharun', 60000, '2022-06-15'),
(103, 'Thiru', 55000, '2023-01-20');

---Backup---
SELECT * INTO DeletedEmpBackup FROM Employee WHERE empno = 101;


select * from EMPLOYEE

---b. Update the second row sal with 15% increment
UPDATE Employee
SET sal = sal * 1.15
WHERE empno = 102;

select * from EMPLOYEE
---c. Delete first row.
DELETE FROM Employee WHERE empno = 101;

select * from EMPLOYEE

COMMIT;

---After completing above all actions, recall the deleted row without losing increment of second row.
INSERT INTO Employee
SELECT * FROM DeletedEmpBackup;


---5. Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
---a.For Deptno 10 employees 15% of sal as bonus.
---b.For Deptno 20 employees  20% of sal as bonus
---c.For Others employees 5%of sal as bonus
create function calbonus (@sal decimal(7,2), @deptno int)
returns decimal(7,2)
as
begin
    declare @bonus decimal(7,2);
 
    if @deptno = 10
        set @bonus = @sal * 0.15;
    else if @deptno = 20
        set @bonus = @sal * 0.20;
    else
        set @bonus = @sal * 0.05;
 
    return @bonus;
end;
 
select 
    EMPNO, 
    ename, 
    sal, 
    deptno,
    dbo.calbonus(sal, deptno) as bonus
from EMP;



--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
create or alter procedure updatesalary
as
begin
    set nocount on;
 
    update EMP
    set sal = sal + 500
    where deptno = (
        select deptno from DEPT where DNAME = 'SALES'
    )
    and sal < 1500;
end;
 
exec updatesalary;

select * from EMP where DEPTNO='30'
