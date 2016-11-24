using BcApiFrame.Util.Msg;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BcApiFrame.Web.Api
{
    /// <summary>
    /// 示例接口
    /// </summary>
    public class TestController : ApiController
    {

        /// <summary>
        /// 加法运算
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Add(int x, int y)
        {
            int sum = x + y;

            string json = string.Empty;
            json = JsonConvert.SerializeObject(new ApiMsg { status = ApiMsgStatus.success, msg = "加载数据成功!", info = new { result = sum } });

            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }

    }
}
