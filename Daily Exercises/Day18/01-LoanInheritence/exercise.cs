namespace exercise
{

    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipleAmount { get; set; }
        public int Tenure { get; set; }

        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipleAmount = 0m;
            Tenure = 0;
        }
        public virtual void Display()
        {
            Console.WriteLine("Loan Display");
            Console.WriteLine($"EMI = {CalculateEMI():C2}");
        }
        public Loan(string id, string name, decimal Amount, int tenure)
        {
            LoanNumber = id;
            CustomerName = name;
            PrincipleAmount = Amount;
            Tenure = tenure;

        }

        //kritika sharma

        public decimal CalculateEMI()
        {
            decimal interest = PrincipleAmount * 10 / 100 * Tenure;
            decimal totalAmount = PrincipleAmount + interest;
            return totalAmount / (Tenure * 12);
        }
        public override string ToString()
        {
            return $"LoanNumber :{LoanNumber}," +
                $"Customer_Name: {CustomerName}," +
                $"Principal :{PrincipleAmount}," +
                $"Tenure :{Tenure},";
        }


    }
    class HomeLoan : Loan
    {
        public HomeLoan(string loanNo, string name, decimal principal, int tenure)
       : base(loanNo, name, principal, tenure) { }
        public new decimal CalculateEMI()
        {
            decimal interest = PrincipleAmount * 8 / 100 * Tenure;
            decimal processingFee = PrincipleAmount * 1 / 100;
            decimal totalAmount = PrincipleAmount + interest + processingFee;
            return totalAmount / (Tenure * 12);
        }

        public override void Display()
        {
            Console.WriteLine("Home Loan Display");
            Console.WriteLine($"EMI = {CalculateEMI():C2}");
        }

    }
    class CarLoan : Loan
    {
        public CarLoan(string loanNo, string name, decimal principal, int tenure)
       : base(loanNo, name, principal, tenure) { }
        public new decimal CalculateEMI()
        {
            decimal newPrincipal = PrincipleAmount + 15000;
            decimal interest = newPrincipal * 9 / 100 * Tenure;
            decimal totalAmount = newPrincipal + interest;
            return totalAmount / (Tenure * 12);
        }

        public override void Display()
        {
            Console.WriteLine("----- CAR LOAN -----");
            Console.WriteLine(ToString());
            Console.WriteLine($"EMI = {CalculateEMI():C2}");
            Console.WriteLine("Executed from CarLoan\n");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Loan[] arr = new Loan[4] {
            new HomeLoan("A1", "kritika", 100000, 10),
            new HomeLoan("A2", "yoyoy", 100000, 10),
            new CarLoan("C1", "Kartik",100000 , 10),
            new CarLoan("C2", "ekta", 100000, 10)
            };

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            foreach (Loan i in arr)
            {
                Console.WriteLine($"EMI = {i.CalculateEMI():C2}");
            }

        }
    }
}