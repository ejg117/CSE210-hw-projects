using System;

namespace AbstractionActivity
{
    // A class representing a professional's LinkedIn profile
    public class LinkedInProfile
    {
        // Attributes (state)
        public string FullName;
        public string JobTitle;
        public string CompanyName;

        // Constructor: Initializes a new LinkedInProfile object
        public LinkedInProfile(string fullName, string jobTitle, string companyName)
        {
            FullName = fullName;
            JobTitle = jobTitle;
            CompanyName = companyName;
        }

        // Behavior: Displays the profile summary
        public void DisplayProfile()
        {
            Console.WriteLine("LinkedIn Profile Summary:");
            Console.WriteLine($"Name: {FullName}");
            Console.WriteLine($"Job Title: {JobTitle}");
            Console.WriteLine($"Company: {CompanyName}");
        }
    }

    // A class representing a blind (unchanged for this example)
    public class Blind
    {
        public double Width;
        public double Height;
        public string Color;

        public Blind(double width, double height, string color)
        {
            Width = width;
            Height = height;
            Color = color;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Width: {Width} inches");
            Console.WriteLine($"Height: {Height} inches");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Area: {GetArea()} square inches");
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1: Using the LinkedInProfile class
            Console.WriteLine("### LinkedIn Profile Example ###");
            LinkedInProfile profile1 = new LinkedInProfile(
                "John Doe",
                "Software Engineer",
                "TechCorp Inc."
            );

            LinkedInProfile profile2 = new LinkedInProfile(
                "Jane Smith",
                "Data Scientist",
                "DataAnalytics LLC"
            );

            Console.WriteLine("Profile 1:");
            profile1.DisplayProfile();

            Console.WriteLine("\nProfile 2:");
            profile2.DisplayProfile();

            // Part 2: Using the Blind class
            Console.WriteLine("\n### Blind Example ###");
            Blind officeBlind = new Blind(72, 48, "Blue");

            Console.WriteLine("Blind Details:");
            officeBlind.DisplayDetails();
        }
    }
}