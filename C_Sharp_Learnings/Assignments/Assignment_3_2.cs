using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments
{
    class Student
    {
        public string stud_name,Class,branch;
        public int roll_no, sem,avg_marks;
        bool fail = false;
       

        public void GetInfo(string info)
        {
            Console.WriteLine($"Enter the {info} : ");
            if (info == "name"){
                this.stud_name = Console.ReadLine();
            }
            else if (info == "class"){
                this.Class = Console.ReadLine();
            }
            else if (info == "branch"){
                this.branch = Console.ReadLine();
            }
            else if (info == "roll no"){
                this.roll_no = Convert.ToInt32(Console.ReadLine());
            }
            else if (info == "semester"){
                this.sem = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void GetMarks()
        {
            int[] arry = new int[5];
            for(int i =0; i< arry.Length; i++)
            {
                Console.WriteLine("Enter the subject {0} mark ", i + 1);
                arry[i] = Convert.ToInt32(Console.ReadLine());
            }
            this.avg_marks = arry.Sum() / arry.Length;

            foreach(int i in arry)
            {
                if (i < 35)
                {
                    this.fail = true;
                }
            }



        }

        public void DisplayInfo()
        {
            if(this.fail == false)
            {
                if (this.avg_marks > 50)
                {
                    Console.WriteLine("Your result is : PASS");
                }
            }
            else
            {
                Console.WriteLine("Your result is : FAIL");
            }
            Console.WriteLine($"Your Average Mark : {this.avg_marks}");
            Console.WriteLine($"Student name : {this.stud_name}");
            Console.WriteLine($"Student roll no : {this.roll_no}");
            Console.WriteLine($"Student class : {this.Class}");
            Console.WriteLine($"Student branch : {this.branch}");
            Console.WriteLine($"Student semester : {this.sem}");
        }
       
        
        static void Main()
        {
           /* Console.WriteLine("Enter the name : ");
            string stud_name = Console.ReadLine();
            Console.WriteLine("Enter the roll no : ");
            string stud_name = Console.ReadLine();
            Console.WriteLine("Enter the class name : ");
            string stud_name = Console.ReadLine();
            Console.WriteLine("Enter the name : ");
            string stud_name = Console.ReadLine();
            Console.WriteLine("Enter the name : ");
            string stud_name = Console.ReadLine();*/
            Student obj = new Student();
            obj.GetInfo("name");
            obj.GetInfo("roll no");
            obj.GetInfo("class");
            obj.GetInfo("branch");
            obj.GetInfo("semester");
            obj.GetMarks();
            obj.DisplayInfo();
            Console.Read();


        }

    }

}
