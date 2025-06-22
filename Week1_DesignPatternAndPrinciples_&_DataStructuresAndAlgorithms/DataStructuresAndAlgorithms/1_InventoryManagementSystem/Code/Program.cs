using System;

class Program
{
    static void Main(string[] args)
    {
        InventoryManager inventory = new InventoryManager();

        Product product1 = new Product { ProductId = 1, ProductName = "Laptop", Quantity = 10, Price = 50000 };
        Product product2 = new Product { ProductId = 2, ProductName = "Mouse", Quantity = 50, Price = 500 };

        inventory.AddProduct(product1);
        inventory.AddProduct(product2);

        inventory.DisplayInventory();

        product1.Price = 48000;
        inventory.UpdateProduct(product1);

        inventory.DisplayInventory();

        inventory.DeleteProduct(2);
        inventory.DisplayInventory();
    }
}