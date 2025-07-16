using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C_Sharp_Learnings.Rough.Factory_Pattern
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscounts(decimal price);
    }
    /* class SeasonalDiscount : IDiscountStrategy
     {
         public decimal ApplyDiscounts(decimal price)
         {
             return price * 0.90m;
         }
     }*/
    /*class ClearanceDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscounts(decimal price)
        {
            return price * 0.70m;
        }
    }*/
    /* class MembershipDiscount : IDiscountStrategy
     {
         public decimal ApplyDiscounts(decimal price)
         {
             return price * 0.95m;
         }
     }*/
    public class DiscountFactory
    {
        public static IDiscountStrategy GetDiscountStrategy(string type)
        {
            switch (type.ToLower())
            {
                case "seasonal":
                    return new SeasonalDiscount();
                case "clearance":
                    return new ClearanceDiscount();
                case "membership":
                    return new MembershipDiscount();
                default:
                    throw new ArgumentException("Invalid discount type.");
            }
        }
    }
    class FactoryPattern
    { 
        static void Main()
        {
            Console.Write("Enter the product price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter discount type (Seasonal, Clearance, Membership): ");
            string discountType = Console.ReadLine();

            try
            {
                IDiscountStrategy strategy = DiscountFactory.GetDiscountStrategy(discountType);
                decimal finalPrice = strategy.ApplyDiscounts(price);

                Console.WriteLine($"\nOriginal Price: {price:C}");
                Console.WriteLine($"Discount Type: {discountType}");
                Console.WriteLine($"Final Price: {finalPrice:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

    }

}
