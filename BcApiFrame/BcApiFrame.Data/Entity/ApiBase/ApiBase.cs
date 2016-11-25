using BC.AppCloud.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcApiFrame.Data.Entity.ApiBase
{
    /// <summary>
    /// 基本-功能模块
    /// </summary>
    public class BaseFunction : BaseModel
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public string CodeType { get; set; }

        public string Code { get; set; }
    }

    /// <summary>
    /// 基本-客户角色
    /// </summary>
    public class BaseCustomerRole : BaseModel
    {

    }

    /// <summary>
    /// 基本-客户
    /// </summary>
    public class BaseCustomer : BaseModel
    {
        
    }

    /// <summary>
    /// 基本-管理员角色
    /// </summary>
    public class BaseAdminRole : BaseModel
    {

    }

    /// <summary>
    /// 基本-管理员
    /// </summary>
    public class BaseAdmin : BaseModel
    {

    }

    /// <summary>
    /// 基本-应用角色
    /// </summary>
    public class BaseAppRole : BaseModel
    {

    }

    /// <summary>
    /// 基本-应用
    /// </summary>
    public class BaseApp : BaseModel
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseLog : BaseModel
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class BaseApiRecord : BaseModel
    {

    }

}
