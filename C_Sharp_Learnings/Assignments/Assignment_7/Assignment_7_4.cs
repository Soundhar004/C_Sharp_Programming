using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments.Assignment_7
{
    public class Concession
    {
        public string CalculateConcession(int age, double totalFare)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = totalFare * 0.70;
                return $"Senior Citizen - Fare after 30% concession: ₹{discountedFare}";
            }
            else
            {
                return $"Print Ticket Booked - Fare: ₹{totalFare}";
            }
        }
    }
    class Assignment_7_4
    {
        private const double TotalFare = 500;

        static void Main()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            Concession concession = new Concession();
            string result = concession.CalculateConcession(age, TotalFare);

            Console.WriteLine($"\n👤 Passenger: {name}");
            Console.WriteLine($"🎫 Result: {result}");
            Console.Read();
        }
    }
}
