using System;

namespace First_Project
{
    class oops
    {
        public void ModifyValue(int x)
        {
            x = 10; // Only modifies the local copy
        }
        void ModifyValue(ref int x)
        {
            x = 10; // Modifies the original variable
        }
        void Calculate(int a, int b, out int sum, out int product)
        {
            sum = a + b;       // Assigning values
            product = a * b;
        }
        void Parameter(params int[] num)
        {
            foreach (int i in num)
            {
                Console.WriteLine("---------Parameters----------");
                Console.WriteLine($"{i}");
            }
        }
        public void Main()
        {
            int number = 5;
            ModifyValue(number);
            Console.WriteLine(number); // Output: 5

            ModifyValue(ref number);
            Console.WriteLine(number); // Output: 10

            int resultSum, resultProduct;
            Calculate(3, 4, out resultSum, out resultProduct);
            Console.WriteLine($"Sum: {resultSum}, Product: {resultProduct}");
            // Output: Sum: 7, Product: 12
        }
    }
}
