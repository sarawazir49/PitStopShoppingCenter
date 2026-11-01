using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using PitStopShoppingCenter.Models;
using PitStopShoppingCenter.Helpers;

namespace PitStopShoppingCenter.Services
{
    public class ProductManager
    {
        private List<Product> products = new List<Product>();
        private int nextId = 1;
        private readonly string filePath = "products.json";

        public ProductManager() => LoadFromFile();

        public void AddProduct()
        {
            ConsoleHelper.PrintHeader("Add New Product - PIT STOP");
            var product = new Product
            {
                Id = nextId++,
                Category = ConsoleHelper.ReadNonEmpty("Category: "),
                Name = ConsoleHelper.ReadNonEmpty("Product Name: "),
                Price = ConsoleHelper.ReadPrice("Price: ")
            };
            products.Add(product);
            ConsoleHelper.Success($"Added to PIT STOP SHOPPING CENTER - ID: {product.Id}");
        }

        public void ListProducts()
        {
            if (!products.Any())
            {
                ConsoleHelper.Error("No products in PIT STOP SHOPPING CENTER.");
                return;
            }

            var sorted = products.OrderBy(p => p.Price).ToList();
            ConsoleHelper.PrintHeader($"PIT STOP SHOPPING CENTER - {products.Count} Products");
            Console.WriteLine($"{"ID",-4} | {"Category",-12} | {"Name",-18} | {"Price",9}");
            Console.WriteLine(new string('-', 55));
            foreach (var p in sorted) Console.WriteLine(p);
            Console.WriteLine(new string('-', 55));
            Console.WriteLine($"TOTAL: {products.Sum(p => p.Price):C}");
        }

       
        public void SearchProduct()
        {
            if (!products.Any())
            {
                ConsoleHelper.Error("No products.");
                return;
            }

            Console.Write("\nSearch (Name/Category/ID): ");
         
            string? rawInput = Console.ReadLine();
          
            string term = rawInput?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(term))
            {
                ConsoleHelper.Error("Search term cannot be empty!");
                return;
            }

            var results = products.Where(p =>
                p.Name.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                p.Category.Contains(term, StringComparison.CurrentCultureIgnoreCase) ||
                p.Id.ToString() == term
            ).ToList();

            if (!results.Any())
            {
                ConsoleHelper.Error($"Not found '{term}'");
                return;
            }

            ConsoleHelper.PrintHeader($"Found {results.Count}");
            foreach (var p in products.OrderBy(p => p.Price))
            {
                if (results.Contains(p))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($" >> {p} << FOUND");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"    {p}");
                }
            }
        }

        public void EditProduct()
        {
            if (!products.Any()) return;
            ListProducts();
            int id = ConsoleHelper.ReadInt("ID to edit: ");
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) { ConsoleHelper.Error("Not found."); return; }

            Console.Write($"New Category [{product.Category}]: ");
            string? c = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(c)) product.Category = c;

            Console.Write($"New Name [{product.Name}]: ");
            string? n = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(n)) product.Name = n;

            Console.Write($"New Price [{product.Price}]: ");
            string? s = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(s) && decimal.TryParse(s, out decimal np) && np > 0) product.Price = np;

            ConsoleHelper.Success("Updated!");
        }

        public void DeleteProduct()
        {
            if (!products.Any()) return;
            ListProducts();
            int id = ConsoleHelper.ReadInt("ID to delete: ");
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p == null) { ConsoleHelper.Error("Not found."); return; }

            Console.Write($"Delete '{p.Name}'? (y/n): ");
        
            string? answer = Console.ReadLine();
            if (answer != null && answer.ToLower() == "y")
            {
                products.Remove(p);
                ConsoleHelper.Success("Deleted from PIT STOP SHOPPING CENTER.");
            }
        }

        public void ShowStatistics()
        {
            if (!products.Any()) { ConsoleHelper.Error("No data."); return; }
            ConsoleHelper.PrintHeader("PIT STOP SHOPPING CENTER - Statistics");
            Console.WriteLine($"Total Products : {products.Count}");
            Console.WriteLine($"Total Value    : {products.Sum(p => p.Price):C}");
            Console.WriteLine($"Average Price  : {products.Average(p => p.Price):C}");
            Console.WriteLine($"Most Expensive : {products.OrderByDescending(p => p.Price).First()}");
            Console.WriteLine($"Cheapest       : {products.OrderBy(p => p.Price).First()}");
            Console.WriteLine("\n--- Per Category ---");
            foreach (var g in products.GroupBy(p => p.Category))
            {
                Console.WriteLine($"- {g.Key,-12} : {g.Count()} items | {g.Sum(x => x.Price):C}");
            }
        }

        public void SaveToFile()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true }));
            ConsoleHelper.Success($"Saved {products.Count} products to {filePath}");
        }

        public void LoadFromFile()
        {
            if (!File.Exists(filePath)) return;
            try
            {
                var loaded = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(filePath));
                if (loaded != null && loaded.Any())
                {
                    products = loaded;
                    nextId = products.Max(p => p.Id) + 1;
                }
            }
            catch { }
        }
    }
}