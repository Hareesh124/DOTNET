create database assesment

use assesment


--Book table

create table Book (
    id int PRIMARY KEY,        
    title varchar(255) NOT NULL,               
    author varchar(255) NOT NULL,
    isbn varchar(20) UNIQUE NOT NULL, 
	published_date DATETIME,   
);

insert into Book values (1,'My First SQL book','Mary Parker','981483029127','2012-02-22 12:08:17');
insert into Book values (2,'My Second SQL book','John Mayer','857300923713','1972-07-03 09:22:45');
insert into Book values (3,'My Third SQL book','Cary Flint','523120967812','2015-10-18 14:05:44');

select * from Book
where author LIKE '%er';


--Review table

create table review (
    id int PRIMARY KEY,        
    book_id int,  
	reviewer_name varchar(50) NOT NULL,
    content varchar(50) NOT NULL,
    rating int, 
	published_date DATETIME,   
);

insert into review values (1,1,'John Smith','My first review',4,'2017-12-10 05:50:11');
insert into review values (2,2,'John Smith','My second review',5,'2017-10-13 15:05:12');
insert into review values (3,2,'Alice Walker','Another review',1,'2017-10-22 23:47:10');

select b.title, b.author, r.reviewer_name
from Book b, review r
where b.id = r.id

select reviewer_name
from review
group by reviewer_name
having count(DISTINCT book_id) > 1;

--EMployee table


create table Employee (
Id int,
  Name varchar(50),
  Age int,
  Address varchar(50),
  Salary float)

   insert into Employee values
   (1,'Ramesh',32,'Ahmedabad',2000.00),
   (2,'Khilan',25,'Delhi',1500.00),
  (3,'Kaushik',23,'Kota',2000.00),
  (4,'Chaitali',23,'Mumbai',6500.00),
  (5,'Hardik',23,'Bhopal',8500.00),
  (6,'Komal',22,'MP',4500.00),
  (7,'Muffy',24,'Indore',10000.00)
 
  select*from Employee

  select Name from Employee where Address like '%o%';
 
 --Employee table after updating null values (q2)

 update Employee 
 set Salary = NULL
 where Id = 6

  update Employee 
 set Salary = NULL
 where Id = 7

 select LOWER(Name) as Name from Employee where Salary IS NULL;


 --Orders table

 create table Orders (
	Oid int,
	date DATETIME,   
  Customer_id int,
  amount int)

     insert into Orders values
	 (102,'2009-10-08 00:00:00',3,3000),
	 (100,'2009-10-08 00:00:00',3,1500),
	 (101,'2009-11-20 00:00:00',2,1560),
	 (103,'2008-05-20 00:00:00',4,2060)

select date, COUNT(DISTINCT Oid) AS customers
from Orders
group BY date
having COUNT(DISTINCT Oid) > 1
order by date

--Student Table

create table Studentdetails(
    reg int PRIMARY KEY,        
    name varchar(50) NOT NULL,     
	age int NOT NULL,
	qualification varchar(20),
    mobile varchar(255) NOT NULL,
    mail varchar(50) UNIQUE NOT NULL, 
	loc varchar(20),
	gender char)

insert into StudentDetails values 
(2,'Sai',22,'B.E',9952836777,'Sai@gmail.com','Chennai','M'), 
(3,'Kumar',20,'BSC',7890125648,'Kumar@gmail.com','Madurai','M'), 
(4,'Selvi',22,'B.Tech',8904567342,'Selvi@gmail.com','Selam','F'), 
(5,'Nisha',25,'M.E',7834672310,'Nisha@gmail.com','Theni','F'), 
(6,'SaiSaran',21,'B.A',7890345678,'Saran@gmail.com','Madurai','F'), 
(7,'Tom',23,'BCA',8901234675,'Tom@gmail.com','Pune','M')

select * from StudentDetails 

select gender,count(gender) 'Total' from StudentDetails group by gender 