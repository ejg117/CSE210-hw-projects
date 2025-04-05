class Program
{
    static void Main(string[] args)
    {
        Address lectureAddress = new Address("123 Main St", "Boston", "MA", "02108");
        Lecture lecture = new Lecture(
            "AI Future", 
            "Discussion about AI advancements",
            new DateTime(2025, 5, 1, 14, 0, 0),
            lectureAddress,
            "Dr. Jane Smith",
            100
        );

        Address receptionAddress = new Address("456 Oak Ave", "Chicago", "IL", "60601");
        Reception reception = new Reception(
            "Company Gala",
            "Annual celebration dinner",
            new DateTime(2025, 6, 15, 19, 0, 0),
            receptionAddress,
            "rsvp@company.com"
        );

        Address outdoorAddress = new Address("789 Park Rd", "Denver", "CO", "80202");
        OutdoorGathering outdoor = new OutdoorGathering(
            "Summer Festival",
            "Outdoor music and food event",
            new DateTime(2025, 7, 4, 12, 0, 0),
            outdoorAddress,
            "Sunny, 75°F"
        );

        Event[] events = { lecture, reception, outdoor };
        
        foreach (Event evt in events)
        {
            Console.WriteLine("\nSTANDARD DETAILS:");
            Console.WriteLine(evt.GetStandardDetails());
            Console.WriteLine("\nFULL DETAILS:");
            Console.WriteLine(evt.GetFullDetails());
            Console.WriteLine("\nSHORT DESCRIPTION:");
            Console.WriteLine(evt.GetShortDescription());
            Console.WriteLine("\n" + new string('-', 50));
        }
    }
}