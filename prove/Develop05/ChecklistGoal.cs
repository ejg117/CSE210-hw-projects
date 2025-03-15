public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            _currentCount++;
            if (_currentCount >= _targetCount)
            {
                MarkComplete();
            }
        }
    }

    public override string GetDetailsString()
    {
        return $"[{ (IsComplete ? "X" : " ") }] {Name} ({Description}) -- Currently completed: {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{_targetCount},{_bonusPoints},{_currentCount}";
    }

    public override int GetPointsAwarded()
    {
        if (IsComplete && _currentCount == _targetCount)
        {
            return Points + _bonusPoints; 
        }
        return IsComplete ? 0 : Points;
    }
}