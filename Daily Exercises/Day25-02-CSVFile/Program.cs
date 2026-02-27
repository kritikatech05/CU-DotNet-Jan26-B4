using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Player
    {
        public string Name { get; set; }

        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }

        public void CalculateStats()
        {
            try
            {
                if (BallsFaced == 0)
                    throw new DivideByZeroException();

                StrikeRate = (double)RunsScored / BallsFaced * 100;
            }

            catch (DivideByZeroException e)
            {
                Console.WriteLine("Cannot calculate strike rate: " + e.Message);
                StrikeRate = 0;
            }

            if (!IsOut)
                Average = RunsScored;
            else
                Average = RunsScored;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

           

            List<Player> players = new List<Player>();

            Console.WriteLine("enter csv file :");
            string path = Console.ReadLine();
            try
            {
                using StreamReader sr = new StreamReader(path);
                string data;
                while ((data = sr.ReadLine()) != null)
                {
                    try
                    {
                        string[] input = data.Split(",");

                        Player player = new Player()
                        {
                            Name = input[0],
                            RunsScored = int.Parse(input[1]),
                            BallsFaced = int.Parse(input[2]),
                            IsOut = bool.Parse(input[3])
                        };
                        player.CalculateStats();

                        if (player.BallsFaced >= 10)
                        {
                            players.Add(player);
                        }

                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("invalid record" + e.Message);
                    }
                }
                players = players.OrderByDescending(p => p.StrikeRate).ToList();
                Display(players);
            }            

            catch (FileNotFoundException e)
            {
                Console.WriteLine("file not found : " + e.Message);
            }
            
        }
        public static void Display(List<Player> players)
        {
            Console.WriteLine("\nPlayer Statistics\n");

            Console.WriteLine($"{"Name",-20} {"Runs",-6} {"Strike Rate",-14} {"Avg",-8}");
            Console.WriteLine("--------------------------------------------------");

            foreach (var p in players)
            {
                Console.WriteLine($"{p.Name,-20} {p.RunsScored,-8} {p.StrikeRate, -12:F2} {p.Average,-8:F2}");
            }
        }
    }
}
