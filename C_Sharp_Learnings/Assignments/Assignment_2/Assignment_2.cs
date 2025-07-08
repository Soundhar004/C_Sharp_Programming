using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments
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
            obj.TenMarks();
            obj.CopyElement();
            obj.StringAssignment();

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
            int avg, sum = 0;
            Console.WriteLine("-------------Array Activity----------------");
            foreach (int i in a)
            {
                sum = sum + i;
            }
            avg = sum / a.Length;
            Console.WriteLine($"A. Average Value : {avg}");
            Console.WriteLine($"B. Minimum Value : {a.Min()} and Maximum Value : {a.Max()}");

        }
        public void TenMarks()
        {
            int[] a = { 50, 60, 100, 20, 30, 40, 10 };

            int avg, sum = 0;
            Console.WriteLine("-------------Ten Marks----------------");
            foreach (int i in a)
            {
                sum = sum + i;
            }
            avg = sum / a.Length;
            Console.WriteLine($"A. Total Value : {sum}");
            Console.WriteLine($"B. Average Value : {avg}");
            Console.WriteLine($"C. Minimum Value : {a.Min()} and Maximum Value : {a.Max()}");
            Array.Sort(a);
            Console.WriteLine($"D. Ascending Array : ");
            foreach (int i in a)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"E. Descending Array : ");
            Array.Reverse(a);
            foreach (int i in a)
            {
                Console.WriteLine(i);
            }

        }
        public void CopyElement()
        {
            int[] a = { 3, 3, 2, 4, 56, 6, 4, };
            int[] b = (int[])a.Clone();

            Console.WriteLine("-------------Copy Elements----------------");
            /*List<int> b = new List<int>();
            foreach (int i in a)
            {
                b.Append(i);
            }*/

            Console.WriteLine($"Copy Elemnets : ");
            foreach (int i in b)
            {
                Console.WriteLine(i);
            }

        }

        public void StringAssignment()
        {
            /* string[] arry1 = { "Cars", "Bikes", "Trucks" };*/
            Console.WriteLine("Enter the string : ");
            string[] arry2 = new string[4];

            for (int i = 0; i < arry2.Length; i++)
            {
                arry2[i] = Console.ReadLine();
            }
            Console.WriteLine($"Length of the String : {arry2.Length}");
            Array.Reverse(arry2);
            Console.WriteLine($"Reverse of the String : ");
            foreach (string i in arry2)
            {
                Console.WriteLine(i);
            }

            string i1, i2;
            Console.WriteLine("Enter Input 1 : ");
            i1 = Console.ReadLine();
            Console.WriteLine("Enter Input 2 : ");
            i2 = Console.ReadLine();
            if (i1 == i2)
            {
                Console.WriteLine("Two Values are Equal");
            }
            else
            {
                Console.WriteLine("Two Values are not Equal");
            }
            Console.Read();
        }

    }
}
