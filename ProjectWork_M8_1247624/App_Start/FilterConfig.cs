using System.Web;
using System.Web.Mvc;

namespace ProjectWork_M8_1247624
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
