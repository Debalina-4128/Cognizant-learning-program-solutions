CREATE TABLE Departments(
DepartmentID INT PRIMARY KEY,
DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
 EmployeeID INT PRIMARY KEY,
 FirstName VARCHAR(50),
 LastName VARCHAR(50),
 DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
 Salary DECIMAL(10,2),
 JoinDate DATE
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, 
JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');



CREATE FUNCTION fn_CalculateAnnualSalary (
    @Salary DECIMAL(10, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN @Salary * 12;
END;

SELECT EmployeeID, FirstName, LastName, Salary,
       dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;


CREATE FUNCTION fn_GetEmployeesByDepartment (
    @DepartmentID INT
)
RETURNS TABLE
AS
RETURN (
    SELECT EmployeeID, FirstName, LastName, Salary, JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID
);

SELECT * FROM dbo.fn_GetEmployeesByDepartment(3);




CREATE FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN @Salary * 0.10;
END;

SELECT EmployeeID, FirstName, LastName, Salary,
       dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;


ALTER FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN @Salary * 0.15;
END;


SELECT EmployeeID, FirstName, LastName, Salary,
       dbo.fn_CalculateBonus(Salary) AS Bonus
FROM Employees;


DROP FUNCTION fn_CalculateBonus;


SELECT EmployeeID, FirstName, LastName, Salary,
       dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;


SELECT dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees
WHERE EmployeeID = 1;


SELECT * FROM dbo.fn_GetEmployeesByDepartment(2);


CREATE FUNCTION fn_CalculateBonus (
    @Salary DECIMAL(10, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN @Salary * 0.15; -- use current 15%
END;

CREATE FUNCTION fn_CalculateTotalCompensation (
    @Salary DECIMAL(10, 2)
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @AnnualSalary DECIMAL(10, 2) = dbo.fn_CalculateAnnualSalary(@Salary);
    DECLARE @Bonus DECIMAL(10, 2) = dbo.fn_CalculateBonus(@Salary);
    RETURN @AnnualSalary + @Bonus;
END;

SELECT EmployeeID, FirstName, LastName, Salary,
       dbo.fn_CalculateTotalCompensation(Salary) AS TotalCompensation
FROM Employees;


