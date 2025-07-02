using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments
{
    class Scholarship
    {
        double marks, fees, scholar_amt, tot_amt;

        public void Merit()
        {
            if(this.marks >=70 && this.marks <= 80){
                scholar_amt = (fees * 20) / 100;
                tot_amt = fees - scholar_amt; 
            }
            else if(this.marks>80 && this.marks <= 90)
            {
                scholar_amt = (fees * 30) / 100;
                tot_amt = fees - scholar_amt;
            }
            else if (this.marks >90)
            {
                scholar_amt = (fees * 50) / 100;
                tot_amt = fees - scholar_amt;
            }
            Console.WriteLine($"Your scholarship amount  : {scholar_amt}");
            Console.WriteLine($"The amount you want to be paid : {tot_amt}");

        }

        public void GetInfo()
        {
            Console.WriteLine("Enter your marks : ");
            this.marks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your Fees : ");
            this.fees = Convert.ToDouble(Console.ReadLine());
        }
        static void Main()
        {
            Scholarship obj = new Scholarship();
            obj.GetInfo();
            obj.Merit();
            Console.Read();
        }
    }
}
