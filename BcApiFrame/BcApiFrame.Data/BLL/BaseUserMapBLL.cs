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
    public partial class BaseUserMapBLL : BaseBLL<BaseUserMap>
    {
        private readonly BaseDAL<BaseUserMap> _BaseUserMapDal;
        public BaseUserMapBLL()
            : base()
        {
            _BaseUserMapDal = base.Dal;
        }

		#region 单例模式


        public static BaseUserMap Instance
        {
            get
            {
                return Singleton<BaseUserMap>.Instance;
            }
        }

        #endregion
    }
}
    