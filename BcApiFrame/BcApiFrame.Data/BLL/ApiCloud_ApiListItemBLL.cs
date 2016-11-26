using BcApiFrame.Data.DAL;
using BcApiFrame.Data.Entity.ApiCloud;
using BcApiFrame.Util.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcApiFrame.Data.BLL.ApiCloud
{
    public partial class ApiCloud_ApiListItemBLL : BaseBLL<ApiCloud_ApiListItem>
    {
        private readonly BaseDAL<ApiCloud_ApiListItem> _ApiCloud_ApiListItemDal;
        public ApiCloud_ApiListItemBLL()
            : base()
        {
            _ApiCloud_ApiListItemDal = base.Dal;
        }

		#region 单例模式


        public static ApiCloud_ApiListItem Instance
        {
            get
            {
                return Singleton<ApiCloud_ApiListItem>.Instance;
            }
        }

        #endregion
    }
}
    