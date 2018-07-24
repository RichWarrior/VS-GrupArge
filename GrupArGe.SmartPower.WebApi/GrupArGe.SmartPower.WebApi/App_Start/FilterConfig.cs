using System.Web;
using System.Web.Mvc;

namespace GrupArGe.SmartPower.WebApi
{
  public class FilterConfig
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }
  }
}
