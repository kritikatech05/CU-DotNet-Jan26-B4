using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman_Project
{
    internal class Hangman
    {
        static void Main(string[] args)
        {
            List<string> wordList = new List<string>()
            {
                "computer","hangman","programming","keyboard","internet",
                "developer","software","hardware","compiler","variable",
                "function","loop","condition","array","string","integer",
                "boolean","object","class","method","namespace","exception",
                "debugger","framework","library","database","network","server",
                "client","algorithm","datastructure","recursion","pointer",
                "thread","process","memory","storage","binary","encryption",
                "authentication","performance"
            };

            Random rn = new Random();
            string word = wordList[rn.Next(wordList.Count)].ToUpper();
            char[] arr = word.ToCharArray();

            HashSet<char> guessed = new HashSet<char>();

            char[] displayword = new char[arr.Length];
            for (int i = 0; i < displayword.Length; i++)
                displayword[i] = '_';

            int chances = 6;

            Console.WriteLine("-------Hangman------");
            while (chances > 0 && displayword.Contains('_'))
            {
                
                Console.WriteLine("Word    : " + string.Join(" ", displayword));
                Console.WriteLine("Chances : " + chances);
                Console.Write("Guessed : ");

                foreach (char c in guessed)
                    Console.Write(c + " ");

                Console.WriteLine();

                Console.Write("Enter letter: ");
                char input = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (!char.IsLetter(input))
                {
                    Console.WriteLine("Invalid input. Enter a letter.");
                    continue;
                }

                if (guessed.Contains(input))
                {
                    Console.WriteLine("Already guessed.");
                    continue;
                }

                guessed.Add(input);

                bool found = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == input)
                    {
                        displayword[i] = input;
                        found = true;
                    }
                }

                if (found)
                    Console.WriteLine("Correct guess!");
                else
                {
                    chances--;
                    Console.WriteLine("Wrong guess!");
                }
            }

            Console.WriteLine();

            if (!displayword.Contains('_'))
                Console.WriteLine("YOU WIN  \nWord: " + word);
            else
                Console.WriteLine("YOU LOSE \nWord: " + word);
        }
    }
}
