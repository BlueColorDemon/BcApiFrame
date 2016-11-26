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
    public partial class BaseRoleBLL : BaseBLL<BaseRole>
    {
        private readonly BaseDAL<BaseRole> _BaseRoleDal;
        public BaseRoleBLL()
            : base()
        {
            _BaseRoleDal = base.Dal;
        }

		#region 单例模式


        public static BaseRoleBLL Instance
        {
            get
            {
                return Singleton<BaseRoleBLL>.Instance;
            }
        }

        #endregion
    }
}
    