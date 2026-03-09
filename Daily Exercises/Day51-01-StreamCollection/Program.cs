namespace StreamCollection
{
    class CreatorStats
    {
        public string CreatorName { get; set; }
        public double[] WeeklyLikes { get; set; }

        public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    }
    internal class Program
    {

        public void RegisterCreator(CreatorStats record)
        {
            CreatorStats.EngagementBoard.Add(record);
            Console.WriteLine("creator registered successfully");

        }
        public Dictionary<string, int> GetTopPostsCounts(List<CreatorStats> records, double likeThreshold)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var i in records)
            {
                int count = 0;

                foreach (var like in i.WeeklyLikes)
                {
                    if (like >= likeThreshold)
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    dict.Add(i.CreatorName, count);
                }
            }
            return dict;

        }

        public double CalculateAverageLikes()
        {
            int totalweeks = 0;
            double totallikes = 0;
            foreach (var i in CreatorStats.EngagementBoard)
            {
                foreach (var j in i.WeeklyLikes)
                {
                    totallikes += j;
                    totalweeks++;
                }
            }
            if (totalweeks == 0) return 0;
            return totallikes / totalweeks;
        }



        static void Main(string[] args)
        {
            Program program = new Program();
            int choice;

            while (true)
            {
                Console.WriteLine("\n1. Register Creator");
                Console.WriteLine("2. Show Top Posts");
                Console.WriteLine("3. Calculate Average Likes");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter Creator Name:");
                    string creatorName = Console.ReadLine();

                    double[] weeklyLikes = new double[4];

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");

                    for (int i = 0; i < 4; i++)
                    {
                        weeklyLikes[i] = double.Parse(Console.ReadLine());
                    }

                    CreatorStats creator = new CreatorStats
                    {
                        CreatorName = creatorName,
                        WeeklyLikes = weeklyLikes
                    };

                    program.RegisterCreator(creator);
                }

                else if (choice == 2)
                {
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    Dictionary<string, int> topPosts =
                        program.GetTopPostsCounts(CreatorStats.EngagementBoard, threshold);

                    if (topPosts.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in topPosts)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                    }
                }

                else if (choice == 3)
                {
                    double avgLikes = program.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + avgLikes);
                }

                else if (choice == 4)
                {
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    break;
                }
            }
        }
    }
}
    