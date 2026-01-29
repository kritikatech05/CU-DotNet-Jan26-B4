using System.Text.Unicode;


namespace ConsoleApp1
{

    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

        public abstract decimal CalculateBillAmount();
        public  virtual decimal CalculateTax(decimal billAmount)
        {
            
            Console.WriteLine("tax to be applied : ");
            return 0.05m * billAmount;

        }
        

        public void PrintBill()
        {
            
            Console.WriteLine($"consumer id : {ConsumerId},\n consumer name : {ConsumerName}, \n units consumed : {UnitsConsumed}");
            decimal billAmount = CalculateBillAmount();
            decimal tax = CalculateTax(billAmount);
            decimal TotalAmount = billAmount + tax;

            Console.WriteLine($"Base Amount: {billAmount}");
            Console.WriteLine($"Tax: {tax :c}");
            Console.WriteLine($"Final Payable: ₹{TotalAmount}");
        }

    }
    class ElectricityBill : UtilityBill
    {
        public override decimal CalculateBillAmount()
        {
            decimal amt = UnitsConsumed * RatePerUnit;

            if (UnitsConsumed > 300)
            {
                amt += amt * 0.10m; 
            }

            return amt;
        }
     
    }
    class WaterBill : UtilityBill
    {
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m;
        }
    }
    class GasBill : UtilityBill
    {
        public override decimal CalculateBillAmount()
        {
            return (UnitsConsumed * RatePerUnit) + 150;
        }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            List<UtilityBill> bills = new List<UtilityBill>()
            {
                new ElectricityBill
                {
                    ConsumerId = 1,
                    ConsumerName = "Kritika",
                    UnitsConsumed = 350,
                    RatePerUnit = 6
                },

                new WaterBill
                {
                    ConsumerId = 2,
                    ConsumerName = "ekta",
                    UnitsConsumed = 120,
                    RatePerUnit = 2
                },

                new GasBill
                {
                    ConsumerId = 3,
                    ConsumerName = "komal",
                    UnitsConsumed = 50,
                    RatePerUnit = 4
                }
            };

            foreach (UtilityBill bill in bills)
            {
                bill.PrintBill(); 
            }
        }
    }
}
