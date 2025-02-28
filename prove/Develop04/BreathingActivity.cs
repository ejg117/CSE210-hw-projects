using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity",
        "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    protected override void PerformActivity()
    {
        int timeLeft = GetDuration();
        while (timeLeft > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(2); // 4 seconds total per cycle
            timeLeft -= 4;

            if (timeLeft <= 0) break;

            Console.WriteLine("Breathe out...");
            ShowSpinner(2);
            timeLeft -= 4;
        }
    }
}