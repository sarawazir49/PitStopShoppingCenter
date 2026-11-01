using System;

namespace PitStopShoppingCenter.Models
{
 
    public class Product
    {
        
        public int Id { get; set; }

        // Product Category e.g. Food, Drinks, Electronics
        public required string Category { get; set; }

        // Product Name e.g. Coca-Cola, Bread
        public required string Name { get; set; }

        // Product Price - using decimal for money (more accurate than double)
        public decimal Price { get; set; }

        // When product was added - useful for statistics
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Override ToString() to control how product is printed in console
        // Format: ID | Category | Name | Price | Created
        public override string ToString() => $"{Id,-4} | {Category,-12} | {Name,-18} | {Price,9:C}  | {CreatedAt:yyyy-MM-dd}";
    }
}
