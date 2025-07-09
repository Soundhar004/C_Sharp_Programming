using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments.Assignment_7
{
    class Assignment_7_2
    {
        static void Main()
        {
            Console.WriteLine("Enter words separated by commas (e.g. mum,amsterdam,bloom):");
            string input = Console.ReadLine();

            string[] words = input.Split(',');

            List<string> filteredWords = new List<string>();

            foreach (string word in words)
            {
                string trimmed = word.Trim().ToLower();

                if (trimmed.StartsWith("a") && trimmed.EndsWith("m"))
                {
                    filteredWords.Add(trimmed);
                }
            }

            Console.WriteLine("\nWords starting with 'a' and ending with 'm':");
            foreach (string word in filteredWords)
            {
                Console.WriteLine(word);
            }
            Console.Read();
        }
    }
}
