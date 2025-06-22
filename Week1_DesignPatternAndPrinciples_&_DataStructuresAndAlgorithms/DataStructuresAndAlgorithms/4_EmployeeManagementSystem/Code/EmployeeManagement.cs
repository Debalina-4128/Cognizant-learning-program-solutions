using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EmployeeManagement
{
    private Employee[] employees;
    private int count;

    public EmployeeManagement(int size)
    {
        employees = new Employee[size];
        count = 0;
    }


    public void AddEmployee(Employee employee)
    {
        if (count < employees.Length)
        {
            employees[count] = employee;
            count++;
            Console.WriteLine("Employee added successfully.");
        }
        else
        {
            Console.WriteLine("Employee array is full.");
        }
    }

    public Employee SearchEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                return employees[i];
            }
        }
        return null;
    }

    public void TraverseEmployees()
    {
        Console.WriteLine("\nCurrent Employee List:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"ID: {employees[i].EmployeeId}, Name: {employees[i].Name}, Position: {employees[i].Position}, Salary: {employees[i].Salary}");
        }
    }

    public void DeleteEmployee(int id)
    {
        int index = -1;
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        for (int i = index; i < count - 1; i++)
        {
            employees[i] = employees[i + 1];
        }

        employees[count - 1] = null;
        count--;

        Console.WriteLine("Employee deleted successfully.");
    }
}