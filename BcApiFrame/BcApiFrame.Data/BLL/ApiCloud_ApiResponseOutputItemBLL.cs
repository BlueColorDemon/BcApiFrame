using BC.AppCloud.DAL;
using BC.AppCloud.Entity.ApiCloud;
using BcApiFrame.Util.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.AppCloud.BLL.ApiCloud
{
    public partial class ApiCloud_ApiResponseOutputItemBLL : BaseBLL<ApiCloud_ApiResponseOutputItem>
    {
        private readonly BaseDAL<ApiCloud_ApiResponseOutputItem> _ApiCloud_ApiResponseOutputItemDal;
        public ApiCloud_ApiResponseOutputItemBLL()
            : base()
        {
            _ApiCloud_ApiResponseOutputItemDal = base.Dal;
        }

		#region 单例模式


        public static ApiCloud_ApiResponseOutputItem Instance
        {
            get
            {
                return Singleton<ApiCloud_ApiResponseOutputItem>.Instance;
            }
        }

        #endregion
    }
}
    