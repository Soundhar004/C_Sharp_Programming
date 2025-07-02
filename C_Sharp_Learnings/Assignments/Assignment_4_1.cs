using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments
{
    //Assignment - 4, Question no - 2.
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }
    class Assignment_4_1
    {
        static List<Employee> employeeList = new List<Employee>();

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1: AddEmployee(); break;
                        case 2: ViewAllEmployees(); break;
                        case 3: SearchEmployee(); break;
                        case 4: UpdateEmployee(); break;
                        case 5: DeleteEmployee(); break;
                        case 6: exit = true; break;
                        default: Console.WriteLine("Invalid choice! Please select from the menu."); break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            Console.WriteLine("Exiting the program. Goodbye!");
        }

        static void AddEmployee()
        {
            try
            {
                Employee emp = new Employee();
                Console.Write("Enter ID: ");
                emp.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Name: ");
                emp.Name = Console.ReadLine();
                Console.Write("Enter Department: ");
                emp.Department = Console.ReadLine();
                Console.Write("Enter Salary: ");
                emp.Salary = Convert.ToDouble(Console.ReadLine());
                employeeList.Add(emp);
                Console.WriteLine("Employee added successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter correct data types.");
            }
        }

        static void ViewAllEmployees()
        {
            if (employeeList.Count == 0)
            {
                Console.WriteLine("No employee records found.");
                return;
            }

            Console.WriteLine("\n=== Employee Records ===");
            foreach (Employee emp in employeeList)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary:C}");
            }
        }

        static void SearchEmployee()
        {
            Console.Write("Enter Employee ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employeeList.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                Console.WriteLine($"Found - ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary:C}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employeeList.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                Console.Write("Enter new Name (leave blank to keep unchanged): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name)) emp.Name = name;

                Console.Write("Enter new Department (leave blank to keep unchanged): ");
                string dept = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dept)) emp.Department = dept;

                Console.Write("Enter new Salary (leave blank to keep unchanged): ");
                string salaryStr = Console.ReadLine();
                if (double.TryParse(salaryStr, out double salary)) emp.Salary = salary;

                Console.WriteLine("Employee details updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Employee emp = employeeList.FirstOrDefault(e => e.Id == id);

            if (emp != null)
            {
                employeeList.Remove(emp);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}
