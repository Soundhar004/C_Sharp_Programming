using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Coding_Challenge.Coding_C3
{
    class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }

        public Box()
        {
            Length = 0;
            Breadth = 0;
        }

        public void SetDimensions()
        {
            Console.Write("Enter Length: ");
            Length = int.Parse(Console.ReadLine());

            Console.Write("Enter Breadth: ");
            Breadth = int.Parse(Console.ReadLine());
        }

        public static Box Add(Box b1, Box b2)
        {
            Box result = new Box();
            result.Length = b1.Length + b2.Length;
            result.Breadth = b1.Breadth + b2.Breadth;
            return result;
        }

        public void Display()
        {
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Breadth: {Breadth}");
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter dimensions for Box 1:");
            Box box1 = new Box();
            box1.SetDimensions();

            Console.WriteLine("\nEnter dimensions for Box 2:");
            Box box2 = new Box();
            box2.SetDimensions();

            Box box3 = Box.Add(box1, box2);

            Console.WriteLine("\n--- Box 3 (Sum of Box 1 & 2) ---");
            box3.Display();
            Console.Read();
        }
    }
}
