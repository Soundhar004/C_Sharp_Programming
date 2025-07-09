using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Coding_Challenge.Coding_C3
{
    class Coding_Q4
    {
        public delegate int CalculatorDelegate(int a, int b);

        public static int Add(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;

        public static void PerformCalculation(string operation, CalculatorDelegate calc, int a, int b)
        {
            int result = calc(a, b);
            Console.WriteLine($"{operation}: {result}");
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Calculator Results ---");

            PerformCalculation("Addition", Add, num1, num2);
            PerformCalculation("Subtraction", Subtract, num1, num2);
            PerformCalculation("Multiplication", Multiply, num1, num2);
            Console.Read();
        }
    }
}
