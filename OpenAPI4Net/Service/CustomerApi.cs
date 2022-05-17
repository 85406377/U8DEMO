using System;
using System.Collections.Generic;
using System.Text;

namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 客户 API
    /// </summary>
    public class CustomerApi : BasicApi
    {
        public const string RESOURCE_ID = "customer";

        public CustomerApi()
            : base(RESOURCE_ID) { }
    }
}
