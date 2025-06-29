CREATE TABLE EmployeeChanges (
    ChangeID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangeDate DATETIME DEFAULT GETDATE()
);

CREATE TRIGGER trg_AfterSalaryUpdate
ON Employees
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeChanges (EmployeeID, OldSalary, NewSalary)
        SELECT 
            d.EmployeeID,
            d.Salary AS OldSalary,
            i.Salary AS NewSalary
        FROM deleted d
        JOIN inserted i ON d.EmployeeID = i.EmployeeID
        WHERE d.Salary <> i.Salary;
    END
END;


CREATE TRIGGER trg_PreventEmployeeDelete
ON Employees
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR('Deletion of employee records is not allowed.', 16, 1);
END;


CREATE TRIGGER trg_RestrictLogonDuringMaintenance
ON ALL SERVER
FOR LOGON
AS
BEGIN
    DECLARE @CurrentTime TIME = CONVERT(TIME, GETDATE());

    -- Maintenance window: 2 AM to 3 AM
    IF @CurrentTime BETWEEN '02:00:00' AND '03:00:00'
    BEGIN
        ROLLBACK;
        PRINT 'Logins are disabled during maintenance hours (2 AM - 3 AM).';
    END
END;


UPDATE Employees
SET Salary = 6500
WHERE EmployeeID = 1;

SELECT * FROM EmployeeChanges;


DROP TRIGGER trg_AfterSalaryUpdate;

ALTER TABLE Employees ADD AnnualSalary DECIMAL(12, 2);

CREATE TRIGGER trg_UpdateAnnualSalary
ON Employees
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE e
    SET e.AnnualSalary = i.Salary * 12
    FROM Employees e
    INNER JOIN inserted i ON e.EmployeeID = i.EmployeeID;
END;
