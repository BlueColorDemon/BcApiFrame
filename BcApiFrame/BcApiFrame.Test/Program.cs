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
            //Add_BaseUser_WithUserDetail_WithApps();
            //Add_BaseRole();
            //Add_RoleFunction_RoleApp();
            Console.ReadLine();
        }

        /// <summary>
        /// 第一步
        /// 添加-Function ,Api
        /// </summary>
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

        /// <summary>
        /// 第二步
        /// 添加-Function ,Mvc
        /// </summary>
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

        /// <summary>
        /// 第三步
        /// 添加-User，包含UserDetail、Apps
        /// </summary>
        static void Add_BaseUser_WithUserDetail_WithApps()
        {
            var user = new BaseUser();
            user.Account = "demo";
            user.Password = "demo";
            user.Category = BaseUserCategory.Customer;

            var userDetail = new BaseUserDetail()
            {
                Name = "梁智慧",
                Email = "214909012@qq.com",
                Sex = BaseSex.Boy,
                Note = "首席布道师"
            };

            var app = new BaseApp();
            app.Name = "Test";
            app.Secret = Guid.NewGuid().ToString();

            user.UserDetail = userDetail;
            user.Apps.Add(app);
            var reuslt = BaseUserBLL.Instance.Add(user);
        }

        /// <summary>
        /// 第四步
        /// 添加-Role
        /// </summary>
        static void Add_BaseRole()
        {
            var functions = BaseFunctionBLL.Instance.Where(p => p.Category == BaseFunctionCategory.Bunesss).ToList();
            var apps = BaseAppBLL.Instance.Where(p => p.Category == BaseAppCategory.Default).ToList();

            var appRole = new BaseRole();
            appRole.Name = "AppTestRole";
            appRole.Category = BaseRoleCategory.App;
            //以下错误原因：一个实体对象不能由多个 IEntityChangeTracker 实例引用。
            //appRole.Functions = functions;
            //appRole.Apps = apps;
            var reuslt = BaseRoleBLL.Instance.Add(appRole);
        }


        /// <summary>
        /// 第五步
        /// 添加-RoleFunction，RoleApp
        /// </summary>
        static void Add_RoleFunction_RoleApp()
        { //以下错误原因：一个实体对象不能由多个 IEntityChangeTracker 实例引用。

            var functions = BaseFunctionBLL.Instance.Where(p => p.Category == BaseFunctionCategory.Bunesss).ToList();
            var apps = BaseAppBLL.Instance.Where(p => p.Category == BaseAppCategory.Default).ToList();
            var appRole = BaseRoleBLL.Instance.Single(p => p.Name == "AppTestRole" && p.Category == BaseRoleCategory.App);

            //var db = new Data.Entity.ModelAC();

            //foreach (var function in functions)
            //{
            //    var sql = string.Format(@"INSERT INTO [dbo].[BaseRoleFunction]
            //                                           ([Role_Id]
            //                                           ,[Controller]
            //                                           ,[Action])
            //                                     VALUES
            //                                           ('{0}'
            //                                           ,'{1}'
            //                                           ,'{2}')",
            //                                           appRole.Id, function.Controller, function.Action);
            //    var reuslt = db.Database.ExecuteSqlCommand(sql);
            //}

            //foreach (var app in apps)
            //{
            //    var sql = string.Format(@"INSERT INTO [dbo].[BaseRoleApp]
            //                                           ([Role_Id]
            //                                           ,[App_Id])
            //                                     VALUES
            //                                           ('{0}'
            //                                           ,'{1}')",
            //                                           appRole.Id, app.Id);
            //    var reuslt = db.Database.ExecuteSqlCommand(sql);
            //}
        }


        /// <summary>
        ///  添加-Function
        /// </summary>
        /// <param name="ControllerName"></param>
        /// <param name="ActionName"></param>
        /// <param name="Category"></param>
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
