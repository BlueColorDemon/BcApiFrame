using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BcApiFrame.Util.RootPath
{
    public class RootPath
    {
        /// <summary>
        /// 获取网站根目录
        /// </summary>
        /// <param name="path">相对路径</param>
        /// <returns></returns>
        public static string GetRootPath(string path)
        {
            return Path.IsPathRooted(path)
                ? path
                : HttpContext.Current.Server.MapPath(path);
        }

        /// <summary>
        /// 获取网站Bin目录
        /// </summary>
        /// <param name="path">相对路径</param>
        /// <returns></returns>
        public static string GetBinDirectory(string path)
        {
            return Path.IsPathRooted(path)
                ? path
                : Path.Combine(HttpRuntime.BinDirectory, path);
        }
    }
}
