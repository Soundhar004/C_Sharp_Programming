using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Learnings.Models
{
    public partial class Cust_Order_Result
    {
        public int OrderID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
    }
}