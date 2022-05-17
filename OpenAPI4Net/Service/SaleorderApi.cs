namespace Yonyou.OpenApi.Service
{
    #region Imports

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// 销售订单 API
    /// </summary>
    public class SaleorderApi : BillApi
    {
        public const string RESOURCE_ID = "saleorder";

        public SaleorderApi()
            : base(RESOURCE_ID) { }

        public new Model.BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }
      
    }
}
