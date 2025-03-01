using System;
using System.Threading;

abstract class Activity
{
    private string _activityName;
    private string _description;
    private int _duration;

    public Activity(string activityName, string description)
    {
        _activityName = activityName;
        _description = description;
    }

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}!");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How many seconds for this session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Write("Prepare to begin...");
        ShowLoadingBar(2); 
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowLoadingBar(2); 
        Console.WriteLine($"You completed {_duration} seconds of the {_activityName}.");
    }

    protected void ShowLoadingBar(int seconds)
    {
        int barWidth = 20;
        int totalIterations = seconds * 10; 

        for (int i = 0; i <= totalIterations; i++)
        {
            double progress = (double)i / totalIterations;
            int filledWidth = (int)(progress * barWidth);
            
            Console.Write("\r"); 
            Console.Write(new string('█', filledWidth)); 
            Console.Write(new string(' ', barWidth - filledWidth)); 
            
            Thread.Sleep(100); 
        }
        Console.Write("\r" + new string(' ', barWidth) + "\r"); 
    }

    protected int GetDuration()
    {
        return _duration;
    }

    abstract protected void PerformActivity();
}