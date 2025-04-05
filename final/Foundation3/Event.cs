public abstract class Event
{
    private string _title;
    private string _description;
    private DateTime _dateTime;
    private Address _address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        _title = title;
        _description = description;
        _dateTime = dateTime;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\n" +
               $"Description: {_description}\n" +
               $"Date: {_dateTime.ToString("MMMM dd, yyyy")}\n" +
               $"Time: {_dateTime.ToString("hh:mm tt")}\n" +
               $"Address: {_address.GetFullAddress()}";
    }

    public abstract string GetFullDetails();

    public virtual string GetShortDescription()
    {
        return $"{GetType().Name}: {_title} on {_dateTime.ToString("MMMM dd, yyyy")}";
    }
}