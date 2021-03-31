use examples;
select group_id, 
group_concat(distinct descr order by descr asc separator ',' )
 as descr from example group by group_id