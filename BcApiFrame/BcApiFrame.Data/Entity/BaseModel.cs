using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BC.AppCloud.Entity
{
    /// <summary>
    /// 基本模型
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 跟新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 数据状态
        /// </summary>
        public int State { get; set; }
    }

    /// <summary>
    /// 基本模型状态
    /// </summary>
    public enum BaseModelState
    {
        /// <summary>
        /// 默认
        /// </summary>
        Default = 0,
        /// <summary>
        /// 已删除
        /// </summary>
        Deleted = 1
    }
}