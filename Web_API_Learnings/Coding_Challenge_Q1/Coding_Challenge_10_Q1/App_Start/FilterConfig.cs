using System.Web;
using System.Web.Mvc;

namespace Coding_Challenge_10_Q1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
