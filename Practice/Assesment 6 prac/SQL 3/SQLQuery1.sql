use assesment

CREATE TABLE courses (
    cid VARCHAR(10) PRIMARY KEY,
    cname VARCHAR(50),
    startdate DATE,
    enddate DATE,
    fee INT
);

INSERT INTO courses (cid, cname, startdate, enddate, fee) VALUES 
    ('DN003', 'DotNet', '2018-02-01', '2018-02-28', 15000),
	('DV004', 'DataVisualization', '2018-03-01', '2018-04-15', 15000),
	('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
	('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000);


-- 1)
CREATE FUNCTION cal_duration(@startdate DATE, @enddate DATE)
RETURNS INT
AS
BEGIN
RETURN DATEDIFF(DAY, @startdate, @enddate)
END
 
SELECT cid,cname,startdate,enddate, dbo.cal_duration(startdate,enddate) AS Course_Duration
FROM courses


--2)

-- Create TCourseInfo table
CREATE TABLE TCourseInfo (
    Course_Name VARCHAR(50),
    Start_Date DATE
);
 
-- Create Trigger
CREATE TRIGGER TrigCourseInsert
ON Courses
AFTER INSERT
AS
BEGIN
    -- Insert
    INSERT INTO TCourseInfo (Course_Name, Start_Date)
    SELECT cname, startdate
    FROM inserted;
 
    -- Display
    SELECT cname AS Course_Name, startdate AS Start_Date
    FROM inserted;
END;
 
-- Test Trigger
INSERT INTO Courses (cid, cname, startdate, enddate, fee)
VALUES
('DN009', 'Devops', '2018-02-01', '2018-02-26', 25000),
('DV010', 'Data Science', '2018-04-01', '2018-05-15', 15000);
 
-- Check TCourseInfo table
SELECT * FROM TCourseInfo;

--3)

CREATE TABLE Productdetail (
	ProductId INT NULL,
    ProductName VARCHAR(50) ,
    Price FLOAT,
	DiscountedPrice FLOAT

);


----------------------------------------------------------- 

CREATE or ALTER PROCEDURE InsertAndRet

@ProductName VARCHAR(25),

@Price FLOAT,

@GeneratedProductID INT OUTPUT,

@DiscountedPrice FLOAT OUTPUT

AS

BEGIN

SELECT @GeneratedProductID = COALESCE(MAX(ProductId), 0) + 1 FROM Productdetail;

SET @DiscountedPrice = @Price * 0.9;

INSERT INTO Productdetail(ProductId, ProductName, Price, DiscountedPrice)

VALUES (@GeneratedProductID, @ProductName, @Price, @DiscountedPrice);

END;
 
DECLARE @GeneratedProductID INT;

DECLARE @DiscountedPrice FLOAT;
 
EXEC InsertAndRet

@ProductName = 'Fan', 

@Price = 5000,

@GeneratedProductID = @GeneratedProductID OUTPUT,

@DiscountedPrice = @DiscountedPrice OUTPUT;

select * from Productdetail


