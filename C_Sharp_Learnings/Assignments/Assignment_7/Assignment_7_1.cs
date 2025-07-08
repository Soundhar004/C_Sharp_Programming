using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments.Assignment_7
{
    class Assignment_7_1
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers separated by commas :");
            string input = Console.ReadLine();

            // Split and convert input to an array of integers
            string[] inputParts = input.Split(',');
            int[] numbers = new int[inputParts.Length];

            for (int i = 0; i < inputParts.Length; i++)
            {
                numbers[i] = int.Parse(inputParts[i].Trim());
            }

            Console.WriteLine("\nNumbers and their squares (only if square > 20):");
            foreach (int number in numbers)
            {
                int square = number * number;
                if (square > 20)
                {
                    Console.WriteLine($"{number} - {square}");
                }
            }
            Console.Read();
        }
    }
}
