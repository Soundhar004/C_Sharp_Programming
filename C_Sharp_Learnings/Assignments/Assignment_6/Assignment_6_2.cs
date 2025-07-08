using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_Sharp_Learnings.Assignments.Assignment_6
{
    class Assignment_6_2
    {
        static void Main()
        {
            Console.Write("How many strings would you like to enter? ");
            int count = int.Parse(Console.ReadLine());

            string[] userInputs = new string[count];

            // Getting user input
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter string #{i + 1}: ");
                userInputs[i] = Console.ReadLine();
            }

            string filePath = "C:\\Users\\soundhark\\Documents\\Project_C#\\C_Sharp_Learnings\\Assignments\\Assignment_6\\File_Handling_Files\\UserStrings.txt";

            // Writing to file
            try
            {
                File.WriteAllLines(filePath, userInputs);
                Console.WriteLine($"\nSuccessfully written to '{filePath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
            Console.Read();
        }

    }
}
