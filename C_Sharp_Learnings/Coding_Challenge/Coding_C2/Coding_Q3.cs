using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Coding_Challenge.Coding_C2
{
    class Coding_Q3
    {
        static void CheckPositive(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number cannot be negative.");
            }

            Console.WriteLine($"✅ The number {number} is valid.");
        }

        static void Main()
        {
            Console.Write("Enter an integer: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                CheckPositive(input); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid integer.");
            }
            Console.Read();
        }
    }

}

