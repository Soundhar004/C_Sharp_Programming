using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Coding_Challenge.Coding_C2
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Coding_Q1
    {
        static void Main()
        {
            Console.WriteLine("Enter student type (Undergraduate/Graduate):");
            string type = Console.ReadLine();

            Console.WriteLine("Enter student name :");
            string name = Console.ReadLine();

            Console.WriteLine("Enter student ID :");
            int studentId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter student mark : ");
            double grade = double.Parse(Console.ReadLine());

            Student student;

            if (type.ToLower() == "undergraduate")
            {
                student = new Undergraduate();
            }
            else if (type.ToLower() == "graduate")
            {
                student = new Graduate();
            }
            else
            {
                Console.WriteLine("Invalid student type.");
                return;
            }

            student.Name = name;
            student.StudentId = studentId;
            student.Grade = grade;

            bool result = student.IsPassed(student.Grade);
            Console.WriteLine($"{student.Name} ({type}) Passed: {result}");
            Console.Read();
        }
    }
}
