namespace Yonyou.OpenApi.Service
{
    #region Imports
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// 采购订单 API
    /// </summary>
    public class PurchaseorderApi : BillApi
    {
        public const string RESOURCE_ID = "Purchaseorder";

        public PurchaseorderApi()
            : base(RESOURCE_ID) { }

        public new Model.BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
