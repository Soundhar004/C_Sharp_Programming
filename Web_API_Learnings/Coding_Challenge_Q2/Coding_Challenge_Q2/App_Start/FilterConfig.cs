using System.Web;
using System.Web.Mvc;

namespace Coding_Challenge_Q2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
