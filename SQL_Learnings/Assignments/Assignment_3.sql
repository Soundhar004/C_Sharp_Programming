use Sql_Learnings

---Creating a table Department---
CREATE TABLE DEPT (
    DEPTNO INT PRIMARY KEY,
    DNAME VARCHAR(20),
    LOC VARCHAR(20)
)

---Insert the data into Department---
INSERT INTO DEPT (DEPTNO, DNAME, LOC) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON')

select * from DEPT


---Creating a table Employee---
CREATE TABLE EMP (
    EMPNO INT PRIMARY KEY,
    ENAME VARCHAR(20),
    JOB VARCHAR(20),
    MGR_ID INT,
    HIREDATE DATE,
    SAL DECIMAL(10, 2),
    COMM DECIMAL(10, 2),
    DEPTNO INT,
    FOREIGN KEY (DEPTNO) REFERENCES DEPT(DEPTNO)
)

---Insert the data into Employee---
INSERT INTO EMP (EMPNO, ENAME, JOB, MGR_ID, HIREDATE, SAL, COMM, DEPTNO) VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10)


---1. Retrieve a list of MANAGERS---
select * from EMP WHERE JOB = 'MANAGER';

---2. Find out the names and salaries of all employees earning more than 1000 permonth---
SELECT ename, sal FROM EMP WHERE sal > 1000;

---3. Display the names and salaries of all employees except JAMES---
SELECT ename, sal
FROM EMP
WHERE ename != 'JAMES';

-- 4. Find out the details of employees whose names begin with ‘S’.
SELECT *
FROM EMP
WHERE ename LIKE 'S%';

-- 5. Find out the names of all employees that have ‘A’ anywhere in their name.
SELECT ename
FROM EMP
WHERE ename LIKE '%A%';

-- 6. Find out the names of all employees that have ‘L’ as their third character in their name.
SELECT ename
FROM EMP
WHERE ename LIKE '__L%';

-- 7. Compute daily salary of JONES.
SELECT ename, sal / 30 AS daily_sal
FROM EMP
WHERE ename = 'JONES';

-- 8. Calculate the total monthly salary of all employees.
SELECT SUM(sal) AS total_monthly_salary
FROM EMP;

-- 9. Print the average annual salary.
SELECT AVG(sal) * 12 AS average_annual_salary
FROM EMP;

-- 10. Select the name, job, salary, department number of all employees except... (The request was cut off, so I will provide the query for name, job, salary, and department number for all employees.)
SELECT ename, job, sal, deptno
FROM EMP
WHERE NOT (job = 'SALESMAN' AND deptno = 30);


-- 11. List unique departments of the EMP table.
SELECT DISTINCT deptno
FROM EMP;

-- 12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30.
-- Label the columns Employee and Monthly Salary respectively.
SELECT ename AS Employee, sal AS "Monthly Salary"
FROM EMP
WHERE sal > 1500 AND (deptno = 10 OR deptno = 30);

-- 13. Display the name, job, and salary of all the employees whose job is MANAGER or
-- ANALYST and their salary is not equal to 1000, 3000, or 5000.
SELECT ename, job, sal
FROM EMP
WHERE (job = 'MANAGER' OR job = 'ANALYST') AND sal NOT IN (1000, 3000, 5000);

-- 14. Display the name, salary and commission for all employees whose commission
-- amount is greater than their salary increased by 10%.
-- COALESCE is used to treat NULL commission values as 0 for the comparison.
SELECT ename, sal, comm
FROM EMP
WHERE COALESCE(comm, 0) > (sal * 1.10);

-- 15. Display the name of all employees who have two Ls in their name and are in
-- department 30 or their manager is 7782.
select ename 
from emp 
where ename like '%l%l%' and (deptno = 30 or mgr_id = 7782);

-- 16. Display the names of employees with experience of over 30 years and under 40 yrs.
-- Count the total number of employees.
-- Assuming current date is '21-JUL-2025' for experience calculation.
-- Experience is calculated in years by dividing the difference in days by 365.25 to account for leap years.
select ename 
from emp 
where datediff(year, hiredate, getdate()) between 30 and 40;


select count(*) as total_employees 
from emp 
where datediff(year, hiredate, getdate()) between 30 and 40;

-- Total number of employees
SELECT COUNT(*) AS total_employees
FROM EMP;

-- 17. Retrieve the names of departments in ascending order and their employees in
-- descending order.
SELECT d.dname, e.ename
FROM DEPT d
JOIN EMP e ON d.deptno = e.deptno
ORDER BY d.dname ASC, e.ename DESC;

-- 18. Find out experience of MILLER.
-- Assuming current date is '21-JUL-2025' for experience calculation.
select ename, round(datediff(day, hiredate, getdate()) / 365.0, 2) as experience_years 
from emp 
where ename = 'miller';
