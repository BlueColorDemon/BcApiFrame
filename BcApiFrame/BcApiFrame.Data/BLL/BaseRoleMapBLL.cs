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
    public partial class BaseRoleMapBLL : BaseBLL<BaseRoleMap>
    {
        private readonly BaseDAL<BaseRoleMap> _BaseRoleMapDal;
        public BaseRoleMapBLL()
            : base()
        {
            _BaseRoleMapDal = base.Dal;
        }

		#region 单例模式


        public static BaseRoleMap Instance
        {
            get
            {
                return Singleton<BaseRoleMap>.Instance;
            }
        }

        #endregion
    }
}
    