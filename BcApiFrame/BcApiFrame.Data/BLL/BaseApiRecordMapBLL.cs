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
    public partial class BaseApiRecordMapBLL : BaseBLL<BaseApiRecordMap>
    {
        private readonly BaseDAL<BaseApiRecordMap> _BaseApiRecordMapDal;
        public BaseApiRecordMapBLL()
            : base()
        {
            _BaseApiRecordMapDal = base.Dal;
        }

		#region 单例模式


        public static BaseApiRecordMap Instance
        {
            get
            {
                return Singleton<BaseApiRecordMap>.Instance;
            }
        }

        #endregion
    }
}
    