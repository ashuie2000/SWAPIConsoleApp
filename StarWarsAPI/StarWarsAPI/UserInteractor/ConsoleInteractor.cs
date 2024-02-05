using System;
using StarWarsAPI.Models;

namespace StarWarsAPI.UserInteractor
{
    public class ConsoleInteractor : IConsoleInteractor
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }


        public string GetValidUserChoice(IEnumerable<string> properties)
        {
            string? choice = Console.ReadLine();

            while (choice is null || !properties.Contains(choice))
            {
                PrintMessage("Invalid Choice. Please choose a valid property.");
                choice = Console.ReadLine();
            }

            return choice;
        }

        public void PrintTable<T>(IEnumerable<T> data)
        {
            UnviersalPrinter.Print(data);
        }
    }
}

