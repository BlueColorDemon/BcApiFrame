using BcApiFrame.Data.DAL;
using BcApiFrame.Data.Entity.ApiBase;
using BcApiFrame.Util.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcApiFrame.Data.BLL.ApiBase
{
    public partial class BaseAppBLL : BaseBLL<BaseApp>
    {
        private readonly BaseDAL<BaseApp> _BaseAppDal;
        public BaseAppBLL()
            : base()
        {
            _BaseAppDal = base.Dal;
        }

		#region 单例模式


        public static BaseAppBLL Instance
        {
            get
            {
                return Singleton<BaseAppBLL>.Instance;
            }
        }

        #endregion
    }
}
    