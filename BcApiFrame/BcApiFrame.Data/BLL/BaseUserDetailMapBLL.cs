using BcApiFrame.Data.DAL;
using BcApiFrame.Data.Entity.ApiBase;
using BcApiFrame.Util.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcApiFrame.Data.BLL.ApiCloud
{
    public partial class BaseUserDetailMapBLL : BaseBLL<BaseUserDetailMap>
    {
        private readonly BaseDAL<BaseUserDetailMap> _BaseUserDetailMapDal;
        public BaseUserDetailMapBLL()
            : base()
        {
            _BaseUserDetailMapDal = base.Dal;
        }

		#region 单例模式


        public static BaseUserDetailMap Instance
        {
            get
            {
                return Singleton<BaseUserDetailMap>.Instance;
            }
        }

        #endregion
    }
}
    