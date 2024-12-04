create database company

use company

CREATE TABLE DEPT (
    deptno INT PRIMARY KEY,
    dname VARCHAR(50),
    loc VARCHAR(50)
);
 
CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    job VARCHAR(50),
    mgr_id INT,
    hiredate DATE,
    sal DECIMAL(10, 2),
    comm DECIMAL(10, 2) DEFAULT NULL,
    deptno INT,
    FOREIGN KEY (deptno) REFERENCES DEPT(deptno),
    FOREIGN KEY (mgr_id) REFERENCES EMP(empno)
);
 
INSERT INTO DEPT (deptno, dname, loc) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');
 
INSERT INTO EMP (empno, ename, job, mgr_id, hiredate, sal, comm, deptno) VALUES
(7369, 'SMITH', 'CLERK', 7902, CONVERT(DATE, '17-DEC-80', 113), 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, CONVERT(DATE, '20-FEB-81', 113), 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, CONVERT(DATE, '22-FEB-81', 113), 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, CONVERT(DATE, '02-APR-81', 113), 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, CONVERT(DATE, '28-SEP-81', 113), 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, CONVERT(DATE, '01-MAY-81', 113), 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, CONVERT(DATE, '09-JUN-81', 113), 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, CONVERT(DATE, '19-APR-87', 113), 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, CONVERT(DATE, '17-NOV-81', 113), 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, CONVERT(DATE, '08-SEP-81', 113), 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, CONVERT(DATE, '23-MAY-87', 113), 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, CONVERT(DATE, '03-DEC-81', 113), 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, CONVERT(DATE, '03-DEC-81', 113), 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, CONVERT(DATE, '23-JAN-82', 113), 1300, NULL, 10);


CREATE or ALTER PROC sp_getAvgSalAndCountEmp @depId int,@avgSalary1 DECIMAL(10, 2) OUTPUT
AS
BEGIN
	Select @avgSalary1 = avg(sal) from emp where deptno=@depId
	return (Select Count(empno) as TotalEmployee from emp where deptno=@depId)
END
 
Declare @empCount int
Declare @Op_AvgSal decimal(10,2) 
exec @empCount=sp_getAvgSalAndCountEmp 10,@Op_AvgSal OUTPUT
select @empCount as employeeCount,@Op_AvgSal as AVGSalary