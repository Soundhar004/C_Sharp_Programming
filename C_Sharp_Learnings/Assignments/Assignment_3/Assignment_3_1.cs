using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Assignments
{
    class Accounts
    {
        public int balance;
        protected int account_no;
        protected string cust_name;

        public void GettingAccountInfo(out int account_no, out string cust_name, out string acc_type)
        {
            
            Console.WriteLine("Enter your account number : ");
            account_no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the customer name : ");
            cust_name = Console.ReadLine();
            Console.WriteLine("Enter the account type Deposite or Withdrawal, Please type D/W : ");
            acc_type = Console.ReadLine();
           
        }

        public void Credit(int amount)
        {
            this.balance =  this.balance + amount;
        }
        public void Withdraw(int withdraw)
        {
            this.balance = this.balance - withdraw;
        }
        public void DisplayBalance()
        {
            Console.WriteLine($"Your Current Balance is : {this.balance}");
        }


        static void Main(){
            Accounts Obj_Acc = new Accounts();
            int a = 0;
            while (a<5)
            {
                Console.WriteLine("Do you want to use your account Yes/No : ");
                string Account_Access = Console.ReadLine();
                if (Account_Access == "Yes")
                {
                    
                    Obj_Acc.GettingAccountInfo(out int account_no, out string cust_name, out string acc_type);
                    Obj_Acc.account_no = account_no;
                    Obj_Acc.cust_name = cust_name;
                    if (acc_type == "D")
                    {
                        Console.WriteLine("How much amount that you want to deposite : ");
                        int Amount = Convert.ToInt32(Console.ReadLine());

                        Obj_Acc.Credit(Amount);
                        Console.WriteLine("Credited Successfully..");
                        Console.WriteLine("Want to display the balance Yes/No : ");
                        string CheckBalance = Console.ReadLine();
                        if (CheckBalance == "Yes")
                        {
                            Obj_Acc.DisplayBalance();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Thankyou, Visit Again.....");
                            continue;
                        }
                    }
                    else if (acc_type == "W")
                    {
                        Console.WriteLine("How much amount that you want to withdraw : ");
                        int Amount = Convert.ToInt32(Console.ReadLine());
                        if (Amount <= Obj_Acc.balance)
                        {
                            Obj_Acc.Withdraw(Amount);
                            Console.WriteLine("Debited Successfully..");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, You don't have sufficient ..");
                        }
                        Console.WriteLine("Want to display the balance Yes/No : ");
                        string CheckBalance = Console.ReadLine();
                        if (CheckBalance == "Yes")
                        {
                            Obj_Acc.DisplayBalance();
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Thankyou, Visit Again.....");
                            continue;
                        }

                    }
                    
                }
                else
                {
                    break;
                }
                Console.Read();
            }
        }

    }

}
