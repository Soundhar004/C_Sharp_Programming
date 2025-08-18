using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Billing_System
{
    public class Verify_The_Billing
    {

        public string ValidateUnitsConsumed(int unitsConsumed)
        {
            if (unitsConsumed < 0)
                return "Given units is invalid";
            return null;
        }
    }
}
