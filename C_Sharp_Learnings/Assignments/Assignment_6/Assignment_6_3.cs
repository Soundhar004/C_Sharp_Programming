using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace C_Sharp_Learnings.Assignments.Assignment_6
{
    class Assignment_6_3
    {

        static void Main()
        {
            /*Console.WriteLine("Enter the full path of the file: ");*/
            string filePath = "C:\\Users\\soundhark\\Documents\\Project_C#\\C_Sharp_Learnings\\Assignments\\Assignment_6\\File_Handling_Files\\UserStrings.txt";

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                Console.WriteLine($"Total number of lines: {lines.Length}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found. Please check the path.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.Read();
        }

    }
}
