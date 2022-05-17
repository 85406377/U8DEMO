namespace Yonyou.OpenApi.Service
{
    #region Imports
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// 发货单 API
    /// </summary>
    public class ConsignmentApi : BillApi
    {
        public const string RESOURCE_ID = "consignment";

        public ConsignmentApi()
            : base(RESOURCE_ID) { }

        public new Model.BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
