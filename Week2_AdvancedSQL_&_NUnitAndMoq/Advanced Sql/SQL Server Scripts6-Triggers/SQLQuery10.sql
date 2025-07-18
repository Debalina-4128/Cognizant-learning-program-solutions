USE [EmployeeDB3]
GO
/****** Object:  Trigger [dbo].[trg_AfterSalaryUpdate]    Script Date: 29-06-2025 11:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trg_AfterSalaryUpdate]
ON [dbo].[Employees]
AFTER UPDATE
AS
BEGIN
    IF UPDATE(Salary)
    BEGIN
        INSERT INTO EmployeeChanges (EmployeeID, OldSalary, NewSalary, ChangedBy, ChangeDate)
        SELECT 
            d.EmployeeID,
            d.Salary AS OldSalary,
            i.Salary AS NewSalary,
            SYSTEM_USER AS ChangedBy,
            GETDATE() AS ChangeDate
        FROM deleted d
        JOIN inserted i ON d.EmployeeID = i.EmployeeID
        WHERE d.Salary <> i.Salary;
    END
END;