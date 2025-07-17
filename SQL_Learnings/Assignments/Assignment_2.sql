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


select * from EMP

---1. List all employees whose name begins with 'A'---
select * from Emp where ENAME like 'A%' 


---2. Select all those employees who don't have a manager---
select * from EMP where MGR_ID is null 


---3. List employee name, number and salary for those employees who earn in the range 1200 to 1400---
select ENAME, EMPNO, SAL FROM EMP WHERE SAL BETWEEN 1200 AND 1600 


---4. Give all the employees in the RESEARCH department a 10% pay rise. 
---   Verify that this has been done by listing all their details before and after the rise.---
select * from DEPT where DEPTNO=20
update EMP set SAL= SAL* 1.10
select * from EMP where Deptno=20

---5. Find the number of CLERKS employed. Give it a descriptive heading---
select count(*) as 'Number of Employees' from EMP where UPPER(Job)='CLERK'

---6. Find the average salary for each job type and the number of people employed in each job---
SELECT JOB, COUNT(*) AS NUM_EMPLOYEES, AVG(SAL) AS AVG_SALAR FROM EMP
GROUP BY JOB;

---7. List the employees with the lowest and highest salary---
SELECT * FROM EMP 
WHERE SAL = (SELECT MIN(SAL) FROM EMP)
   OR SAL = (SELECT MAX(SAL) FROM EMP);

---8. List full details of departments that don't have any employee---
SELECT D.* FROM DEPT D
LEFT JOIN EMP E ON D.DEPTNO = E.DEPTNO
WHERE E.DEPTNO IS NULL;

---9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20.
---   Sort the answer by ascending order of name---
SELECT ENAME, SAL FROM EMP
WHERE JOB = 'ANALYST'
  AND SAL > 1200
  AND DEPTNO = 20
ORDER BY ENAME ASC;

---10. For each department, list its name and number together with the total salary paid to employees in that department---
SELECT 
    D.DEPTNO,
    D.DNAME,
    SUM(E.SAL) AS TOTAL_SALARY
FROM DEPT D
JOIN EMP E ON D.DEPTNO = E.DEPTNO
GROUP BY D.DEPTNO, D.DNAME;

---11. Find out salary of both MILLER and SMITH---
select SAL,ENAME from EMP where ENAME in ('MILLER', 'SMITH')

---12. Find out the names of the employees whose name begin with ‘A’ or ‘M’---
select ENAME from EMP where ENAME like 'A%' or ENAME like 'M%' 

---13. Compute yearly salary of SMITH---
SELECT ENAME, SAL * 12 AS YEARLY_SALARY
FROM EMP
WHERE ENAME = 'SMITH';

---14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850---
SELECT ENAME, SAL
FROM EMP
WHERE SAL NOT BETWEEN 1500 AND 2850;

---15. Find all managers who have more than 2 employees reporting to them---
SELECT MGR.EMPNO, MGR.ENAME, MGR.JOB, COUNT(E.EMPNO) AS NUM_REPORTS
FROM EMP E
JOIN EMP MGR ON E.MGR_ID = MGR.EMPNO
GROUP BY MGR.EMPNO, MGR.ENAME, MGR.JOB
HAVING COUNT(E.EMPNO) > 2;
