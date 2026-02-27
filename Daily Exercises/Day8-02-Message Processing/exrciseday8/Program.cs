namespace exrciseday8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split('#');

            string id = parts[0];
            string name = parts[1];
            string transaction = parts[2];

            transaction = transaction.Trim();
            transaction = transaction.ToLower();
            while (transaction.Contains("  "))
            {
                transaction = transaction.Replace("  ", " ");
            }
            bool Deposit = transaction.Contains("deposit");
            bool Withdrawal = transaction.Contains("withdrawal");
            bool Transfer = transaction.Contains("transfer");

            bool hasKeyword = Deposit || Withdrawal || Transfer;

            string stdNarration = "cash deposit successful";
            bool isStandard = transaction.Equals(stdNarration);
            string category;

            if (!hasKeyword)
            {
                category = "NON-FINANCIAL TRANSACTION";
            }
            else if (hasKeyword && isStandard)
            {
                category = "STANDARD TRANSACTION";
            }
            else
            {
                category = "CUSTOM TRANSACTION";
            }

            Console.WriteLine($"Transaction ID : {id}");
            Console.WriteLine($"Account Holder : {name}");
            Console.WriteLine($"Narration      : {transaction}");
            Console.WriteLine($"Category       : {category}");

        }
    }
}
