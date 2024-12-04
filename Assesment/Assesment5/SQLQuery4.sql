use assesment

CREATE TABLE bday (
    id INT PRIMARY KEY,
    name VARCHAR(50),
    birthday DATE
);

INSERT INTO bday (id, name, birthday) 
VALUES (1, 'Hareesh', '2002-04-19');

INSERT INTO bday (id, name, birthday) 
VALUES (2, 'Anand', '2001-04-18');

INSERT INTO bday (id, name, birthday) 
VALUES (3, 'Sai', '2002-10-30');

SELECT * FROM bday

--1.
SELECT DATENAME(WEEKDAY, birthday)  AS birthday_day
FROM bday
WHERE name = 'Hareesh';

--2.
SELECT DATEDIFF(DAY, birthday, GETDATE()) AS age_in_days
FROM bday
WHERE id = 3; 


create  table Dept(Deptno int Primary key,
Dname varchar(40),
loc varchar(40));
 
create table Emp(Empno int primary key,
Ename varchar(20) not null,
Job varchar(20),
MGR_Id int,
HireDate Date, 
Sal float,
Comm int,
Deptno  int foreign key references Dept(Deptno))
 
 
insert into Dept values(10,'Accounting','New York'),
(20,'Research','Dallas'),
(30,'Sales','Chicago'),
(40,'Operations','Boston')
 
 
insert into Emp values
(7369,'SMITH','CLERK',7902,'17-Dec-80',800,null,20),
(7499,'ALLEN','SALESMAN',7698,'20-FEB-81',1600,300,30),
(7521,'WARD','SALESMAN',7698,'22-FEB-81',1250,500,30),
(7566,'JONES','MANAGER',7839,'02-APR-81',2975,null,20),
(7654,'MARTIN','SALESMAN',7698,'28-SEP-81',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'01-MAY-81',2850,null,30),
(7782,'CLARK','MANAGER',7839,'09-JUN-81',2450,null,10),
(7788,'SCOTT','ANALYST',7566,'19-APR-87',3000,null,20),
(7839,'KING','PRESIDENT',null,'17-NOV-81',5000,null,10),
(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
(7900,'JAMES','CLERK',7698,'03-DEC-81',950,null,30),
(7902,'FORD','ANALYST',7566,'03-DEC-81',3000,null,20),
(7934,'MILLER','CLERK',7782,'23-JAN-82',1300,null,10)


 --3.

SELECT * 
FROM Emp
WHERE HireDate <= DATEADD(YEAR, -5, GETDATE())
  AND MONTH(HireDate) = MONTH(GETDATE())



--4.
BEGIN TRANSACTION;
CREATE TABLE Emplo (
    empno INT PRIMARY KEY,
 
    ename VARCHAR(20),
 
    sal FLOAT,
 
    doj DATE
 
);
INSERT INTO Emplo (empno, ename, sal, doj) VALUES (1, 'hareesh', 1000, '2020-07-11'),(2, 'anand', 2000, '2023-06-16'),
(3, 'sai', 3000, '2024-09-25');
-- Update second row's salary 15% increment
 
UPDATE Emplo
SET sal = sal * 1.15 
WHERE empno = 2;
-- Delete first row
 
DELETE FROM Emplo WHERE empno = 1;
-- Commit the transaction
 
COMMIT;

 
-- Re-insert the deleted row with the updated salary
 
INSERT INTO Emplo (empno, ename, sal, doj) VALUES (1, 'hareesh', 1000, '2020-07-11'); 
SELECT * FROM Emplo;

--5.
CREATE FUNCTION CalculateBonus(@deptno INT, @emp_sal FLOAT) 
RETURNS FLOAT
AS
BEGIN
    DECLARE @bonus FLOAT;

    IF @deptno = 10
        SET @bonus = @emp_sal * 0.15;
    ELSE IF @deptno = 20
        SET @bonus = @emp_sal * 0.20;
    ELSE
        SET @bonus = @emp_sal * 0.05;

    RETURN @bonus;
END;

SELECT empno, ename, sal, deptno, dbo.CalculateBonus(deptno, sal) AS bonus
FROM Emp;


-- 6.

CREATE PROCEDURE UpdateSalaryForSales
AS
BEGIN
    UPDATE Emp
    SET sal = sal + 500
    WHERE Deptno = (SELECT Deptno FROM Dept WHERE Dname = 'Sales')
    AND sal < 1500;
END;

 
EXEC UpdateSalaryForSales;
 
select *from Emp

select*from Dept
select*from Emp