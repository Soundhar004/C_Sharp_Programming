use Sql_Learnings

with cte_months (numb, month_names) as 
(select 1, datename(month, datefromparts(2025, 1, 1))
union all
select numb + 1, datename(month, datefromparts(2025, numb + 1, 1))
from cte_months
where numb < 12)
 
 
select numb, month_names 
from cte_months;


create procedure getdetails 
@empid int as begin
select e.ename as emp_name, e.sal as emp_salary, m.ename as mgr_name
from emp e
left join emp m on e.mgr_id = m.empno
where e.empno = @empid
end
go
 
exec getdetails @empid = 7839;

select * from sysmessages