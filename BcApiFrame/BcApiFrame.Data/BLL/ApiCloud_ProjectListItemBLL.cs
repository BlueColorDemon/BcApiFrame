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
    public partial class ApiCloud_ProjectListItemBLL : BaseBLL<ApiCloud_ProjectListItem>
    {
        private readonly BaseDAL<ApiCloud_ProjectListItem> _ApiCloud_ProjectListItemDal;
        public ApiCloud_ProjectListItemBLL()
            : base()
        {
            _ApiCloud_ProjectListItemDal = base.Dal;
        }

		#region 单例模式


        public static ApiCloud_ProjectListItem Instance
        {
            get
            {
                return Singleton<ApiCloud_ProjectListItem>.Instance;
            }
        }

        #endregion
    }
}
    