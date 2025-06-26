using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments
{
    class SaleDetails
    {
       
        int Salesno, Productno, Price, dateofsale, Qnty, TotalAmount;
        public SaleDetails(int salesno, int pro_no, int price, int dateofsale, int qnty)
        {
            this.Salesno = salesno;
            this.Productno = pro_no;
            this.Price = price;
            this.dateofsale = dateofsale;
            this.Qnty = qnty;
        }

        public void Sales()
        {
            this.TotalAmount = this.Qnty * this.Price;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"The total price of your products : Rs.{this.TotalAmount}");
            Console.WriteLine($"Your sales number : {this.Salesno}");
            Console.WriteLine($"Your product  number : {this.Productno}");
            Console.WriteLine($"Price of yout product : {this.Price}");
            Console.WriteLine($"Date of your sale : {this.dateofsale}");
            Console.WriteLine($"Qauantity of your product : {this.Qnty}");
        }


        static void Main() 
        {


            Console.WriteLine("Enter the sales number : ");
            int sal_no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the product number : ");
            int pro_no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price : ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the date of sale : ");
            int dateofsale = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the quantity : ");
            int qnty = Convert.ToInt32(Console.ReadLine());

            SaleDetails obj = new SaleDetails(sal_no,pro_no,price,dateofsale,qnty);
            obj.Sales();
            obj.DisplayInfo();
            Console.Read();
            


        }
    }
}
