
namespace Freight_Tracking_System
{

    public class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string location) : base()
        {
            
        }
    }

    public class InsecurePackgingException : Exception
    {
        public InsecurePackgingException(string message) : base(message)
        {
            
        }

    }
    public interface ILoggable
    {
        void SaveLog(string message);
    }

    public class LogManager : ILoggable
    {
        string dir = @"..\..\..\";
        string file = "shipment_audit.log";
        string path;

        public LogManager()
        {
            
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            path = dir + file;
            if (!File.Exists(path))
            {
                Console.WriteLine("file doesnt exists");
                return;
            }
            
        }

        public void SaveLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(message);
            }
        }
    }


    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool IsFragile { get; set; }
        public bool Reinforced { get; set; }

        public List<string> restrictedZones = new List<string>
        {
            "North Pole",
            "Unknown Island",
            "Mars"
        };
        
        abstract public void ProcessShipment();
    }

    
    class ExpressShipment : Shipment
    {
        
        public override void ProcessShipment()
        {

            
            if(Weight <= 0){
                throw new ArgumentOutOfRangeException("Weight","Shipment weight is less than zero" );
            }
            if (restrictedZones.Contains(Destination))
            {
                throw new RestrictedDestinationException(Destination);

            }
            if(IsFragile && !Reinforced)
            {
                throw new InsecurePackgingException("Fragile packaging should be reinforced");

            }
           
            Console.WriteLine($"express shipment for {TrackingId} : SUCCESSFULL");
        }
    }

    class HeavyFreight : Shipment
    {
        public bool HeavyLiftPermit { get; set; }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight", "Shipment weight is less than zero");
            }
            if (restrictedZones.Contains(Destination))
            {
                throw new RestrictedDestinationException(Destination);

            }
            if (IsFragile && !Reinforced)
            {
                throw new InsecurePackgingException("Fragile packaging should be reinforced");

            }
            if (Weight > 1000 && !HeavyLiftPermit)
            {
                throw new Exception("no permit to lift more than 1000kg weight");
            }
            Console.WriteLine($"Heavy Freight shipment for {TrackingId} is processed");
            

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager log = new LogManager();
            
            List<Shipment> shipments = new List<Shipment>
            {
                new ExpressShipment
                {
                    TrackingId = "A1",
                    Weight = 57.05,
                    Destination = "Sirsa",
                    IsFragile = true,
                    Reinforced = true
                },
                new HeavyFreight
                {
                    TrackingId = "A2",
                    Weight = 2005,
                    Destination = "Pune",
                    IsFragile = true,
                    Reinforced = true,
                    HeavyLiftPermit = false
                },
                new ExpressShipment
                {
                    TrackingId = "A3",
                    Weight = 57.05,
                    Destination = "Hyd",
                    IsFragile = true,
                    Reinforced = false
                },
                new HeavyFreight
                {
                    TrackingId = "A4",
                    Weight = 2005,
                    Destination = "NZ",
                    IsFragile = true,
                    Reinforced = true,
                    HeavyLiftPermit = true
                },
                new ExpressShipment
                {
                    TrackingId = "A5",
                    Weight = 00.00,
                    Destination = "Hyd",
                    IsFragile = true,
                    Reinforced = true
                },
                new ExpressShipment
                {
                    TrackingId = "A6",
                    Weight = 20,
                    Destination = "Mars",
                    IsFragile = true,
                    Reinforced = true
                }
            };

            foreach (var ship in shipments)
            {
                
                try
                {
                    ship.ProcessShipment();
                    log.SaveLog($"SUCCESS. shipment {ship.TrackingId} processed");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    log.SaveLog($"!!!!!!wrong entry : {ex.Message}!!!!!!");
                }
                catch (RestrictedDestinationException ex)
                {
                    log.SaveLog($"Delivery not available at {ship.Destination}");

                }
                catch (InsecurePackgingException ex)
                {
                    log.SaveLog($"fragile items:  {ex.Message}");
                }
                catch (Exception ex)
                {
                    log.SaveLog($"{ex.Message}");
                }
                finally
                {
                    log.SaveLog($"Processing attempt finished for ID: [{ship.TrackingId}]");
                }

                
            }
        }
    }
}
