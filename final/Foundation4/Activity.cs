public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual double GetDistance()
    {
        return 0.0;
    }

    public virtual double GetSpeed()
    {
        double distance = GetDistance();
        return distance > 0 ? (distance / _minutes) * 60 : 0.0;
    }

    public virtual double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? _minutes / distance : 0.0;
    }

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }

    protected int GetMinutes()
    {
        return _minutes;
    }
}