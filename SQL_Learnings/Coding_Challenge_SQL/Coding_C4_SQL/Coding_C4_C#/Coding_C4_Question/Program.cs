using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_C4_Question
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize employee list
            var empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager",     DOB = DateTime.Parse("1984-11-16"), DOJ = DateTime.Parse("2011-06-08"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin",   LastName = "Dhalla",     Title = "AsstManager", DOB = DateTime.Parse("1994-08-20"), DOJ = DateTime.Parse("2012-07-07"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza",        Title = "Consultant",  DOB = DateTime.Parse("1987-11-14"), DOJ = DateTime.Parse("2015-04-12"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba",    LastName = "Shaikh",     Title = "SE",          DOB = DateTime.Parse("1990-06-03"), DOJ = DateTime.Parse("2016-02-02"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia",   LastName = "Shaikh",     Title = "SE",          DOB = DateTime.Parse("1991-03-08"), DOJ = DateTime.Parse("2014-08-08"), City = "Chennai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit",    LastName = "Pathak",     Title = "Consultant",  DOB = DateTime.Parse("1989-12-02"), DOJ = DateTime.Parse("2015-06-01"), City = "Mumbai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay",   LastName = "Natrajan",   Title = "Associate",   DOB = DateTime.Parse("1993-11-11"), DOJ = DateTime.Parse("2014-11-06"), City = "Chennai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul",   LastName = "Dubey",      Title = "Associate",   DOB = DateTime.Parse("1994-11-15"), DOJ = DateTime.Parse("2014-12-03"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh",  LastName = "Mistry",     Title = "Associate",   DOB = DateTime.Parse("1992-08-12"), DOJ = DateTime.Parse("2014-03-21"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit",   LastName = "Shah",       Title = "Manager",     DOB = DateTime.Parse("1991-04-12"), DOJ = DateTime.Parse("2016-01-02"), City = "Pune" }
            };

            Console.WriteLine("A. All Employees: ");
            foreach (var emp in empList)
            {
                PrintEmployee(emp);
            }

            Console.WriteLine("\nB. Employees NOT from Mumbai: ");
            foreach (var emp in empList)
            {
                if (emp.City != "Mumbai")
                {
                    PrintEmployee(emp);
                }
            }

            Console.WriteLine("\nC. Employees with Title = 'AsstManager': ");
            foreach (var emp in empList)
            {
                if (emp.Title == "AsstManager")
                {
                    PrintEmployee(emp);
                }
            }

            Console.WriteLine("\nD. Employees with Last Name starting with 'S': ");
            foreach (var emp in empList)
            {
                if (emp.LastName.StartsWith("S"))
                {
                    PrintEmployee(emp);
                }
            }
            Console.Read();
        }

        static void PrintEmployee(Employee emp)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, " +
                              $"DOB: {emp.DOB:dd-MM-yyyy}, DOJ: {emp.DOJ:dd-MM-yyyy}, City: {emp.City}");
        }
    }
}
