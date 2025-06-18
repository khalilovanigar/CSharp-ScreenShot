using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {

        System.Console.WriteLine("Select your operating system:");
        System.Console.WriteLine("1 - macOS");
        System.Console.WriteLine("2 - Windows");
        System.Console.Write("Enter your choice (1 or 2): ");

        string choice = Console.ReadLine()!;

        if (choice == "2")
        {
            System.Console.WriteLine("This program is not suitable for Windows,exit from program.");
            return;
        }
        else if (choice != "1")
        {
            System.Console.WriteLine("Wrong input,existing from program.");
            return;
        }

        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string imagesPath = Path.Combine(desktop, "Images");

        if (!Directory.Exists(imagesPath))
            Directory.CreateDirectory(imagesPath);

        System.Console.WriteLine("Click enter to screenshot. Click ESC to exit");

        while (true)
        {
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Enter)
            {
                string fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string fullPath = Path.Combine(imagesPath, fileName);

                
                Process.Start("screencapture", $"\"{fullPath}\"");

                System.Console.WriteLine($"ScreenShot saved successfully!: {fileName}");
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
        
        System.Console.WriteLine();

        System.Console.WriteLine("Photos on image folder:");
        string[] files = Directory.GetFiles(imagesPath, "*.png");
        foreach (string file in files)
        {
            System.Console.WriteLine(Path.GetFileName(file));
        }
    }
}
