using System;
using System.Text.RegularExpressions;

namespace StudentValidationApp
{
 
    class AgeException : Exception
    {
        public AgeException(string message) : base(message) { }
    }
    class NameException : Exception
    {
        public NameException(string message) : base(message) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DivideNumbers();
            ConvertStringToInt();
            AccessArrayIndex();
            ValidateStudent();

            Console.WriteLine("\nProgram Ended");
        }


        static void DivideNumbers()
        {
            try
            {
                Console.Write("Enter first number: ");
                int a = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int b = int.Parse(Console.ReadLine());

                int result = a / b;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid integers only.");
            }
            finally
            {
                Console.WriteLine("Division Operation Completed");
            }
        }

        static void ConvertStringToInt()
        {
            try
            {
                Console.Write("\nEnter a numeric string: ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Converted number: " + number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format. Not a number.");
            }
            finally
            {
                Console.WriteLine("String to Integer Conversion Completed");
            }
        }

        static void AccessArrayIndex()
        {
            try
            {
                int[] arr = { 10, 20, 30 };
                Console.Write("\nEnter array index: ");
                int index = int.Parse(Console.ReadLine());
                Console.WriteLine("Value: " + arr[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Index is out of range.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Index must be numeric.");
            }
            finally
            {
                Console.WriteLine("Array Access Completed");
            }
        }


        static void ValidateStudent()
        {
            try
            {
  
                Console.Write("\nEnter student age: ");
                int age = int.Parse(Console.ReadLine());

                if (age < 18 || age > 60)
                    throw new AgeException("Invalid age exception occurred");

                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                if (!Regex.IsMatch(name, @"^[A-Z][a-z]{2,}$"))
                    throw new NameException("Invalid name exception occurred");

                Console.WriteLine("\nStudent Validated Successfully");
            }
            catch (Exception ex)
            {

                Exception wrappedException =
                    new Exception("Student validation failed", ex);

                LogException(wrappedException);
            }
        }

        static void LogException(Exception ex)
        {
            Console.WriteLine("\n---- Exception Details ----");
            Console.WriteLine("Message: " + ex.Message);
            Console.WriteLine("\nStackTrace:\n" + ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine("\nInnerException: " +
                                  ex.InnerException.Message);
            }
        }
    }
}
