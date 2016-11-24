using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcApiFrame.Util.Msg
{
    /// <summary>
    /// Api消息结果
    /// 规约：全部使用单驼峰命名法（json 输出）
    /// </summary>
    public class ApiMsg
    {
        /// <summary>
        /// 状态
        /// </summary>
        public ApiMsgStatus status { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public object info { get; set; }
    }

    /// <summary>
    /// ApiMsg状态 枚举
    /// </summary>
    public enum ApiMsgStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        success = 1,
        /// <summary>
        /// 错误
        /// </summary>
        error = 0,
    }


}
