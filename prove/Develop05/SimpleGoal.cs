public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            MarkComplete();
        }
    }

    public override string GetDetailsString()
    {
        return $"[{ (IsComplete ? "X" : " ") }] {Name} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{IsComplete}";
    }
}