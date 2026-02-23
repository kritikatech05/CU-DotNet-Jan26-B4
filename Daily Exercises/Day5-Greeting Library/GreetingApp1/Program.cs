using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreetingLibrary1;

namespace GreetingApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            string message = GreetingHelper1.GetGreeting(name);

            Console.WriteLine(message);

            Console.ReadLine();

        }
    }
}
