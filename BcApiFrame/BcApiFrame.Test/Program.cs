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

namespace BcApiFrame.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add_BaseFunctionByApi();
            //Add_BaseApp()
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

        static void Add_BaseFunction(string ControllerName, string ActionName, BaseFunctionCategory Category)
        {
            var entity = new BaseFunction();
            entity.Controller = ControllerName;
            entity.Action = ActionName;
            entity.ApiCode = "00000";
            entity.Category = Category;
            var result = BaseFunctionBLL.Instance.Add(entity);
        }

        static void Add_BaseApp()
        {
            var entity = new BaseApp();
            entity.Name = "Test";
            entity.Secret = Guid.NewGuid().ToString();
            var result = BaseAppBLL.Instance.Add(entity);
        }

    }
}
