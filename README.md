# PIT STOP SHOPPING CENTER

A simple console app to manage products for PIT STOP SHOPPING CENTER.
Made in C# with .NET 10.

## What it does

- Add new products with ID, Category, Name, Price
- List all products sorted by price
- Search products by Name, Category or ID with highlight
- Edit product by ID
- Delete product by ID
- Show statistics (total, average, most expensive, cheapest, per category)
- Save and load data to JSON file

## How to run

1. You need .NET 10 SDK
2. Clone or download the project
3. Run in terminal: dotnet run
4. The app will create products.json automatically

## Check your version

Run this to check:
dotnet --version
Should show 10.x.x

## Project files

If you use multi-file version:
- Models/Product.cs - Product class
- Services/ProductManager.cs - Logic
- Helpers/ConsoleHelper.cs - Colors and input
- Program.cs - Main menu

If you use single file version:
- Program.cs - Everything in one file (beginner friendly)

## Menu

PIT STOP SHOPPING CENTER
1. Add Product
2. List Products
3. Search Product
4. Edit Product
5. Delete Product
6. Statistics
7. Save
0. Exit

## Example data

products.json looks like this:
[
  {
    "Id": 1,
    "Category": "Drinks",
    "Name": "Pepsi",
    "Price": 15.5,

  }
]

## Features used

- List<Product> for storage
- LINQ: OrderBy, Sum, Where, Average, GroupBy, FirstOrDefault
- TryParse for error handling
- System.Text.Json for save/load
- DateTime for CreatedAt
- required keyword (.NET 8/10 feature)

