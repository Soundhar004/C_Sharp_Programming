---Creating the Database---
create database SQL_Assessment

use SQL_Assessment

create table Book(
id int primary key,
title varchar(50),
author varchar(50),
isbn varchar(20) UNIQUE,
published_date DATETIME
)

---inserting data into table Book----
insert into Book values(1,'My first sql book ','Mary parker','9837487487','2012-02-22 11:08:17'),
(2,'My first sql book ','Jhon mayer','9834783487','1972-07-03 12:08:45'),
(3,'My first sql book ','cary fint','52374857874','2015-10-18 02:08:44')


----- 1. Write a query to fetch the details of the books written by author whose name ends with er----
select * from Book where author like '%er'

---Creating reviews table---
create table reviews(
id int primary key,
book_id int,
reviewer_name varchar(100),
content text,
rating int,
published_date datetime,
foreign key (book_id) references Book(id)
)

---inserting data into reviews tabel--------
Insert into reviews values(1,1,'John Smith','My first review',4,'2017-12-10 02:09:34'),
(2,2,'John Smith','My second review',5,'2017-10-10 21:09:34'),
(3,2,'alice Walker','Another review',1,'2017-10-10 21:09:34')

------2. Display the Title ,Author and ReviewerName for all the books from the above table-------
Select Book.title,Book.author,reviews.reviewer_name from Book,reviews where book.id=reviews.book_id

----- 3---- Display the reviewer name who reviewed more than one book.-------------
select reviewer_name from reviews 
group by reviewer_name 
having COUNT(*)>1



---Creating table Customer---
create table customer (
    id INT PRIMARY KEY, 
	name varchar(50),
    age INT,
    address VARCHAR(100),
    salary DECIMAL(10, 2)
)

insert into customer (id, name, age, address, salary) values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00)


---4. Query to display name where address has character 'o'--- 
select name
FROM customer
WHERE address LIKE '%o%'


---creating Table Order---
create table ORDERS (
   O_ID INT PRIMARY KEY,
   O_DATE DATETIME,
   CUSTOMER_ID INT,
   AMOUNT FLOAT,
   )

 ----inserting data into ORDERS table-----
insert into ORDERS 
values (102, '2009-10-08 00:00:00', 3, 3000),
       (100, '2009-10-08 00:00:00', 3, 1500),
       (101, '2008-05-20 00:00:00',2, 1560),
	   (103, '2008-05-20 00:00:00',4, 2060)
 
 
------5. Write a query to display the   Date,Total no of customer  placed order on same Date
select o_date, COUNT(DISTINCT customer_id) AS TotalNoCustomers
FROM ORDERS
GROUP BY o_date


---Create table Employee---
create table EMPLOYEE (
    id int primary KEY,
    name varchar(50),
    address varchar(100),
    age int,
    salary float
)
 
 
insert into EMPLOYEE
values 
    (1, 'RAMESH', 'AHMEDABAD',  32, 2000.00),
    (2, 'KHILAN', 'DELHI', 25, 1500.00),
    (3, 'KAUSHIK', 'KOTA', 23, 2000.00),
	(4,'CHAITALI','MUMBAI',25,6500.00),
	(5,'HARDIK','BHOPAL',27,8500.00),
	(6,'KOMAL','MP',22,NULL),
	(7,'MUFFY','INDORE',24,NULL)
 
 
---6. Display the Names of the Employee in lower case, whose salary is null--- 
select LOWER(name) as LowercaseName
FROM Employee
WHERE salary IS NULL


---Creating table Student---
create table Students (
    reg INT PRIMARY KEY,
    name VARCHAR(50),
    age INT,
    qualification VARCHAR(50),
    mobile_no VARCHAR(15),
    mail_id VARCHAR(50),
    location VARCHAR(100),
    gender CHAR(1)
)

---inserting data into student table---
insert into Students 
values 
(2, 'SAI', 22, 'BE', '9952836777', 'SAI@GMAIL.COM', 'CHENNAI', 'M'),
(3, 'KUMAR', 20, 'BSC', '7890125648', 'KUMAR@GMAIL.COM', 'MADURAI', 'M'),
(4, 'SELVI',  22, 'B  TECH', '8904567342', 'SELVI@GMAIL.COM', 'SELAM', 'F'),
(5, 'NISHA',  25, 'ME', '7834672310', 'NISHA@GMAIL.COM', 'THENI', 'F'),
(6, 'SAISARAN',  21, 'BA', '7890345678', 'SARAN@GMAIL.COM', 'MADURAI', 'F'),
(7, 'TOM',  23, 'BCA', '8901234675', 'TOM@GMAIL.COM', 'PUNE', 'M')


---7. Write a sql server query to display the Gender,Total no of male and female from the above relation.---
select gender, COUNT(*) as Totale_No_mployees
FROM Students
GROUP BY gender