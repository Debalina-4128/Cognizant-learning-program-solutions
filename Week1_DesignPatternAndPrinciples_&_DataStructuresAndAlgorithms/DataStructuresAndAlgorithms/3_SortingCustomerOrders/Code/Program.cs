using System;

class Program
{
    static void Main(string[] args)
    {
        Order[] orders = new Order[]
        {
            new Order { OrderId = 1, CustomerName = "John", TotalPrice = 250.00 },
            new Order { OrderId = 2, CustomerName = "Alice", TotalPrice = 120.00 },
            new Order { OrderId = 3, CustomerName = "Bob", TotalPrice = 500.00 },
            new Order { OrderId = 4, CustomerName = "Daisy", TotalPrice = 300.00 }
        };

        Console.WriteLine("Original Orders:");
        DisplayOrders(orders);

        // Bubble Sort
        BubbleSort.Sort(orders);
        Console.WriteLine("\nOrders Sorted by Bubble Sort:");
        DisplayOrders(orders);

        orders = new Order[]
        {
            new Order { OrderId = 1, CustomerName = "John", TotalPrice = 250.00 },
            new Order { OrderId = 2, CustomerName = "Alice", TotalPrice = 120.00 },
            new Order { OrderId = 3, CustomerName = "Bob", TotalPrice = 500.00 },
            new Order { OrderId = 4, CustomerName = "Daisy", TotalPrice = 300.00 }
        };

        // Quick Sort
        QuickSort.Sort(orders, 0, orders.Length - 1);
        Console.WriteLine("\nOrders Sorted by Quick Sort:");
        DisplayOrders(orders);
    }

    static void DisplayOrders(Order[] orders)
    {
        foreach (var order in orders)
        {
            Console.WriteLine($"OrderID: {order.OrderId}, Customer: {order.CustomerName}, TotalPrice: {order.TotalPrice}");
        }
    }
}