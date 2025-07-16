using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Learnings.Rough.Factory_Pattern
{
    public class ClearanceDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscounts(decimal price)
        {
            return price * 0.70m;
        }
    }
}
