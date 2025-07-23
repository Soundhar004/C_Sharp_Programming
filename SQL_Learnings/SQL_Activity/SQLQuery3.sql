--multi statement table valued functions
create or alter function fn_GetEmp_ByGender(@egen varchar(8))
returns 
@EmpBygender table(EmpNumber int, EmployeeName varchar(max), Gender varchar(8))
 as
  begin
   --bulk insertion
   insert into @EmpBygender select empid,empname,gender from employee
     where gender = @egen
	 --incase there wer eissues in bulk insertion
	 --we can try to handle exception
	 if @@ROWCOUNT = 0
	  begin
	   insert into @EmpBygender values(0, 'No Employee Found with the given gender', null)
	  end
	  return
   end

   --to execute the above
   select * from dbo.fn_GetEmp_Bygender('Male')
     select * from dbo.fn_GetEmp_Bygender('FeMale')
	   select * from dbo.fn_GetEmp_Bygender('M')
   
   --Northwind 
   use Northwind
   select * from Customers

   --write a multi statement function to return customers by their country name (given country name)

   --Indexes
create table TestTable 
( TestId int,
TestName varchar(max),
TestDate date)

insert into TestTable values(4,'Javascript','2025/07/20'),(null,'SQL','2025/07/25'),
(1,'API','2025/08/21')

delete from TestTable where TestName like'C%'
select * from TestTable
--creating a clustered index 
create clustered index idxt_tid on TestTable(testid)

-- the above only sorts the physical order

--dropping an index from a table
drop index Testtable.idxt_tid
drop index Testtable.idxu

--creating a unique clustered index
create unique clustered index idx_u on TestTable(testid)
create unique clustered index idxname on TestTable(testname)

sp_help employee

--non clusterd indexes
create index idxtestname on testtable(testdate)

--the above way of creating indexes will always create a non-clusterd, non-unique index only
create unique nonclustered index idxdname on department(deptname)

select * from department
insert into department values(8,'hr',7000) -- unique nonclusterd protects from duplicate entries

create nonclustered index idxname on employee(empname)

select * from employee

insert into employee values(107,'Shreya','Female',6200,3,'111111')

--filtered indexes
create index idxsalary on emp(salary) where salary > 1600

select * from emp where salary between 2000 and 3000

--Views 
--1. single table view
create view vwEmpdata
as select empid,empname,salary, phone from employee 

sp_helptext vwempdata
select * from vwEmpdata
select * from employee

insert into vwempdata values(108,'Dinesh',6300,'222222')

update vwempdata set empname='Hari' where empid=108

delete from vwempdata where empid=107
-- all dml operations are successful thru the view , when the view is made out of a 
--single table, and the other columns can take either a null value or a default value

--mutliple table views
create view vwEmpbyDept
as select empid, empname,salary, department.deptname from employee join department
on employee.departmentid = department.deptid

select * from vwEmpbyDept

select * from employee
select * from department
insert into vwEmpbyDept values(200,'Shami',6400,'IT')

update vwEmpbyDept set deptname = 'HR' where empid=101





--triggers
create trigger trgEmpIns
on employee   -- object on which the trigger is placed
for insert   -- the event for which the trigger would automatically fire
as
 begin
  select * from inserted
  select * from employee
  end

  --for the above trigger to be fired
  insert into employee values(200,'Banurekha','Female',6200,1,'34343434')

  create or alter trigger trg_EmpDel
  on employee
  for delete
  as
   begin
    select * from deleted
	select * from employee
	end

set implicit_transactions on

delete from employee where empid=200
rollback

--3. upd
create trigger trg_empUpd
on employee
for update
as
begin
 select * from deleted
 select * from inserted

 declare @oldsal float, @newsal float
 select @oldsal = salary from deleted
 select @newsal = salary from inserted
 print @oldsal
 print @newsal
 if(@newsal > @oldsal)
  begin
   print ' emp salary has been upgraded'
   end

   else
   begin
   print ' salary has been decreased'
   end

 end

 update employee set salary = 6000 where empid=200

 rollback


--eg 4. trigger for dml restriction
drop trigger trgnochanges
create or alter trigger trgNoChanges
on department
for insert,update,delete
as
begin
 select 'Permission denied.. Contact Admin'
 rollback
 end

 insert into department values(20,'OurDept',20000)
 delete from department where deptid =20
 select * from department

 --eg 5.
 --trigger for creating log data

 create table AuditLog(msg nvarchar(max))

 create or alter trigger trgAudit
 on employee
 for insert
 as
  begin
   declare @id int
   select @id = empid from inserted

   insert into AuditLog
   values('New Employee with Employee Id : ' + ' ' + cast(@id as varchar(5)) + 
   ' ' + ' is added at ' + cast(getdate() as varchar(20)))
  end

  --let us insert a row into employee
  insert into employee values(110,'Taraka lakshmi', 'Female', 6500,1,'776655')

  select * from auditlog

  delete from department where deptid=7
  sp_help employee

  -- trigger for updation along withaudit lod details
  alter table auditlog
  add auditdate date 

  create or alter trigger trgUpdateAudit
  on employee
  for update
  as
  begin
   declare @id int, @olddept int, @newdept int
   declare @oldename varchar(40), @newename varchar(40)
   declare @oldsal float, @newsal float

   -- declare a variable to build the audit string 
   declare @auditdata varchar(max)
   select * from deleted
   select * from inserted
   --store the inserted data into temporary table or we can directly use the inserted 
   select * into #temptable from inserted 
   select * from #temptable
   --loop thru all the updated records incase we have updated many records
   while(exists(select empid from #temptable))
    begin
	 set @auditdata = ' '

	 --let us select the first row of the temporary table
	 select top 1 @id=empid, @newename=empname, @newsal = salary,@newdept=departmentid from #temptable

	 --let us also select the data from the deleted table
	 select @oldename = empname, @oldsal=salary, @olddept = departmentid from deleted

	 set @auditdata = 'Employee with ID : ' + cast(@id as varchar(5)) + ' Changed '
	 --if old data is updated with new data, we should track individually
	 if(@oldename <> @newename)
	  begin
	   set @auditdata = @auditdata + ' the Name from ' + @oldename + ' to ' + @newename
	   end
	   --for salary
	   if(@oldsal <> @newsal)
	    begin
		set @auditdata = @auditdata + ' Salary from ' + cast(@oldsal as varchar(8)) + ' to ' + 
		cast(@newsal as varchar(10))
	   end
	   --for dept
	   if(@olddept <> @newdept)
	    begin
		set @auditdata = @auditdata + ' Department from ' + cast(@olddept as varchar(5)) + ' to '
		+ cast(@newdept as varchar(5))
	   end







---Triggers---
CREATE TRIGGER trg_InsteadOfUpdate_EmployeeDepartmentView
ON vwEmpbyDept
INSTEAD OF UPDATE
AS
    BEGIN
        -- Update the DepartmentID in the base Employee table
        UPDATE e
        SET e.DepartmentID = i.DepartmentID
        FROM Employee e
        INNER JOIN INSERTED i ON e.EmpId = i.EmpId
    END
END;
 
update vwEmpbyDept set deptname='Operations' where empid=2