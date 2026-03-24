namespace assessment_week_2
{
    internal class assessment
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];

            for(int i =0; i < policyHolderNames.Length; i++)
            {
                Console.WriteLine("Enter name of policy holder : ");
                policyHolderNames[i] = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(policyHolderNames[i]))
                {
                    Console.WriteLine("name invalid! enter again");
                    policyHolderNames[i] = Console.ReadLine();
                }
                //kritika sharma
                Console.WriteLine($"enter annual premium amount for {policyHolderNames[i]}");
                annualPremiums[i] = Decimal.Parse(Console.ReadLine());

                while (annualPremiums[i] <= 0)
                {
                    Console.WriteLine("Premium cannot be less than 0! enter again");
                    annualPremiums[i] = Decimal.Parse(Console.ReadLine());
                }
            }
            decimal highestPremium = annualPremiums[0];
            decimal lowestPremium = annualPremiums[0];
            decimal totalPremium = annualPremiums[0];

            for(int i = 1; i < annualPremiums.Length; i++)
            {
                if (annualPremiums[i] > highestPremium) 
                {
                    highestPremium = annualPremiums[i];
                }
                if (annualPremiums[i] <= lowestPremium) { 
                    lowestPremium = annualPremiums[i];
                }
                totalPremium += annualPremiums[i];
            }

            decimal averagePremium = totalPremium / annualPremiums.Length;

            Console.WriteLine("----------------Insurance Premium Summary----------------");
            Console.WriteLine();
            Console.WriteLine($"{"NAME",-20} {"PREMIUM",-15} {"CATEGORY",-10}");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            for (int i = 0; i < policyHolderNames.Length; i++)
            {
                string category;

                if (annualPremiums[i] < 10000)
                    category = "LOW";
                else if (annualPremiums[i] <= 25000)
                    category = "MEDIUM";
                else
                    category = "HIGH";

                Console.WriteLine($"{policyHolderNames[i].ToUpper(),-20} {annualPremiums[i],-15:F2} {category,-10}");
            }
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine($"Total Premium   : {totalPremium:F2}");
            Console.WriteLine($"Average Premium : {averagePremium:F2}");
            Console.WriteLine($"Highest Premium : {highestPremium:F2}");
            Console.WriteLine($"Lowest Premium  : {lowestPremium:F2}");
          


        }
    }
}


