using System;
using System.Collections.Generic;
using System.Text;

namespace Yonyou.OpenApi.Service
{ /// <summary>
    /// 工资项目 API
    /// </summary>
    public class SalaryitemApi : BasicApi
    {
        public const string RESOURCE_ID = "salaryitem";

        public SalaryitemApi()
            : base(RESOURCE_ID) { }

        public new Model.BusinessObject Add(string data, string biz_id)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Add2(string data, string tradeid)
        {
            throw new System.NotImplementedException();
        }
    }
}
