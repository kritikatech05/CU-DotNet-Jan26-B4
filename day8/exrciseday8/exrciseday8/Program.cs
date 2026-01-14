namespace exrciseday8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] arr = input.Split('|');
            string userName = arr[0];
            string msg = arr[1];

            string cleanMessage = msg.Trim().ToLower();

            bool containsSuccessful = cleanMessage.Contains("successful");

            string standardMessage = "login successful";

            string status;

            if (!containsSuccessful)
            {
                status = "LOGIN FAILED";
            }
            else if (cleanMessage.Equals(standardMessage))
            {
                status = "LOGIN SUCCESS";
            }
            else
            {
                status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
            }
            Console.WriteLine($"User     : {userName}");
            Console.WriteLine($"Message  : {cleanMessage}");
            Console.WriteLine($"Status   : {status}");
        }
    }
}
