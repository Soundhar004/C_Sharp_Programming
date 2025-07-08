using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments.Assignment_7
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }

        public void Display()
        {
            Console.WriteLine($"ID: {EmpId}, Name: {EmpName}, City: {EmpCity}, Salary: {EmpSalary}");
        }
    }
    class Assignment_7_3
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("How many employees do you want to enter? ");
            int count = int.Parse(Console.ReadLine());

            // Accept employee data from user
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n--- Enter details for Employee #{i + 1} ---");
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine());

                employees.Add(new Employee { EmpId = id, EmpName = name, EmpCity = city, EmpSalary = salary });
            }

            Console.WriteLine("\n👉 a. All Employees:");
            foreach (Employee emp in employees)
                emp.Display();

            Console.WriteLine("\n👉 b. Employees with Salary > 45000:");
            foreach (Employee emp in employees.Where(e => e.EmpSalary > 45000))
                emp.Display();

            Console.WriteLine("\n👉 c. Employees from Bangalore Region:");
            foreach (Employee emp in employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase)))
                emp.Display();

            Console.WriteLine("\n👉 d. Employees sorted by Name (Ascending):");
            foreach (Employee emp in employees.OrderBy(e => e.EmpName))
                emp.Display();

            Console.Read();

        }
    }
}
