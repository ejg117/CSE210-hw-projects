using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        int timeLeft = GetDuration();
        while (timeLeft > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(5); 
            timeLeft -= 5;

            if (timeLeft <= 0) break;

            Console.WriteLine("Breathe out...");
            ShowCountdown(5); 
            timeLeft -= 5;
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} seconds remaining    ");
            Thread.Sleep(1000); 
        }
        Console.Write("\r" + new string(' ', 20) + "\r"); 
    }
}