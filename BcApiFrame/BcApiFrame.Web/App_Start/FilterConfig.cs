using System.Web;
using System.Web.Mvc;

namespace BcApiFrame.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Permission.Filter_Permission.Filter_MvcPermission());
            filters.Add(new Log.Filter_Monitor.StatisticsTrackerAttribute());
            filters.Add(new Log.Filter_ErrorRecord.MvcHandleErrorAttribute());
        }
    }
}
