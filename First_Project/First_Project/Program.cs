using System;

namespace First_Project
{
    class Program
    {

        static void Main(string[] args) {


            Program own_class = new Program();
            own_class.CheckEqual();
            Console.Read();
         


        }

        public void CheckEqual()
        {
            Console.WriteLine("Enter Input 1 : ");
            int input_1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Input 2 : ");
            int input_2 = Convert.ToInt32(Console.ReadLine());
            if(input_1 == input_2) {
                Console.WriteLine($"{input_1} and {input_2} are equal.");

            }
            else
            {
                Console.WriteLine();
                Console.Read();
            }
        }
    }
}
