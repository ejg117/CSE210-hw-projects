using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people you appreciate?",
        "What are your strengths?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity will help you list positive things in your life.")
    {
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.Write("Start thinking...");
        ShowSpinner(2);
        Console.WriteLine();

        Console.WriteLine("List items (press Enter after each, 'done' to finish):");
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration() - 2); // Adjust for initial pause

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;
            if (!string.IsNullOrEmpty(input)) items.Add(input);
        }

        Console.WriteLine($"You listed {items.Count} items.");
    }
}