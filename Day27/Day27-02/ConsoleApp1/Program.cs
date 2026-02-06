using System.Text;

namespace ConsoleApp1
{
    class Loan
    {
        public string Name { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
        public string RiskLevel(double Interest)
        {
            if (Interest < 5) { return "Low"; }
            if (Interest < 10) { return "Medium"; }
            return "High";
        }
        public double InterestAmount(double principle, double interest)
        {
            return (principle * interest) / 100;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\LoanDetails.csv";
            Console.WriteLine("Enter Name ,Principal amount ,and Rate of interest in same format");
            string inputData = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(inputData);
            }

            List<Loan> list = new List<Loan>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] input = line.Split(',');
                    if (!double.TryParse(input[1], out double prin) || !double.TryParse(input[2], out double result))
                    {
                        Console.WriteLine("Invalid Details");
                        continue;

                    }

                    Loan l = new Loan()
                    {
                        Name = input[0],
                        Principal = prin,
                        InterestRate = result

                    };
                    list.Add(l);
                }
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\b                     THE LOAN PORTFOLIO                     ");
                Console.WriteLine($"{"Client",-10}|{"Principal",-15}|{"Interest",-15}|{"Risk Level",-10}");
                Console.WriteLine("--------------------------------------------------------------");
                foreach (Loan i in list)
                {
                    Console.WriteLine($"{i.Name,-10}|{i.Principal,-15:c2}|{i.InterestAmount(i.Principal, i.InterestRate),-15:c2}|{i.RiskLevel(i.InterestRate),-10}");
                }

            }



        }
    }
}