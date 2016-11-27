using BcApiFrame.Data.BLL.ApiBase;
using BcApiFrame.Data.Entity.ApiBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace BcApiFrame.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add_BaseFunctionByMvc();
            //Add_BaseFunctionByApi();
            //Add_BaseAppByUser();
            Console.ReadLine();
        }

        static void Add_BaseFunctionByApi()
        {
            var Types = typeof(BcApiFrame.Web.Api.TestController).Assembly.GetTypes();
            var controllers = from t in Types
                              where typeof(ApiController).IsAssignableFrom(t) && !t.IsAbstract
                              orderby t.FullName
                              from m in t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                              where !m.IsSpecialName
                              select new { ControllerName = t.Name, ActionName = m.Name, Params = m.GetParameters() };

            controllers.ToList()
                .ForEach(c =>
                {
                    Add_BaseFunction(c.ControllerName, c.ActionName, BaseFunctionCategory.Bunesss);
                });
        }

        static void Add_BaseFunctionByMvc()
        {
            var Types = typeof(BcApiFrame.Web.Controllers.HomeController).Assembly.GetTypes();
            var controllers = from t in Types
                              where typeof(Controller).IsAssignableFrom(t) && !t.IsAbstract
                              orderby t.FullName
                              from m in t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                              where !m.IsSpecialName
                              select new { ControllerName = t.Name, ActionName = m.Name, Params = m.GetParameters() };

            controllers.ToList()
                .ForEach(c =>
                {
                    Add_BaseFunction(c.ControllerName, c.ActionName, BaseFunctionCategory.Default);
                });
        }

        static void Add_BaseAppByUser()
        {
            var entity = new BaseUser();
            entity.Account = "demo";
            entity.Password = "demo";
            entity.Category = BaseUserCategory.Customer;
            entity.UserDetail = new BaseUserDetail()
            {
                Name = "梁智慧",
                Email = "214909012@qq.com",
                Sex = BaseSex.Boy,
                Note = "首席布道师"
            };
            entity.Apps = new List<BaseApp>();
            entity.Apps.Add(new BaseApp()
            {
                Name = "Test",
                Secret = Guid.NewGuid().ToString()
            });
            var reuslt = BaseUserBLL.Instance.Add(entity);
        }

        private static void Add_BaseFunction(string ControllerName, string ActionName, BaseFunctionCategory Category)
        {
            var entity = new BaseFunction();
            entity.Controller = ControllerName;
            entity.Action = ActionName;
            entity.ApiCode = "00000";
            entity.Category = Category;
            var result = BaseFunctionBLL.Instance.Add(entity);
        }

    }
}
