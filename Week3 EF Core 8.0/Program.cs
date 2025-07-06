using RetailInventory;
using RetailInventory.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Dynamic;

using var context = new AppDbContext();

var electronics = new Category
{
    Name = "Electronics"
};

var groceries = new Category
{
    Name = "Groceries"
};

await context.Categories.AddRangeAsync(electronics, groceries);

var product1 = new Product
{
    Name = "Laptop",
    Price = 75000,
    Category = electronics
};
var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

await context.Products.AddRangeAsync(product1, product2);
await context.SaveChangesAsync();


var products = await context.Products.ToListAsync();
foreach (var p in products)
    Console.WriteLine($"{p.Name} - {p.Price}");

var foundById = await context.Products.FindAsync(1);
Console.WriteLine($"Found: {foundById?.Name}");

var expensive = await context.Products.FirstOrDefaultAsync(product => product.Price > 50000);
Console.WriteLine($"Expensive: {expensive?.Name}");


var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
if (product != null)
{
    product.Price = 70000;
    await context.SaveChangesAsync();
}

var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
if(toDelete != null)
{
    context.Products.Remove(toDelete);
    await context.SaveChangesAsync();
}


var filtered = await context.Products
    .Where(p => p.Price > 10000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();

Console.WriteLine("Filtered and Sorted Products:");
foreach (var p in filtered)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");

var productDTOs = await context.Products
    .Select(p=>new {p.Name, p.Price})
    .ToListAsync();

Console.WriteLine("\nProduct DTOs:");
foreach (var dto in productDTOs)
    Console.WriteLine($"{dto.Name} - ₹{dto.Price}");


var load = await context.Products
    .Include(p => p.Category)
    .ToListAsync();

var exLoad = await context.Products.FirstAsync();
await context.Entry(product).Reference(p => p.Category).LoadAsync();



