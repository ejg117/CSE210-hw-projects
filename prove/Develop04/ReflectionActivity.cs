using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you did something hard.",
        "Think of a time when you helped someone."
    };
    private List<string> _questions = new List<string>
    {
        "Why did this matter to you?",
        "How did you feel after?"
    };

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on moments of strength in your life.")
    {
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        ShowSpinner(2);

        int timeLeft = GetDuration() - 2; // Account for prompt pause
        while (timeLeft > 0)
        {
            Console.WriteLine(_questions[rand.Next(_questions.Count)]);
            ShowSpinner(2); // 4 seconds per question cycle
            timeLeft -= 4;
        }
    }
}