using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Rough
{
    class Rough_1
    {


        static void Main()
        {
            Rough_1 obj = new Rough_1();
            obj.BillingSystem();
        }

        public void BillingSystem()
        {
            double items = 5, price = 200, percent = 10, tot_price, offer, result;
            tot_price = items * price;
            offer = (tot_price * percent) / 100;
            result = tot_price - offer;
            Console.WriteLine($"Amount to be paid : {result}");
            Console.ReadLine();

        }

    }


    /*Question No 2 */
    /*class Box
    {
        public int tot_len;
        int[] box1, box2;

        public Box(int[] a, int[] b)
        {
            box1 = a;
            box2 = b;
        }
        public static Box operator +(Box a, Box b)
        {
            int[] b1 = { 4, 3 }, b2 = { 4, 3, 2 };

            Box obj = new Box(b1, b2);
            obj.tot_len = a.box2.Length + b.box1.Length;
            return obj;
            Console.Read();
            
        }

        public void Display()
        {
            Console.WriteLine($"New box Sum : {tot_len}");

        }

        static void Main(string[] args){
            int[] b1 = { 4, 3 }, b2 = { 4, 3, 2 };
            Box Object = new Box(b1, b2);
            Object.Display();
            
        }

    }*/

    public class Box
    {
        // Property to hold the length of the box
        public double Length { get; set; }

        // Constructor to initialize the box with a given length
        public Box(double length)
        {
            Length = length;
        }

        // Overload the '+' operator to add two boxes
        public static Box operator +(Box box1, Box box2)
        {
            // Create a new Box with length as the sum of both boxes' lengths
            return new Box(box1.Length + box2.Length);

        }

        // Method to display the length of the box
        public override string ToString()
        {
            return $"Box Length: {Length}";
        }
    }

    // Example usage
    public class Program
    {
        static void Main()
        {
            // Create two Box instances
            Box box1 = new Box(10.5);
            Box box2 = new Box(5.5);

            // Add the two boxes together
            Box box3 = box1 + box2;

            // Display the result
            Console.WriteLine(box3); // Output: Box Length: 16.0
            Console.Read();
        }


    }


}
