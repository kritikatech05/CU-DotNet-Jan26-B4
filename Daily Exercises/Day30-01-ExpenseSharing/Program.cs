
namespace Day2
{
    internal class Program
    {
        static void Splitwise(Dictionary<string, decimal> expenses)
        {
            int n = expenses.Count;

            decimal sum = 0;
            foreach (var person in expenses)
            {
                sum += person.Value;
            }

            decimal avg = sum / n;

            List<string> names = new List<string>(expenses.Keys);
            List<decimal> balance = new List<decimal>();

            for (int i = 0; i < names.Count; i++)
            {
                balance.Add(expenses[names[i]] - avg);
            }

            int giver = 0;     
            int receiver = 0; 

            Console.WriteLine($"Payer | Receiver   | Amount");
            Console.WriteLine("-----------------------------");

            while (giver < n && receiver < n)
            {
                while (giver < n && balance[giver] >= 0)
                {
                    giver++;
                }

                while (receiver < n && balance[receiver] <= 0)
                {
                    receiver++;
                }

                if (giver == n || receiver == n)
                    break;

                decimal amount = Math.Min(-balance[giver], balance[receiver]);
                amount = Math.Round(amount, 2);

                Console.WriteLine($"{names[giver], -5} | {names[receiver], -10} | {amount:F2}");

                balance[giver] += amount;
                balance[receiver] -= amount;
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, decimal> expenses = new Dictionary<string, decimal>()
            {
                { "Kritika", 900m },
                { "Ekta", 0m },
                { "Kartik", 1290m }
            };

            Splitwise(expenses);
        }
    }
}


//            //brute forcee
//            //List<int> list = new List<int>();
//            //int sum = 0;
//            //for (int i =0; i < arr.Length; i++)
//            //{
//            //    sum += arr[i];
//            //}
//            //int avg = sum / arr.Length;
//            //for(int i = 0; i < arr.Length; i++)
//            //{
//            //    if (arr[i] < avg)
//            //    {
//            //        int diff = avg - arr[i];
//            //        list.Add(diff);
//            //    }
//            //    if(arr[i] >= avg)
//            //    {
//            //        int diff = arr[i] - avg;
//            //        list.Add(arr[i]);
//            //    }
//            //}
//            //foreach(int i in list)
//            //{
//            //    Console.Write($"{i} | ");
//            //}
//        }
//    }
//}
