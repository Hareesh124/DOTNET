begin transaction
update emp set sal=
case
when sal>400 then sal-400 
else 'error in the updating'
end
where MGR_Id=7902
 
save transaction savepoint1
if exists(select * from Emp where MGR_Id=7698)
begin
update emp set sal=sal+400 where MGR_Id=7698
commit;
print 'success full';
end
else
begin
rollback transaction savepoint1;
print 'failed'
select *from emp where MGR_Id in (7902, 7698) 
end;
 
create function rect(@length int,@breath int)
returns int
as
begin
return(select @length*@breath)
end
SELECT dbo.rect(10, 5) AS Area;