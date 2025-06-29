CREATE TABLE Departments(
	DepartmentID INT PRIMARY KEY,
	DepartmentName VARCHAR(100)
);

CREATE TABLE Employees(
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

DECLARE @EmployeeID INT,@FirstName VARCHAR(50),@LastName VARCHAR(50),@DepartmentID INT,@Salary DECIMAL(10,2),@JoinDate DATE;
DECLARE employee_cursor CURSOR FOR
SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
FROM Employees;

OPEN employee_cursor;
FETCH NEXT FROM employee_cursor
INTO @EmployeeID, @FirstName, @LastName, @DepartmentID, @Salary, @JoinDate;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'EmployeeID: ' + CAST(@EmployeeID AS VARCHAR(10)) +
          ', Name: ' + @FirstName + ' ' + @LastName +
          ', DepartmentID: ' + CAST(@DepartmentID AS VARCHAR(10)) +
          ', Salary: ' + CAST(@Salary AS VARCHAR(10)) +
          ', JoinDate: ' + CONVERT(VARCHAR(20), @JoinDate, 120);

    FETCH NEXT FROM employee_cursor
    INTO @EmployeeID, @FirstName, @LastName, @DepartmentID, @Salary, @JoinDate;
END;

CLOSE employee_cursor;
DEALLOCATE employee_cursor;



DECLARE static_cursor CURSOR STATIC FOR
SELECT * FROM Employees;

DECLARE dynamic_cursor CURSOR DYNAMIC FOR
SELECT * FROM Employees;

DECLARE forward_cursor CURSOR FORWARD_ONLY FOR
SELECT * FROM Employees;

DECLARE keyset_cursor CURSOR KEYSET FOR
SELECT * FROM Employees;

