1. Write a query to display your birthday (day of the week)
Assuming your birthday is stored in a column birthday in the format 'YYYY-MM-DD' in a table named employee_info, you can write the following query to display the day of the week:

SELECT TO_CHAR(birthday, 'Day') AS birthday_day
FROM employee_info
WHERE employee_id = YOUR_EMPLOYEE_ID;
Replace YOUR_EMPLOYEE_ID with your actual employee ID or relevant condition. The TO_CHAR function in Oracle or equivalent in other databases can help you extract the day of the week.

2. Write a query to display your age in days

SELECT FLOOR(SYSDATE - birthday) AS age_in_days
FROM employee_info
WHERE employee_id = YOUR_EMPLOYEE_ID;
Here, SYSDATE gives the current date, and subtracting the birthday from it gives the difference in days.

3. 
SELECT *
FROM emp
WHERE hire_date <= ADD_MONTHS(TRUNC(SYSDATE, 'MM'), -60) 
AND EXTRACT(MONTH FROM hire_date) = EXTRACT(MONTH FROM SYSDATE);
Explanation:

ADD_MONTHS(TRUNC(SYSDATE, 'MM'), -60) gets the date 5 years before the current date.
EXTRACT(MONTH FROM hire_date) = EXTRACT(MONTH FROM SYSDATE) ensures the employees were hired in the current month.
4. Create a table Employee and perform the following operations in a single transaction
First, create the Employee table:

sql
Copy code
CREATE TABLE Employee (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    sal DECIMAL(10, 2),
    doj DATE
);
Now, perform the required operations in a single transaction:

sql
Copy code
BEGIN
    -- Insert 3 rows
    INSERT INTO Employee (empno, ename, sal, doj) VALUES (1, 'John', 1000, TO_DATE('2020-12-01', 'YYYY-MM-DD'));
    INSERT INTO Employee (empno, ename, sal, doj) VALUES (2, 'Jane', 1200, TO_DATE('2021-12-01', 'YYYY-MM-DD'));
    INSERT INTO Employee (empno, ename, sal, doj) VALUES (3, 'Doe', 1100, TO_DATE('2022-12-01', 'YYYY-MM-DD'));
    
    -- Update the second row's salary with 15% increment
    UPDATE Employee SET sal = sal * 1.15 WHERE empno = 2;
    
    -- Delete the first row
    DELETE FROM Employee WHERE empno = 1;
    
    -- Rollback to restore the deleted row
    ROLLBACK;
END;

5. Create a user-defined function to calculate the bonus for all employees of a given department
Create a function to calculate the bonus based on department number:


CREATE OR REPLACE FUNCTION calculate_bonus (deptno_in INT) 
RETURN TABLE IS
    CURSOR emp_cursor IS
    SELECT empno, ename, sal
    FROM emp
    WHERE deptno = deptno_in;
    
    emp_record emp_cursor%ROWTYPE;
BEGIN
    FOR emp_record IN emp_cursor LOOP
        IF deptno_in = 10 THEN
            RETURN (emp_record.sal * 0.15);
        ELSIF deptno_in = 20 THEN
            RETURN (emp_record.sal * 0.20);
        ELSE
            RETURN (emp_record.sal * 0.05);
        END IF;
    END LOOP;
END;
This function takes deptno_in as a parameter and calculates the bonus based on the conditions provided. You can modify the table structure and adjust the logic if necessary.

6. Create a procedure to update the salary of employees by 500 whose department name is 'Sales' and whose current salary is below 1500

CREATE OR REPLACE PROCEDURE update_sales_salary IS
BEGIN
    UPDATE emp
    SET sal = sal + 500
    WHERE deptno = (SELECT deptno FROM dept WHERE dname = 'Sales')
    AND sal < 1500;
    
    COMMIT;
END;
