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
    public partial class BaseLogMapBLL : BaseBLL<BaseLogMap>
    {
        private readonly BaseDAL<BaseLogMap> _BaseLogMapDal;
        public BaseLogMapBLL()
            : base()
        {
            _BaseLogMapDal = base.Dal;
        }

		#region 单例模式


        public static BaseLogMap Instance
        {
            get
            {
                return Singleton<BaseLogMap>.Instance;
            }
        }

        #endregion
    }
}
    