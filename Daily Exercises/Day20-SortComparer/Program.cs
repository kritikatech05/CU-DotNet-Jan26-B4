using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
    class Flight : IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            if (other == null) return 1;

            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {

            return $"flight number : {FlightNumber}, duration : {Duration}, Price : {Price}, Departure time : {DepartureTime}";

        }
    }
    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return x.Duration.CompareTo(y.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }
    //kritika sharma
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> l1 = new List<Flight>()
            {
                new Flight
                {
                    FlightNumber = "A1",
                    Price = 5500,
                    Duration = new TimeSpan(5, 10, 0),
                    DepartureTime = new DateTime(2026, 01, 30, 06, 30, 00)
                },
                new Flight
                {
                    FlightNumber = "B1",
                    Price = 4200,
                    Duration = new TimeSpan(2, 00, 00),
                    DepartureTime = new DateTime(2026, 01, 29, 12, 40, 00)
                },
                new Flight
                {
                    FlightNumber = "K5",
                    Price = 7000,
                    Duration = new TimeSpan(3, 30, 0),
                    DepartureTime = new DateTime(2026, 01, 29, 22, 20, 00)
                },
                null,
                new Flight {
                    FlightNumber = "A2",
                    Price = 4800,
                    Duration = new TimeSpan(8, 50, 0),
                    DepartureTime = new DateTime(2026, 01, 29, 12, 55, 00)
                }

            };


            Console.WriteLine("---ECONOMY VIEW---");

            l1.Sort();

            Console.WriteLine();

            foreach (Flight f in l1)
            {
                if (f == null)
                {
                    Console.WriteLine("null entry");

                    continue;
                }
               
                Console.WriteLine(f);
            }

            Console.WriteLine();

            Console.WriteLine("---BUSINESS RUNNER  VIEW---");

            l1.Sort(new DurationComparer());

            Console.WriteLine();

            foreach (Flight f in l1)
            {
                if (f == null)
                {
                    Console.WriteLine("null entry");

                    continue;
                }
                Console.WriteLine(f);
            }
            Console.WriteLine();

            Console.WriteLine("---EARLY BIRD VIEW---");

            l1.Sort(new DepartureComparer());

            Console.WriteLine();

            foreach (Flight f in l1)
            {
                if (f == null)
                {
                    Console.WriteLine("null entry");

                    continue;
                }
            
                Console.WriteLine(f);
            }
        }
    }
}
