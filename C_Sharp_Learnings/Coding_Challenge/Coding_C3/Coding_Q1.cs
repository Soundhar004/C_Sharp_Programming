using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Coding_Challenge.Coding_C3
{

    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;

            Console.WriteLine($"Enter the points scored in {no_of_matches} matches:");

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Match {i + 1}: ");
                scores[i] = int.Parse(Console.ReadLine());
                sum += scores[i];
            }

            double average = (double)sum / no_of_matches;

            Console.WriteLine("\n--- Results ---");
            Console.WriteLine($"Total Matches Played: {no_of_matches}");
            Console.WriteLine($"Sum of Scores: {sum}");
            Console.WriteLine($"Average Score: {average:F2}");
        }
    }
    class Coding_Q1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of matches played: ");
            int matches = int.Parse(Console.ReadLine());

            CricketTeam team = new CricketTeam();
            team.Pointscalculation(matches);
            Console.Read();
        }
    }
}
