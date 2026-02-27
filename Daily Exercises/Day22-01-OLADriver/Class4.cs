using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class OLADriver
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string VehicleNo { get; set; }
        public List<Ride> Rides { get; set; }

        public OLADriver()
        {
            Rides = new List<Ride>();
        }

        public decimal totalFare()
        {
            decimal total = 0;
            foreach (var ride in Rides)
            {
                total += ride.Fare;
            }
            return total;
        }

    }
    class Ride
    {
        public int RideId { get; set; }
        public string Pickup { get; set; }
        public string Drop { get; set; }
        public decimal Fare { get; set; }
    }
    internal class Class4
    {
        static void Main(string[] args)
        {
            List<OLADriver> driver = new List<OLADriver>
            {
                new OLADriver
                {
                    Id = 1,
                    Name = "Kushagar",
                    VehicleNo = "KA1AB12",
                    Rides =
                    {
                        new Ride { RideId = 101, Pickup = "LC", Drop = "FR", Fare = 35 },
                        new Ride { RideId = 102, Pickup = "Shivalik", Drop = "NC", Fare = 200 }
                    }
                },
                new OLADriver
                {
                    Id = 2,
                    Name = "Tushar",
                    VehicleNo = "AB12CD2",
                    Rides =
                    {
                        new Ride { RideId = 201, Pickup = "kharar", Drop = "darpan", Fare = 20 },
                        new Ride { RideId = 202, Pickup = "cu", Drop = "Kurali", Fare = 18 },
                        new Ride { RideId = 203, Pickup = "A1", Drop = "E2", Fare = 22 }
                    }
                }
            };


            foreach (var r in driver)
            {
                Console.WriteLine($"Driver: {r.Name} | Vehicle: {r.VehicleNo}");
                Console.WriteLine("Rides:");

                foreach (var ride in r.Rides)
                {
                    Console.WriteLine(
                        $"  RideId: {ride.RideId}, Pickup: {ride.Pickup}, Drop: {ride.Drop}, Fare: {ride.Fare}"
                    );
                }
                Console.WriteLine($"Total Fare: {r.totalFare()}");
                
            }

            }
    }
}
