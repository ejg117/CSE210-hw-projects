public class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, DateTime dateTime, 
                          Address address, string weatherForecast)
        : base(title, description, dateTime, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               "Type: Outdoor Gathering\n" +
               $"Weather Forecast: {_weatherForecast}";
    }
}