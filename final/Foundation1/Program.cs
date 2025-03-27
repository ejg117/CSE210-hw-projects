using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store videos
            List<Video> videos = new List<Video>();

            // Video 1: Python Tutorial
            Video video1 = new Video("Python Tutorial", "TechGuru", 600);
            video1.AddComment(new Comment("Alice", "Great tutorial!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
            video1.AddComment(new Comment("Charlie", "Can you cover more topics?"));
            videos.Add(video1);

            // Video 2: DIY Crafts
            Video video2 = new Video("DIY Crafts", "CraftyMom", 450);
            video2.AddComment(new Comment("Dave", "Love the ideas!"));
            video2.AddComment(new Comment("Eve", "So creative!"));
            video2.AddComment(new Comment("Frank", "I tried this and it worked!"));
            videos.Add(video2);

            // Video 3: Gaming Highlights
            Video video3 = new Video("Gaming Highlights", "GamerPro", 300);
            video3.AddComment(new Comment("Grace", "Epic gameplay!"));
            video3.AddComment(new Comment("Hank", "What game is this?"));
            video3.AddComment(new Comment("Ivy", "You’re the best!"));
            videos.Add(video3);

            // Display each video and its comments
            foreach (Video video in videos)
            {
                Console.WriteLine(video);
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"  - {comment}");
                }
                Console.WriteLine();
            }
        }
    }
}