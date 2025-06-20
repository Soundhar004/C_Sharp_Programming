using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Project.Assignments
{
    class Assignment_2
    {
        static void Main(string[] args)
        {
            Assignment_2 obj = new Assignment_2();
            obj.SwapNumbers();
            obj.DisplayFourTimes();
            obj.ReadDay();
            obj.ArrayActivity();
              
        }

        public void SwapNumbers()
        {
            int a = 10, b = 20;
            Console.WriteLine($"Before Swapping, a = {a} b = {b}");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"After Swapping, a = {a} b = {b}");
           
        }

        public void DisplayFourTimes()
        {
            int a = 25;
            Console.WriteLine("-------------DisplayFourTimes-----------");
            Console.WriteLine("{0} {1} {2} {3}", a, a, a, a);
            Console.WriteLine("{0}{1}{2}{3}", a, a, a, a);
            Console.WriteLine("{0} {1} {2} {3}", a, a, a, a);
            Console.WriteLine("{0}{1}{2}{3}", a, a, a, a);
           
        }
        public void ReadDay()
        {
            int a = 5;
            Console.WriteLine("-------------Reading Day----------------");
            switch (a)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
            }
            
        }

        public void ArrayActivity()
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int avg,sum=0;
            foreach(int i in a)
            {
                sum = sum + i;
            }
            avg = sum / a.Length;
            Console.WriteLine($"A. Average Value : {avg}");
            Console.WriteLine($"Minimum Value : {a.Min()} and Maximum Value : {a.Max()}");
            
        }
        public void TenMarks()
        {
            int[] a = {10,20,30,40};
            int avg, sum = 0;
            foreach (int i in a)
            {
                sum = sum + i;
            }
            avg = sum / a.Length;
            Console.WriteLine($"Total Value : {sum}");
            Console.WriteLine($"A. Average Value : {avg}");
            Console.WriteLine($"Minimum Value : {a.Min()} and Maximum Value : {a.Max()}");
            Console.Read();
        }
    }

}
