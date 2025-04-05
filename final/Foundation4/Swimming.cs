public class Swimming : Activity
{
    private int _laps;
    private const double METERS_PER_LAP = 50.0;
    private const double METERS_TO_MILES = 0.000621371;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * METERS_PER_LAP * METERS_TO_MILES;
    }
}