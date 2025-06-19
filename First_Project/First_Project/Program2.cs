using System;

namespace First_Project
{
    class Program2
    {

        public void ModifyValue(int x)
        {
            x = 10; // Only modifies the local copy
        }
        public void ModifyRef(ref int x)
        {
            x = 10; // Modifies the original variable
        }
        public void Calculate(int a, int b, out int sum, out int product)
        {
            sum = a + b;       // Assigning values
            product = a * b;
        }
        public void Parameter(params int[] num)
        {
            foreach (int i in num)
            {
                Console.WriteLine("---------Parameters----------");
                Console.WriteLine($"{i}");
            }
        }
        static void Main(string[] args){
            Program2 obj = new Program2();
            int number = 5;
            obj.ModifyValue(number);
            Console.WriteLine(number); // Output: 5

            obj.ModifyRef(ref number);
            Console.WriteLine(number); // Output: 10

            int resultSum, resultProduct;
            obj.Calculate(3, 4, out resultSum, out resultProduct);
            Console.WriteLine($"Sum: {resultSum}, Product: {resultProduct}");
            // Output: Sum: 7, Product: 12
            Console.Read();
        }
    }

}

