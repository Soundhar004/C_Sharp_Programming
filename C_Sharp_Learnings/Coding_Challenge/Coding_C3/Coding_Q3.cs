using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_Sharp_Learnings.Coding_Challenge.Coding_C3
{
    class Coding_Q3
    {
        static void Main()
        {
            string fileName = "C:\\Users\\soundhark\\Documents\\Project_C#\\C_Sharp_Learnings\\Assignments\\Assignment_6\\File_Handling_Files\\UserStrings.txt";

            Console.Write("Enter text to append to the file: ");
            string userInput = Console.ReadLine();

            try
            {
               
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine(userInput);
                }

                Console.WriteLine($"\nText has been successfully appended to '{fileName}'.");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            Console.Read();
        }
    }
}
