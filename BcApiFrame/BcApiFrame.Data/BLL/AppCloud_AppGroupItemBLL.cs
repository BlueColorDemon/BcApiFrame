using BcApiFrame.Data.DAL;
using BcApiFrame.Data.Entity.AppCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BcApiFrame.Data.BLL.AppCloud
{
    public partial class AppCloud_AppGroupItemBLL : BaseBLL<AppCloud_AppGroupItem>
    {
        private readonly BaseDAL<AppCloud_AppGroupItem> _AppCloud_AppGroupItemDal;
        public AppCloud_AppGroupItemBLL()
            : base()
        {
            _AppCloud_AppGroupItemDal = base.Dal;
        }
    }
}
    