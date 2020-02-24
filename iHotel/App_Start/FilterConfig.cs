using System.Web;
using System.Web.Mvc;

namespace FIT5032_Assign1_v6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
