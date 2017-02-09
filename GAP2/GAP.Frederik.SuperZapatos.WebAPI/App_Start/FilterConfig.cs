using System.Web;
using System.Web.Mvc;

namespace GAP.Frederik.SuperZapatos.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
