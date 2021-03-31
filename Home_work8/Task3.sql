use users;
select * from user;
select name, count(name) as number from user where name like 'A%' group by name having count(name)>1;