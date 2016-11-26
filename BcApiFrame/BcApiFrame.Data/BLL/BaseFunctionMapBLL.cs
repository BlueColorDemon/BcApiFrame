

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
    public partial class BaseFunctionMapBLL : BaseBLL<BaseFunctionMap>
    {
        private readonly BaseDAL<BaseFunctionMap> _BaseFunctionMapDal;
        public BaseFunctionMapBLL()
            : base()
        {
            _BaseFunctionMapDal = base.Dal;
        }

		#region 单例模式


        public static BaseFunctionMap Instance
        {
            get
            {
                return Singleton<BaseFunctionMap>.Instance;
            }
        }

        #endregion
    }
}
    