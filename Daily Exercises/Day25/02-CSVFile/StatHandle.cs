using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class StatHandle
    {
        static void Main(string[] args)
        {
            string file = @"..\..\..\stat.csv";

            //create mode and writingg

            using FileStream fs = new FileStream(file, FileMode.Create);

            using StreamWriter sw = new StreamWriter(fs);

            string[] data =
            {
                "Steve Smith, re, 90, True",
                "Virat Kohli, 29, 35, False",
                "Joe Root, 110, 120, True",
                "Hardik Pandya, 340, 0, True"

            };
            foreach (string line in data)
            {
                sw.WriteLine(line);
            }
        }
    }
}
