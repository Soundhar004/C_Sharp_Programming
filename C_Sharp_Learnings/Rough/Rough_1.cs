/*using System;
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


    Question No 2 
    class Box
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

        static void Main(string[] args)
        {
            int[] b1 = { 4, 3 }, b2 = { 4, 3, 2 };
            Box Object = new Box(b1, b2);
            Object.Display();

        }

    }

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

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Day7
    {
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public double Salary { get; set; }

            List<Employee> employeeList = new List<Employee>();

            //adding one Employee at a time
            internal void AddStudent(Employee employee)
            {
                employeeList.Add(employee);
            }

            //Display the student

            internal List<Employee> Displayemployee()
            {
                return employeeList;
            }

            //Get emp by id

            internal List<Employee> GetEmployeebyId(int id)
            {
                List<Employee> employee = new List<Employee>();

                foreach (var emp in employeeList)
                {
                    if (emp.Id == id)
                    {
                        employee.Add(emp);

                    }
                }

                return employee;
            }

            public List<Employee> Update_Employee(int id, string name, string department, double salary)
            {
                List<Employee> employee = new List<Employee>();
                foreach (var emp in employeeList)
                {
                    if (emp.Id == id)
                    {
                        emp.Name = name;
                        emp.Department = department;
                        emp.Salary = salary;
                    }
                }
                return employee;
            }

            public List<Employee> delete_Employee(int id)
            {
                List<Employee> employee = new List<Employee>();
                foreach (var emp in employeeList)
                {
                    if (emp.Id == id)
                    {
                        employee.Remove(emp);
                    }
                }
                return employee;
            }

        }
        class ListDemo
        {
            static void Main()
            {
                // ArrayList al = new ArrayList();
                //al.Add(90); //boxing

                List<string> booksList = new List<string>();

                Employee employee = new Employee();

                List<Employee> employees_data = new List<Employee>();

                //Add the student

                employee.AddStudent(new Employee { Id = 1, Name = "Hari", Department = "IT", Salary = 98 });
                employee.AddStudent(new Employee { Id = 2, Name = "Nila", Department = "IT", Salary = 78 });
                employee.AddStudent(new Employee { Id = 3, Name = "Suman", Department = "CSE", Salary = 67 });
                employee.AddStudent(new Employee { Id = 4, Name = "John", Department = "ECE", Salary = 90 });

                //display the student

                studentData = student.DisplayStudent();
                Console.WriteLine("------------------Display Student---------------------");
                foreach (var item in studentData)
                {
                    Console.WriteLine($"ID:{item.StudentId + " " + item.StudentName + " " + item.StudentCourse }");
                }

                Console.WriteLine("------------------Display Student by course---------------------");
                //Display the student by course
                studentData = student.GetStudentsByCourse("IT");
                foreach (var item in studentData)
                {
                    Console.WriteLine($"ID:{item.StudentId + " " + item.StudentName + " " + item.StudentCourse }");
                }
            }
        }
    }


}
*/