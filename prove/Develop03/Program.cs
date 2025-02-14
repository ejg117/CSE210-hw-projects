using System;
using System.Collections.Generic;

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

        while (true)
        {
            scripture.Display();
            Console.Write("\nPress Enter to hide words or type 'quit' to exit: ");
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "quit" || !scripture.HideWords()) break;
        }

        Console.WriteLine("\nAll words hidden. Program ended.");
    }
}