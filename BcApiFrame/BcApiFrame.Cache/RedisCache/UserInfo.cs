using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BcApiFrame.Cache.RedisCache
{
    [Serializable]
    public class UserInfo
    {
        public int Id;
        public string UserName;
        public int Age;
    }
}
