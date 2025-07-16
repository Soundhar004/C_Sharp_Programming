using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon
{
    class Program
    {
        static void Main(string[] args)
        {
            singletonClass trainer = singletonClass.GetInstance();
            trainer.Show("working with pattern");

            singletonClass tr = singletonClass.GetInstance();
            tr.Show("working with single object ");

            singletonClass manager = singletonClass.GetInstance();
            manager.Show("Invoking the object for the third time...");
            Console.Read();
        }
    }
    public class singletonClass
    {
        private static int counter = 0;
        private static singletonClass spobj = null;

        public static singletonClass GetInstance()
        {
            if (spobj == null)
            {
                spobj = new singletonClass();
            }
            return spobj;
        }
        private singletonClass()
        {
            counter++;
            Console.WriteLine("Counter value : " + counter.ToString());
        }
        public void Show(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
