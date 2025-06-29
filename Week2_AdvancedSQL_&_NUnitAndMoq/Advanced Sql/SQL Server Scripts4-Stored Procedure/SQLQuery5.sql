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


CREATE PROCEDURE sp_GetEmployeesByDepartment
	@DepartmentID INT
AS
BEGIN 
SELECT EmployeeID, FirstName, LastName, JoinDate
FROM Employees WHERE DepartmentID = @DepartmentID;
END;


ALTER PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT EmployeeID, FirstName, LastName, JoinDate, Salary
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;


DROP PROCEDURE sp_GetEmployeesByDepartment;


CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT EmployeeID, FirstName, LastName, JoinDate, Salary
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;



EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;



CREATE PROCEDURE sp_CountEmployeesInDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;


CREATE PROCEDURE sp_TotalSalaryByDepartment
    @DepartmentID INT,
    @TotalSalary DECIMAL(18, 2) OUTPUT
AS
BEGIN
    SELECT @TotalSalary = SUM(Salary)
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;

DECLARE @Total DECIMAL(18, 2);
EXEC sp_TotalSalaryByDepartment 2, @Total OUTPUT;
SELECT @Total AS TotalSalary;



CREATE PROCEDURE sp_UpdateEmployeeSalary
    @EmployeeID INT,
    @NewSalary DECIMAL(10, 2)
AS
BEGIN
    UPDATE Employees
    SET Salary = @NewSalary
    WHERE EmployeeID = @EmployeeID;
END;

EXEC sp_UpdateEmployeeSalary 1, 5500.00;


CREATE PROCEDURE sp_GiveBonus
    @DepartmentID INT,
    @BonusAmount DECIMAL(10, 2)
AS
BEGIN
    UPDATE Employees
    SET Salary = Salary + @BonusAmount
    WHERE DepartmentID = @DepartmentID;
END;

EXEC sp_GiveBonus 1, 500.00;


CREATE PROCEDURE sp_TransactionalSalaryUpdate
    @EmployeeID INT,
    @NewSalary DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE Employees
        SET Salary = @NewSalary
        WHERE EmployeeID = @EmployeeID;

        COMMIT;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        PRINT 'Error occurred. Transaction rolled back.';
    END CATCH
END;



CREATE PROCEDURE sp_FilterEmployees
    @ColumnName NVARCHAR(100),
    @Value NVARCHAR(100)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = 'SELECT * FROM Employees WHERE ' + QUOTENAME(@ColumnName) + ' = @Param';

    EXEC sp_executesql @SQL, N'@Param NVARCHAR(100)', @Param = @Value;
END;

EXEC sp_FilterEmployees 'FirstName', 'John';


CREATE PROCEDURE sp_SafeSalaryUpdate
    @EmployeeID INT,
    @NewSalary DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRY
        UPDATE Employees
        SET Salary = @NewSalary
        WHERE EmployeeID = @EmployeeID;

        PRINT 'Salary updated successfully.';
    END TRY
    BEGIN CATCH
        PRINT 'Error updating salary: ' + ERROR_MESSAGE();
    END CATCH
END;
