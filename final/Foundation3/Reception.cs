public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, 
                    Address address, string rsvpEmail)
        : base(title, description, dateTime, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               "Type: Reception\n" +
               $"RSVP Email: {_rsvpEmail}";
    }
}