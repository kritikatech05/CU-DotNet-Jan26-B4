
using System.IO;

namespace TheDailyLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = @"..\..\..\";

            string file = "journal.txt";
            string path = dir + file;

            Console.WriteLine("!DAILY REFLECTION!");
            string reflection = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(reflection);
                sw.WriteLine("------------------------------");
            }

        }
    }
}
