using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StudentView
{
    public void DisplayStudentDetails(string studentName, string studentId, string studentGrade)
    {
        Console.WriteLine("Student Details:");
        Console.WriteLine("Name: " + studentName);
        Console.WriteLine("ID: " + studentId);
        Console.WriteLine("Grade: " + studentGrade);
        Console.WriteLine();
    }
}

