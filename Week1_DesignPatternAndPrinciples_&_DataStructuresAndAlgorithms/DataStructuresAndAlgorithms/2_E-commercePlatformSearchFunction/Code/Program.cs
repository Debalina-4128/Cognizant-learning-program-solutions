class Program
{
    static void Main(string[] args)
    {
        Product[] products = new Product[]
        {
            new Product { ProductId = 3, ProductName = "Laptop", Category = "Electronics" },
            new Product { ProductId = 1, ProductName = "Table", Category = "Furniture" },
            new Product { ProductId = 4, ProductName = "Phone", Category = "Electronics" },
            new Product { ProductId = 2, ProductName = "Chair", Category = "Furniture" }
        };

        Console.WriteLine("----- Linear Search -----");
        int index = SearchAlgorithms.LinearSearch(products, 4);
        if (index != -1)
            Console.WriteLine($"Product found: {products[index].ProductName}");
        else
            Console.WriteLine("Product not found.");

        Array.Sort(products, (a, b) => a.ProductId.CompareTo(b.ProductId));

        Console.WriteLine("\n----- Binary Search -----");
        index = SearchAlgorithms.BinarySearch(products, 4);
        if (index != -1)
            Console.WriteLine($"Product found: {products[index].ProductName}");
        else
            Console.WriteLine("Product not found.");
    }
}