using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SinglyLinkedList
{
    private class Node
    {
        public Task Task;
        public Node Next;

        public Node(Task task)
        {
            Task = task;
            Next = null;
        }
    }

    private Node head;

    public SinglyLinkedList()
    {
        head = null;
    }

    // Add Task to the End
    public void AddTask(Task task)
    {
        Node newNode = new Node(task);

        if (head == null)
        {
            head = newNode;
            Console.WriteLine("Task added as the first task.");
            return;
        }

        Node temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = newNode;
        Console.WriteLine("Task added successfully.");
    }

    // Search Task by ID
    public Task SearchTask(int taskId)
    {
        Node temp = head;

        while (temp != null)
        {
            if (temp.Task.TaskId == taskId)
            {
                return temp.Task;
            }
            temp = temp.Next;
        }

        return null; // Not found
    }

    // Traverse Linked List
    public void TraverseTasks()
    {
        Console.WriteLine("\nCurrent Task List:");
        Node temp = head;

        while (temp != null)
        {
            Console.WriteLine($"ID: {temp.Task.TaskId}, Name: {temp.Task.TaskName}, Status: {temp.Task.Status}");
            temp = temp.Next;
        }
    }

    // Delete Task by ID
    public void DeleteTask(int taskId)
    {
        if (head == null)
        {
            Console.WriteLine("Task list is empty.");
            return;
        }

        if (head.Task.TaskId == taskId)
        {
            head = head.Next;
            Console.WriteLine("Task deleted successfully.");
            return;
        }

        Node current = head;
        Node previous = null;

        while (current != null && current.Task.TaskId != taskId)
        {
            previous = current;
            current = current.Next;
        }

        if (current == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        previous.Next = current.Next;
        Console.WriteLine("Task deleted successfully.");
    }
}

