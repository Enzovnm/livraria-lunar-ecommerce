using System.Web;
using System.Web.Mvc;

namespace Livraria_Lunar_E_commerce
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
