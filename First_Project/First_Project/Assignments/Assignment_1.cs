using System;

namespace First_Project.Assignments
{
    class Assignment_1
    {

        static void Main(string[] args)
        {
            Assignment_1 own_class = new Assignment_1();
            own_class.CheckEqual();
            own_class.CheckPositive();
            own_class.Arithmetic();
            own_class.MultipleTable();
            own_class.Sum();
        }

        public static void TwoInputs(out int input_1, out int input_2)
        {
            Console.WriteLine("Enter Input 1 : ");
            input_1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Input 2 : ");
            input_2 = Convert.ToInt32(Console.ReadLine());
        }

        public void CheckEqual()
        {
            Assignment_1.TwoInputs(out int input_1, out int input_2);
            if (input_1 == input_2)
            {
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
            Assignment_1.TwoInputs(out int input_1, out int input_2);
            Console.WriteLine($"Addition : {input_1 + input_2}");
            Console.WriteLine($"Subraction : {input_1 - input_2}");
            Console.WriteLine($"MultiPlication : {input_1 * input_2}");
            Console.WriteLine($"Division : {input_1 / input_2}");
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
        }

        public void Sum()
        {
            Assignment_1.TwoInputs(out int input_1, out int input_2);
            int sum = input_1 + input_2;
            if (input_1 == input_2)
            {
                Console.WriteLine($"Triple the sum, Inputs are same : {sum * 3}");
            }
            else
            {
                Console.WriteLine($"Sum of two inputs : {sum} ");
            }
            Console.Read();
        }
    }
}
