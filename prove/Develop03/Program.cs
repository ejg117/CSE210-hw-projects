using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        List<(string, int, int, string)> scriptures = new List<(string, int, int, string)>
        {
            ("John", 3, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            ("Proverbs", 3, 5, "Trust in the Lord with all thine heart; and lean not unto thine own understanding."),
            ("Philippians", 4, 13, "I can do all things through Christ which strengtheneth me.")
        };

        Random random = new Random();
        var selected = scriptures[random.Next(scriptures.Count)];
        var reference = new ScriptureReference(selected.Item1, selected.Item2, selected.Item3);
        var scripture = new Scripture(reference, selected.Item4);

        Console.Clear();
        Console.WriteLine("\n✨ Welcome to Scripture Memorization ✨");
        Console.WriteLine("=====================================");

        while (true)
        {
            Console.WriteLine("\n Current Scripture:");
            scripture.Display();
            Console.WriteLine("\n-------------------------------------");

            Console.Write("🔹 Press Enter to hide words, or type 'quit' to exit: ");
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "quit") 
            {
                Console.Write("\nAre you sure you want to quit? (yes/no): ");
                if (Console.ReadLine().Trim().ToLower() == "yes") break;
                Console.WriteLine("\n Keep going! You're doing great!\n");
                continue;
            }

            // Add a 'Loading' effect
            Console.Write("\nHiding words");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine("\n");

            if (!scripture.HideWords()) break;

            Console.Clear();
            Console.WriteLine("\n Keep Going! You're strengthening your memory! ");
            Console.WriteLine("===============================================");
        }

        Console.WriteLine("\nCongratulations! You've completed the scripture memorization!");
    }
}