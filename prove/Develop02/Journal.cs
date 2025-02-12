using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private static readonly List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void WriteEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.ResetColor();

        Console.Write("Your response: ");
        string response = Console.ReadLine();

        entries.Add(new JournalEntry(prompt, response));

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Entry saved successfully!\n");
        Console.ResetColor();
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNo journal entries yet.\n");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nJournal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
        Console.ResetColor();
        Console.WriteLine();
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry);
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Journal saved successfully!\n");
        Console.ResetColor();
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File not found. Please check the filename and try again.\n");
            Console.ResetColor();
            return;
        }

        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                entries.Add(new JournalEntry(parts[1].Trim(), parts[2].Trim()) { Date = parts[0].Trim() });
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Journal loaded successfully!\n");
        Console.ResetColor();
    }
}