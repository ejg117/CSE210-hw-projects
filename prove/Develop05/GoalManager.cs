using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();
            int points = goal.GetPointsAwarded();
            _score += points;
            Console.WriteLine($"Congratulations! You have earned {points} points!");
            Console.WriteLine($"Total Points: {_score}");
            UpdateLevel();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    private void UpdateLevel()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel != _level)
        {
            _level = newLevel;
            Console.WriteLine($"Congratulations! You've leveled up to {GetLevelTitle()}!");
        }
    }

    private string GetLevelTitle()
    {
        string[] titles = {
            "Level 1 Novice", "Level 2 Seeker", "Level 3 Disciple", "Level 4 Faithful",
            "Level 5 Servant", "Level 6 Shepherd", "Level 7 Warrior", "Level 8 Guardian",
            "Level 9 Saint", "Level 10 Celestial Warrior"
        };
        return titles[Math.Min(_level - 1, titles.Length - 1)];
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. { _goals[i].GetDetailsString()}");
        }
        Console.WriteLine($"\nYour score is: {_score}");
        Console.WriteLine($"Level: {GetLevelTitle()}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);
            _goals.Clear();

            for (int i = 2; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] details = parts[1].Split(",");

                Goal goal = CreateGoal(type, details);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved file found. Starting with an empty list.");
        }
    }

    private Goal CreateGoal(string type, string[] details)
    {
        string name = details[0];
        string description = details[1];
        int points = int.Parse(details[2]);

        switch (type)
        {
            case "SimpleGoal":
                bool isComplete = bool.Parse(details[3]);
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                if (isComplete) simpleGoal.RecordEvent();
                return simpleGoal;
            case "EternalGoal":
                return new EternalGoal(name, description, points);
            case "ChecklistGoal":
                int targetCount = int.Parse(details[3]);
                int bonusPoints = int.Parse(details[4]);
                int currentCount = int.Parse(details[5]);
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, targetCount, bonusPoints);
                for (int i = 0; i < currentCount; i++)
                {
                    checklistGoal.RecordEvent();
                }
                return checklistGoal;
            default:
                return null;
        }
    }
}