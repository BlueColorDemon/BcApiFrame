using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace BcApiFrame.Util.Configuration
{
    /// <summary>
    /// 配置文件模式 泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ConfigurationEntry<T> where T : ConfigurationEntry<T>, new()
    {
        /// <summary>
        /// 配置文件对象
        /// </summary>
        private static T _current = null;

        /// <summary>
        /// 同步安全锁
        /// </summary>
        private static readonly object _sync = new object();

        /// <summary>
        /// 配置文件-序列化器
        /// </summary>
        private static readonly XmlSerializer _serializer = new XmlSerializer(typeof(T));

        /// <summary>
        /// 配置文件-路径
        /// 强制设置
        /// 为ConfigurationManager.AppSettings[typeof(T).Name]对应Value(路径)。
        /// </summary>
        private static readonly string _configPath = Path.IsPathRooted(ConfigurationManager.AppSettings[typeof(T).Name])
                                                    ? ConfigurationManager.AppSettings[typeof(T).Name]
                                                    : HostingEnvironment.MapPath(ConfigurationManager.AppSettings[typeof(T).Name]);



        /// <summary>
        /// 当前配置文件对象
        /// 为 null 时,自动加载
        /// </summary>
        public static T Current { get { return _current ?? Load(); } }

        /// <summary>
        /// 加载-配置文件
        /// </summary>
        /// <returns></returns>
        private static T Load()
        {
            lock (_sync)
            {
                if (_current == null)
                {
                    try
                    {
                        using (var stream = File.Open(_configPath, FileMode.Open))
                        {
                            _current = _serializer.Deserialize(stream) as T;
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        _current = new T();
                    }
                }
            }

            return _current;
        }

        /// <summary>
        /// 保存-配置文件
        /// </summary>
        public void Save()
        {
            lock (_sync)
            {
                if (_current != null)
                {
                    using (var stream = File.Open(_configPath, FileMode.Create))
                    {
                        _serializer.Serialize(stream, _current);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化-配置文件(测试使用)
        /// </summary>
        public static void InitialiseForTest()
        {
            _current = new T();
        }



    }
}