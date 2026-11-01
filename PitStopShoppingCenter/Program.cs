using System;
using PitStopShoppingCenter.Helpers;
using PitStopShoppingCenter.Services;


ProductManager manager = new ProductManager();
bool running = true;

// Main application loop - keeps running until user chooses Exit
while (running)
{
    // Clear screen for clean menu 
    Console.Clear();
    // Show PIT STOP SHOPPING CENTER logo
    ConsoleHelper.ShowLogo();
  

    //  menu system
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. List Products");
    Console.WriteLine("3. Search Product");
    Console.WriteLine("4. Edit Product");
    Console.WriteLine("5. Delete Product");
    Console.WriteLine("6. Statistics Dashboard");
    Console.WriteLine("7. Save");
    Console.WriteLine("0. Exit & Auto-Save");
    Console.WriteLine("--------------------------------------------------");
    Console.Write("PIT STOP SHOPPING CENTER > Select: ");


    string? choice = Console.ReadLine();


    // Switch handles menu selection - cleaner than many if/else
    switch (choice)
    {
        case "1": manager.AddProduct(); break;
        case "2": manager.ListProducts(); break;
        case "3": manager.SearchProduct(); break;
        case "4": manager.EditProduct(); break;
        case "5": manager.DeleteProduct(); break;
        case "6": manager.ShowStatistics(); break;
        case "7": manager.SaveToFile(); break;
        case "0":

            manager.SaveToFile();
            running = false; // Break the loop
            Console.WriteLine("Thank you - PIT STOP SHOPPING CENTER");
            continue;
        default:
            ConsoleHelper.Error("Invalid selection! Choose 0-7");
            break;
    }



    if (running)
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}
