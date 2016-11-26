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
    public partial class BaseApiRecordBLL : BaseBLL<BaseApiRecord>
    {
        private readonly BaseDAL<BaseApiRecord> _BaseApiRecordDal;
        public BaseApiRecordBLL()
            : base()
        {
            _BaseApiRecordDal = base.Dal;
        }

		#region 单例模式


        public static BaseApiRecordBLL Instance
        {
            get
            {
                return Singleton<BaseApiRecordBLL>.Instance;
            }
        }

        #endregion
    }
}
    