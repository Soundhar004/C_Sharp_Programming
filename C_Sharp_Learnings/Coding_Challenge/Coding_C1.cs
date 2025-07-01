using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Coding_Challenge
{
    class Coding_C1
    {
        public void RemoveChar()
        {

            Console.WriteLine("Enter the string : ");
            string str_val = Console.ReadLine();
            Console.WriteLine("Enter the index want to remove : ");
            int index_val = Convert.ToInt32( Console.ReadLine());
            string str_new = str_val.Remove(index_val,1);
            Console.WriteLine(str_new);
        }

        public void ChangeChar()
        {
            Console.WriteLine("Enter the string : ");
            string str_val = Console.ReadLine();
            char[] char_str = str_val.ToCharArray();
            char val_0 =  char_str[0], val_1=char_str[char_str.Length-1];
            char_str[0] = val_1;
            char_str[char_str.Length - 1]= val_0;
            Console.WriteLine(char_str);
            
        }

        public void LargeNumber()
        {
            /*int[] a = { 1, 2, 3 };*/
            int[] arry2 = new int[4];

            for (int i = 0; i < arry2.Length; i++)
            {
                Console.Write("Enter the element - {0} : ", i+1);  
                arry2[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine($"Largest value is : {arry2.Max()}");
            Console.Read();
        }

        static void Main()
        {
            Coding_C1 obj = new Coding_C1();
            obj.RemoveChar();
            obj.ChangeChar();
            obj.LargeNumber();
        }

    }


   


}
