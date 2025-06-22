using System;

class Program
{
    static void Main(string[] args)
    {
        SinglyLinkedList taskList = new SinglyLinkedList();

        taskList.AddTask(new Task { TaskId = 1, TaskName = "Design Module", Status = "Pending" });
        taskList.AddTask(new Task { TaskId = 2, TaskName = "Develop Module", Status = "In Progress" });
        taskList.AddTask(new Task { TaskId = 3, TaskName = "Test Module", Status = "Not Started" });

        taskList.TraverseTasks();

        var task = taskList.SearchTask(2);
        if (task != null)
        {
            Console.WriteLine($"\nFound Task: {task.TaskName}, Status: {task.Status}");
        }
        else
        {
            Console.WriteLine("\nTask not found.");
        }

        taskList.DeleteTask(2);
        taskList.TraverseTasks();
    }
}