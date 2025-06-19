using System;

namespace First_Project
{
    class Program
    {

        static void Main(string[] args) {


            Program own_class = new Program();
           /* own_class.CheckEqual();
            own_class.CheckPositive();
            own_class.Arithmetic();*/
            own_class.MultipleTable();
            
            
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
                Console.WriteLine($"{input_1} and {input_2} are not equal.");
               
            }
        }


        public void CheckPositive()
        {
            Console.WriteLine("Enter Input 1 : ");
            int input_1 = Convert.ToInt32(Console.ReadLine());
            if (input_1 > 0)
            {
                Console.WriteLine($"{input_1} is a Positive Number.");
            }
            else
            {
                Console.WriteLine($"{input_1} is a Negative Number");
             
            }
        }
         public void Arithmetic()
        {
            Console.WriteLine("Enter Input 1 : ");
            int input_1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Input 2 : ");
            int input_2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Addition : {input_1 + input_1}");
            Console.WriteLine($"Subraction : {input_1 - input_1}");
            Console.WriteLine($"MultiPlication : {input_1 * input_1}");
            Console.WriteLine($"Division : {input_1 / input_1}");

        }


        public void MultipleTable()
        {
            int i;
            Console.WriteLine("Enter Input 1 : ");
            int input_1 = Convert.ToInt32(Console.ReadLine());
            for (i = 0; i <= 50; i++)
            {
                Console.WriteLine($"{i} * {input_1} = {i * input_1}");
            }
            Console.Read();
        }

        public void Sum()
        {
            Console.WriteLine("Enter Input 1 : ");
            int input_1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Input 2 : ");
            int input_2 = Convert.ToInt32(Console.ReadLine());
            int sum = input_1 + input_2;
            if(input_1 == input_2)
            {
                Console.WriteLine($"Triple the sum, Inputs are same : {sum * 3}");
            }
            else
            {
                Console.WriteLine("Sum of two inputs : ", sum);
            }
        }
    }
}
