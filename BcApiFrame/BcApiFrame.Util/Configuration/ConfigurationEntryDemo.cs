using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace BcApiFrame.Util.Configuration
{
    using System.Web.Hosting;

    public class ConfigurationEntryDemoTest
    {
        public string GetDefaultLanguage()
        {
            return ConfigurationEntryDemo.Current.DefaultLanguage;
        }
    }

    /// <summary>
    /// 配置文件模式 泛型-测试
    /// </summary>
    [XmlRootAttribute(ElementName = "Configuration", IsNullable = false)]
    public class ConfigurationEntryDemo : ConfigurationEntry<ConfigurationEntryDemo>
    {
        /// <summary>
        /// 默认语言
        /// </summary>
        public string DefaultLanguage { get; set; }

        /// <summary>
        /// 站点-标题
        /// </summary>
        public string SiteTitle { get; set; }

        /// <summary>
        /// 站点-版权信息
        /// </summary>
        public string SiteFooterMessage { get; set; }

        public bool HasSiteFooterMessage
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.SiteFooterMessage);
            }
        }

        public string GetSiteTitle()
        {
            return !string.IsNullOrWhiteSpace(this.SiteTitle)
                ? this.SiteTitle
                : "Resources.ResourceTest.Layout_Title";
        }

    }
}