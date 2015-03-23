using System.Web;
using System.Web.Mvc;

namespace MVC_My_Gmail_Contacts
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
