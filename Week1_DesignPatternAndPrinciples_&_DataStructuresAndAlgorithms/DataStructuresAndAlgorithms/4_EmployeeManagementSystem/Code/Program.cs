using System;

class Program
{
    static void Main(string[] args)
    {
        EmployeeManagement employeeManager = new EmployeeManagement(5);

        employeeManager.AddEmployee(new Employee { EmployeeId = 1, Name = "John", Position = "Manager", Salary = 50000 });
        employeeManager.AddEmployee(new Employee { EmployeeId = 2, Name = "Alice", Position = "Developer", Salary = 40000 });
        employeeManager.AddEmployee(new Employee { EmployeeId = 3, Name = "Bob", Position = "Analyst", Salary = 35000 });

        employeeManager.TraverseEmployees();

        var emp = employeeManager.SearchEmployee(2);
        if (emp != null)
        {
            Console.WriteLine($"\nFound: {emp.Name}, {emp.Position}, {emp.Salary}");
        }
        else
        {
            Console.WriteLine("\nEmployee not found.");
        }

        employeeManager.DeleteEmployee(2);
        employeeManager.TraverseEmployees();
    }
}