using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleTon;

namespace Client_2
{
    class Program
    {
        static void Main(string[] args)
        {
            singletonClass training = singletonClass.GetInstance();
            {
                training.Show("This is a dotnet Training on Design Patterns...");
                Console.Read();
            }
        }
    }
}
