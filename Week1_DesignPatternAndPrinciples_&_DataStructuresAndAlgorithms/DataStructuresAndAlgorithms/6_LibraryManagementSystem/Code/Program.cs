using System;

class Program
{
    static void Main(string[] args)
    {
        Book[] books = new Book[]
        {
            new Book { BookId = 1, Title = "Algorithms", Author = "Cormen" },
            new Book { BookId = 2, Title = "Clean Code", Author = "Robert Martin" },
            new Book { BookId = 3, Title = "Design Patterns", Author = "GoF" },
            new Book { BookId = 4, Title = "Refactoring", Author = "Martin Fowler" }
        };

        Console.WriteLine("---- Linear Search ----");
        var result = SearchAlgorithms.LinearSearch(books, "Design Patterns");
        if (result != null)
            Console.WriteLine($"Found: {result.Title} by {result.Author}");
        else
            Console.WriteLine("Book not found.");

        Array.Sort(books, (a, b) => a.Title.CompareTo(b.Title));

        Console.WriteLine("\n---- Binary Search ----");
        result = SearchAlgorithms.BinarySearch(books, "Design Patterns");
        if (result != null)
            Console.WriteLine($"Found: {result.Title} by {result.Author}");
        else
            Console.WriteLine("Book not found.");
    }
}