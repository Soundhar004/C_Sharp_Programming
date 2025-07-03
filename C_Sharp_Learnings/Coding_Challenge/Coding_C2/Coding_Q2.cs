using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Coding_Challenge.Coding_C2
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }

    class Coding_Q2
    {
        static void Main()
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("Enter details for 10 products:");

            for (int i = 0; i < 10; i++)
            {
                Product p = new Product();

                Console.WriteLine($"\nProduct {i + 1}:");

                Console.Write("Enter Product ID: ");
                p.ProductId = int.Parse(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                p.ProductName = Console.ReadLine();

                Console.Write("Enter Price: ");
                p.Price = double.Parse(Console.ReadLine());

                products.Add(p);
            }

            // Sorting products by Price
            var sortedProducts = products.OrderBy(p => p.Price).ToList();

            Console.WriteLine("\n Sorted Products by Price:");

            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: Rs.{product.Price:F2}");
            }
            Console.Read();
        }
    }
}
