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
    public partial class BaseAppMapBLL : BaseBLL<BaseAppMap>
    {
        private readonly BaseDAL<BaseAppMap> _BaseAppMapDal;
        public BaseAppMapBLL()
            : base()
        {
            _BaseAppMapDal = base.Dal;
        }

		#region 单例模式


        public static BaseAppMap Instance
        {
            get
            {
                return Singleton<BaseAppMap>.Instance;
            }
        }

        #endregion
    }
}
    