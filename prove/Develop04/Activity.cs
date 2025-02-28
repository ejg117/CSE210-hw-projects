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
        ShowSpinner(2);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        ShowSpinner(2);
        Console.WriteLine($"You completed {_duration} seconds of the {_activityName}.");
        ShowSpinner(2);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("|");
            Thread.Sleep(500);
            Console.Write("\b/");
            Thread.Sleep(500);
            Console.Write("\b-");
            Thread.Sleep(500);
            Console.Write("\b\\");
            Thread.Sleep(500);
            Console.Write("\b");
        }
    }

    protected int GetDuration()
    {
        return _duration;
    }

    abstract protected void PerformActivity();
}