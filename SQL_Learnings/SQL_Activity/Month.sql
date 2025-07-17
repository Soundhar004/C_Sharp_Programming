with cte_months (numb, month_names) as 
(select 1, datename(month, datefromparts(2025, 1, 1))
union all
select numb + 1, datename(month, datefromparts(2025, numb + 1, 1))
from cte_months
where numb < 12)
 
 
select numb, month_names 
from cte_months;