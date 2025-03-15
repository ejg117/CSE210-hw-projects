using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    // Properties for encapsulation
    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
    public bool IsComplete => _isComplete;

    // Protected method for marking completion
    protected void MarkComplete() => _isComplete = true;

    // Abstract methods for polymorphism
    public abstract void RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    // Virtual method for derived classes to override
    public virtual int GetPointsAwarded()
    {
        return _isComplete ? 0 : _points;
    }
}