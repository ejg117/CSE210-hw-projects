using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private Dictionary<string, List<string>> _promptQuestions = new Dictionary<string, List<string>>
    {
        {
            "Think of a time when you stood up for someone else.",
            new List<string> { "Why was this experience meaningful to you?", "How did you feel when it was complete?" }
        },
        {
            "Think of a time when you did something really difficult.",
            new List<string> { "How did you feel when it was complete?", "What is your favorite thing about this experience?" }
        },
        {
            "Think of a time when you helped someone in need.",
            new List<string> { "Why was this experience meaningful to you?", "How did you feel when it was complete?" }
        },
        {
            "Think of a time when you did something truly selfless.",
            new List<string> { "What is your favorite thing about this experience?", "How did you feel when it was complete?" }
        }
    };

    public ReflectionActivity() : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        string selectedPrompt = _prompts[rand.Next(_prompts.Count)];
        Console.Write("Press Enter when ready to reflect...");
        Console.ReadLine(); 
        Console.WriteLine(selectedPrompt); 

    
        ShowLoadingBar(5); 

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration()); 

        List<string> questions = _promptQuestions[selectedPrompt];
        int questionCount = 0;
        int totalQuestions = questions.Count;
        double totalTimeAvailable = GetDuration(); 

        while (DateTime.Now < endTime && questionCount < totalQuestions)
        {
            if (endTime.Subtract(DateTime.Now).TotalSeconds < 5) break; 
            Console.WriteLine(questions[questionCount]);
            ShowLoadingBar(5); 
            questionCount++;

            double remainingTime = endTime.Subtract(DateTime.Now).TotalSeconds;
            if (remainingTime > 0 && questionCount < totalQuestions)
            {
                double timePerRemaining = remainingTime / (totalQuestions - questionCount + 1);
                double pauseTime = Math.Max(0, timePerRemaining - 5); 
                if (pauseTime > 0)
                {
                    Thread.Sleep((int)(pauseTime * 1000)); 
                }
            }
        }
    }
}