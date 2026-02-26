namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "abcdu";
            string result = "";

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                {
                    if (ch == 'a') result += 'e';
                    else if (ch == 'e') result += 'i';
                    else if (ch == 'i') result += 'o';
                    else if (ch == 'o') result += 'u';
                    else if (ch == 'u') result += 'a'; 
                }
                else
                {
                  
                    char next = (char)(ch + 1);

                    if (next == 'a' || next == 'e' || next == 'i' || next == 'o' || next == 'u')
                    {
                        next = (char)(next + 1);
                    }

                    if (ch == 'z')
                    {
                        next = 'b';
                    }

                    result += next;
                }
            }

            Console.WriteLine("Output: " + result);

        }
    }
}
