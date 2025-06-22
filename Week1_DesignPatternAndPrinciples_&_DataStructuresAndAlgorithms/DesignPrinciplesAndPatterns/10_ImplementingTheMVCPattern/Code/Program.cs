using System;

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student { Name = "John Doe", Id = "101", Grade = "A" };

        StudentView view = new StudentView();

        StudentController controller = new StudentController(student, view);

        controller.UpdateView();

        controller.SetStudentName("Jane Smith");
        controller.SetStudentGrade("A+");

        controller.UpdateView();
    }
}