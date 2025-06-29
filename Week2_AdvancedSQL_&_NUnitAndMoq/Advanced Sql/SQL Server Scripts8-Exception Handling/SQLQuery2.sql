CREATE TABLE Departments ( 
 DepartmentID INT PRIMARY KEY, 
 DepartmentName VARCHAR(100) NOT NULL 
);

CREATE TABLE Employees ( 
 EmployeeID INT PRIMARY KEY, 
 FirstName VARCHAR(50), 
 LastName VARCHAR(50), 
 Email VARCHAR(100) UNIQUE, 
 Salary DECIMAL(10, 2), 
 DepartmentID INT, 
 FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID) 
);

CREATE TABLE AuditLog ( 
 LogID INT IDENTITY(1,1) PRIMARY KEY, 
 Action VARCHAR(100), 
 ErrorMessage VARCHAR(4000), 
 ActionDate DATETIME DEFAULT GETDATE() 
);

INSERT INTO Departments (DepartmentID, DepartmentName)
VALUES 
(1, 'Human Resources'),
(2, 'Finance'),
(3, 'Engineering'),
(4, 'Marketing');


INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
VALUES 
(101, 'Alice', 'Johnson', 'alice.johnson@example.com', 5500.00, 1),
(102, 'Bob', 'Smith', 'bob.smith@example.com', 7200.00, 2),
(103, 'Carol', 'Taylor', 'carol.taylor@example.com', 6100.00, 3);


CREATE PROCEDURE AddEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES ((SELECT ISNULL(MAX(EmployeeID), 0) + 1 FROM Employees), @FirstName, @LastName, @Email, @Salary, @DepartmentID);
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee', ERROR_MESSAGE());
    END CATCH
END


ALTER PROCEDURE AddEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
AS
BEGIN
    BEGIN TRY
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES ((SELECT ISNULL(MAX(EmployeeID), 0) + 1 FROM Employees), @FirstName, @LastName, @Email, @Salary, @DepartmentID);
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee', ERROR_MESSAGE());

        -- Re-throw the caught exception
        THROW;
    END CATCH
END


ALTER PROCEDURE AddEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
AS
BEGIN
    IF @Salary <= 0
    BEGIN
        RAISERROR('Salary must be greater than zero.', 16, 1);
        RETURN;
    END

    BEGIN TRY
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES ((SELECT ISNULL(MAX(EmployeeID), 0) + 1 FROM Employees), @FirstName, @LastName, @Email, @Salary, @DepartmentID);
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee', ERROR_MESSAGE());
        THROW;
    END CATCH
END


CREATE PROCEDURE TransferEmployee
    @EmployeeID INT,
    @NewDepartmentID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRY
            -- Check if department exists
            IF NOT EXISTS (SELECT 1 FROM Departments WHERE DepartmentID = @NewDepartmentID)
            BEGIN
                RAISERROR('Target Department does not exist.', 16, 1);
                RETURN;
            END

            -- Update employee's department
            UPDATE Employees
            SET DepartmentID = @NewDepartmentID
            WHERE EmployeeID = @EmployeeID;

        END TRY
        BEGIN CATCH
            INSERT INTO AuditLog (Action, ErrorMessage)
            VALUES ('TransferEmployee', ERROR_MESSAGE());
            THROW;
        END CATCH
    END TRY
    BEGIN CATCH
        -- Outer catch if needed
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('TransferEmployee-Outer', ERROR_MESSAGE());
        THROW;
    END CATCH
END


CREATE PROCEDURE BatchInsertEmployees
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        -- Simulated multiple inserts (You can pass a table-valued parameter instead in real app)
        INSERT INTO Employees VALUES (201, 'John', 'Doe', 'john.doe@example.com', 3000, 1);
        INSERT INTO Employees VALUES (202, 'Jane', 'Smith', 'jane.smith@example.com', 0, 1);  -- Will raise custom error

        COMMIT
    END TRY
    BEGIN CATCH
        ROLLBACK
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('BatchInsertEmployees', ERROR_MESSAGE());
        THROW;
    END CATCH
END


ALTER PROCEDURE AddEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Email VARCHAR(100),
    @Salary DECIMAL(10,2),
    @DepartmentID INT
AS
BEGIN
    IF @Salary < 0
    BEGIN
        RAISERROR('Salary cannot be negative.', 16, 1);  -- Error
        RETURN;
    END
    ELSE IF @Salary < 1000
    BEGIN
        RAISERROR('Salary is below recommended threshold.', 10, 1);  -- Warning
    END

    BEGIN TRY
        INSERT INTO Employees (EmployeeID, FirstName, LastName, Email, Salary, DepartmentID)
        VALUES ((SELECT ISNULL(MAX(EmployeeID), 0) + 1 FROM Employees), @FirstName, @LastName, @Email, @Salary, @DepartmentID);
    END TRY
    BEGIN CATCH
        INSERT INTO AuditLog (Action, ErrorMessage)
        VALUES ('AddEmployee', ERROR_MESSAGE());
        THROW;
    END CATCH
END


SELECT * FROM AuditLog ORDER BY ActionDate DESC;





