using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InventoryManager
{
    private Dictionary<int, Product> _inventory = new Dictionary<int, Product>();

    public void AddProduct(Product product)
    {
        if (_inventory.ContainsKey(product.ProductId))
        {
            Console.WriteLine("Product already exists.");
            return;
        }
        _inventory[product.ProductId] = product;
        Console.WriteLine("Product added successfully.");
    }

    public void UpdateProduct(Product product)
    {
        if (_inventory.ContainsKey(product.ProductId))
        {
            _inventory[product.ProductId] = product;
            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DeleteProduct(int productId)
    {
        if (_inventory.ContainsKey(productId))
        {
            _inventory.Remove(productId);
            Console.WriteLine("Product deleted successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DisplayInventory()
    {
        Console.WriteLine("\nInventory:");
        foreach (var item in _inventory.Values)
        {
            Console.WriteLine($"ID: {item.ProductId}, Name: {item.ProductName}, Quantity: {item.Quantity}, Price: {item.Price}");
        }
        Console.WriteLine();
    }
}