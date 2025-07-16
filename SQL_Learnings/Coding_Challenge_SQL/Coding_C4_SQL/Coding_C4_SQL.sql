

use SQL_Assessment

create table Book(
id int primary key,
title varchar(50),
author VARCHAR(50),
isbn VARCHAR(20) UNIQUE,
published_date DATETIME
)

---inserting data into book table----
insert into Book values(1,'My first sql book ','Mary parker','9837487487','2012-02-22 11:08:17'),
(2,'My first sql book ','Jhon mayer','9834783487','1972-07-03 12:08:45'),
(3,'My first sql book ','cary fint','52374857874','2015-10-18 02:08:44')