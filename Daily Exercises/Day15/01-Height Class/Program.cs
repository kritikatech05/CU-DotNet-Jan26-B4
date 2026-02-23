namespace ConsoleApp1
{
    class Height
    {
        public int feet { get; set; }
        public double inches { get; set; }
        public Height()
        {
            feet = 0;
            inches = 0.0;
        }
        public Height(int ft, double inch)
        {
            feet = ft;
            inches = inch;
        }

        public Height(double totalInches)
        {
            feet = (int)(totalInches / 12);
            inches = totalInches % 12;
        }

        public Height addHeight(Height h)
        {
            int Totalfeet = this.feet + h.feet;
            double Totalinches = this.inches + h.inches;

            if (Totalinches >= 12)
            {
                Totalfeet += (int)(Totalinches / 12);
                Totalinches = Totalinches % 12;
            }
            return new Height(Totalfeet, Totalinches);
        }
        public override string ToString()
        {
            return $"Height: {feet} feet {inches} inches";
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Height h1 = new Height(5, 4);
                Height h2 = new Height(5, 2);
                Height h3 = new Height(176);
                Console.WriteLine(h1);
                Console.WriteLine(h2);
                Console.WriteLine(h3);
                Console.WriteLine($"total height of h1 and h2 {h1.addHeight(h2)}");
                Console.WriteLine($"total height of h3 and h1 {h3.addHeight(h1)}");



            }

        }
    }
}