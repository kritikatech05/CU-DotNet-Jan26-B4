namespace SecureTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pin = "";
            Console.WriteLine("enter pin : ");
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);

                if (char.IsDigit(info.KeyChar))
                {
                    pin += info.KeyChar;
                    Console.Write("*");

                }
                else if(info.Key == ConsoleKey.Backspace)
                {
                    if(pin.Length > 0)
                    {
                        pin = pin.Substring(0, pin.Length - 1);
                        Console.Write("\b \b");

                    }
                }
                if(info.Key == ConsoleKey.Enter && pin.Length == 4)
                {
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("pin entered successfully");
            Console.WriteLine($"pin : {pin}");
        }

    }
}
