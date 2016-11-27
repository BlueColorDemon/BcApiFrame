using BcApiFrame.Data.BLL.ApiBase;
using BcApiFrame.Data.Entity.ApiBase;
using BcApiFrame.Permission.App_GlobalResources;
using BcApiFrame.Util.Msg;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace BcApiFrame.Permission.Filter_Permission
{
    /// <summary>
    /// mvc 视图,全局权限
    /// 要求有对应的 PermissionError 展示页面
    /// </summary>
    public class Filter_MvcPermission : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            string json = string.Empty;
            var urlTpl = "/Home/PermissionError?msg={0}";
            string url = string.Empty;
            var permission = new PermissionModel()
            {
                ControllerName = filterContext.RouteData.Values["controller"] as string,
                ActionName = filterContext.RouteData.Values["action"] as string
            };

            if (permission.ActionName == "PermissionError" && permission.ControllerName == "Home")
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                if (Valid.NoKey(HttpContext.Current.Request.Headers.AllKeys))
                {
                    json = JsonConvert.SerializeObject(new ApiMsg
                    {
                        status = ApiMsgStatus.error,
                        msg = Resources.error,
                        info = new { result = Resources.ValidKey }
                    });
                    url = string.Format(urlTpl, json);
                    filterContext.HttpContext.Response.Redirect(url);
                    return;
                }
                else
                {
                    #region 权限验证
                    permission.AppKey = new Guid(HttpContext.Current.Request.Headers["AppKey"]);
                    permission.AppSecret = HttpContext.Current.Request.Headers["AppSecret"];
                    if (Valid.ValidKey(permission))
                    {
                        if (Valid.ValidPermission(permission))
                        {
                            base.OnActionExecuting(filterContext);
                        }
                        else
                        {//                   
                            json = JsonConvert.SerializeObject(new ApiMsg
                            {
                                status = ApiMsgStatus.error,
                                msg = Resources.error,
                                info = new { result = Resources.ValidPermission }
                            });
                            url = string.Format(urlTpl, json);
                            filterContext.HttpContext.Response.Redirect(url);
                        }
                    }
                    else
                    {//
                        json = JsonConvert.SerializeObject(new ApiMsg
                        {
                            status = ApiMsgStatus.error,
                            msg = Resources.error,
                            info = new { result = Resources.ValidKey }
                        });
                        url = string.Format(urlTpl, json);
                        filterContext.HttpContext.Response.Redirect(url);
                    }
                    #endregion
                }
            }


        }
    }

    /// <summary>
    /// api 接口,全局权限
    /// 
    /// </summary>
    public class Filter_ApiPermission : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// 接口调用之前
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            string json = string.Empty;

            if (Valid.NoKey(HttpContext.Current.Request.Headers.AllKeys))
            {
                json = JsonConvert.SerializeObject(new ApiMsg
                {
                    status = ApiMsgStatus.error,
                    msg = Resources.error,
                    info = new { result = Resources.ValidKey }
                });

                actionContext.Response = new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
                return;
            }

            var permission = new PermissionModel()
            {
                ControllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName,
                ActionName = actionContext.ActionDescriptor.ActionName,
                AppKey = new Guid(HttpContext.Current.Request.Headers["AppKey"]),
                AppSecret = HttpContext.Current.Request.Headers["AppSecret"]
            };

            #region 权限验证
            if (Valid.ValidKey(permission))
            {
                if (Valid.ValidPermission(permission))
                {
                    base.OnActionExecuting(actionContext);
                }
                else
                {//                   
                    json = JsonConvert.SerializeObject(new ApiMsg
                    {
                        status = ApiMsgStatus.error,
                        msg = Resources.error,
                        info = new { result = Resources.ValidPermission }
                    });

                    actionContext.Response = new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
                }
            }
            else
            {//
                json = JsonConvert.SerializeObject(new ApiMsg
                {
                    status = ApiMsgStatus.error,
                    msg = Resources.error,
                    info = new { result = Resources.ValidKey }
                });

                actionContext.Response = new HttpResponseMessage() { StatusCode = HttpStatusCode.Unauthorized, Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
            }
            #endregion
        }

    }

    /// <summary>
    /// 权限模型
    /// </summary>
    public class PermissionModel
    {
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// AppKey
        /// </summary>
        public Guid? AppKey { get; set; }
        /// <summary>
        /// App密钥
        /// </summary>
        public string AppSecret { get; set; }
    }

    /// <summary>
    /// 验证器
    /// </summary>
    public class Valid
    {

        public static bool NoKey(string[] keys)
        {
            int result = 0;
            foreach (var key in keys)
            {
                if (key == "AppKey" || key == "AppSecret")
                {
                    result++;
                }
            }
            return result == 2
                ? false//有Key，
                : true;//没有Key，
        }

        /// <summary>
        /// 第一步
        /// 是否有效AppKey和App密钥
        /// </summary>
        /// <returns></returns>
        public static bool ValidKey(PermissionModel model)
        {
            var app = BaseAppBLL.Instance.Single(p => p.Id == model.AppKey && p.Secret == model.AppSecret);
            if (app != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 第二步
        /// 是否有权限访问此接口
        /// </summary>
        /// <returns></returns>
        public static bool ValidPermission(PermissionModel model)
        {
            var app = BaseAppBLL.Instance.Single(p => p.Id == model.AppKey && p.Secret == model.AppSecret);
            foreach (var role in app.Roles)
            {
                foreach (var function in role.Functions)
                {
                    if (function.Controller.ToLower() == model.ControllerName.ToLower() + "controller" && function.Action.ToLower() == model.ActionName.ToLower())
                    {//循环比对出权限
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
