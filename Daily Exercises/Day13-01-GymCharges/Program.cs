using System;
using System.Text;

namespace day13Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to opt for Zumba? (true/false)");
            bool zumba = bool.Parse(Console.ReadLine());

            Console.WriteLine("Do you want to opt for Treadmill? (true/false)");
            bool treadmill = bool.Parse(Console.ReadLine());

            Console.WriteLine("Do you want to opt for Weight Lifting? (true/false)");
            bool weightLifting = bool.Parse(Console.ReadLine());

            double bill = MembershipAmount(zumba, treadmill, weightLifting);

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Total Bill Amount (including GST): {bill:c2}");
        }

        static double MembershipAmount(bool zumba, bool treadmill, bool weightLifting)
        {
            int fixedCharges = 1000;
            int total = fixedCharges;

            if (!zumba && !treadmill && !weightLifting)
            {
                Console.WriteLine("At least one service is mandatory.penalty added");
                total += 200;
            }

            if (treadmill)
                total += 300;

            if (weightLifting)
                total += 500;

            if (zumba)
                total += 250;

            double gst = total * 0.05; 
            double finalAmount = total + gst;

            return finalAmount;
        }
    }
}