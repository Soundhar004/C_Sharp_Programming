using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Crispy_CSharp
{
    class Ooops1
    {
        static void Main(string[] args)
        {
            OverLoading obj = new OverLoading();
            Console.WriteLine(obj.add(1, 2));
            Console.WriteLine(obj.add(1, 2));
            

            OverRiding obj1 = new OverRiding();
            obj1.Multiple();
            OverRiding2 obj2 = new OverRiding2();
            obj2.Multiple();


        }
    }

    class OverLoading
    {
        public int add(int a, int b)
        {
            return a + b;
        }
        public double add(double a, double b)
        {
            return a + b;
        }
    }

    class OverRiding
    {

        public void GetValue(out int v1, out int v2)
        {
            Console.WriteLine("Enter the Value1 : ");
            v1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Value2 : ");
            v2 = Convert.ToInt32(Console.ReadLine());
          
        }
        public virtual void Multiple()
        {
            GetValue(out int v1, out int v2);
            /*int v1 = 10, v2 = 20;*/
            int v3 = v1 * v2;
            Console.WriteLine($"From Overriding : {v3}");
        }

    }

    class OverRiding2 : OverRiding
    {
        public override void Multiple()
        {
            GetValue(out int v1, out int v2);
            /*int v1 = 10, v2 = 20;*/
            int v3 = v1 * v2 * 2;
            Console.WriteLine($"From Overriding : {v3}");
            Console.Read();
        }
    }
}
