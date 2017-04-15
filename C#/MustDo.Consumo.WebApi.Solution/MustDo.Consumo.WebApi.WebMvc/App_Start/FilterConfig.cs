using System.Web;
using System.Web.Mvc;

namespace MustDo.Consumo.WebApi.WebMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
