namespace LogiTrack.Models
{
    public class gps
    {
        public string TruckId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public double Speed { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
