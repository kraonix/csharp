using System;
using System.Collections.Generic;

namespace StreamBuzzApp
{
    // Class to store creator details
    public class CreatorStats
    {
        // Name of the creator
        public string CreatorName { get; set; }

        // Weekly likes for 4 weeks
        public double[] WeeklyLikes { get; set; }
    }

    public class Program
    {
        // Static list to store all creator records
        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

        // Method to register a creator into the EngagementBoard
        public void RegisterCreator(CreatorStats record)
        {
            EngagementBoard.Add(record);
        }

        // Method to count weeks where likes meet or exceed the threshold
        public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            // Iterate through each creator
            foreach (CreatorStats creator in records)
            {
                int count = 0;

                // Count weeks meeting the threshold
                foreach (double likes in creator.WeeklyLikes)
                {
                    if (likes >= likeThreshold)
                    {
                        count++;
                    }
                }

                // Add creator only if at least one week meets the condition
                if (count > 0)
                {
                    result.Add(creator.CreatorName, count);
                }
            }

            return result;
        }

        // Method to calculate average of all weekly likes
        public double CalculateAverageLikes()
        {
            double totalLikes = 0;
            int totalWeeks = 0;

            // Sum all likes across all creators
            foreach (CreatorStats creator in EngagementBoard)
            {
                foreach (double likes in creator.WeeklyLikes)
                {
                    totalLikes += likes;
                    totalWeeks++;
                }
            }

            // Avoid division by zero
            if (totalWeeks == 0)
            {
                return 0;
            }

            return totalLikes / totalWeeks;
        }

        // Main method
        public static void Main(string[] args)
        {
            Program program = new Program();
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("1. Register Creator");
                Console.WriteLine("2. Show Top Posts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Register creator
                        CreatorStats creator = new CreatorStats();

                        Console.WriteLine("Enter Creator Name:");
                        creator.CreatorName = Console.ReadLine();

                        creator.WeeklyLikes = new double[4];
                        Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                        for (int i = 0; i < 4; i++)
                        {
                            creator.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                        }

                        program.RegisterCreator(creator);
                        Console.WriteLine("Creator registered successfully");
                        break;

                    case 2:
                        // Show top posts
                        Console.WriteLine("Enter like threshold:");
                        double threshold = Convert.ToDouble(Console.ReadLine());

                        Dictionary<string, int> topPosts =
                            program.GetTopPostCounts(EngagementBoard, threshold);

                        if (topPosts.Count == 0)
                        {
                            Console.WriteLine("No top-performing posts this week");
                        }
                        else
                        {
                            foreach (KeyValuePair<string, int> item in topPosts)
                            {
                                Console.WriteLine(item.Key + " - " + item.Value);
                            }
                        }
                        break;

                    case 3:
                        // Calculate average likes
                        double average = program.CalculateAverageLikes();
                        Console.WriteLine("Overall average weekly likes: " + average);
                        break;

                    case 4:
                        // Exit program
                        Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}