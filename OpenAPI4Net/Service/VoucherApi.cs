
namespace Yonyou.OpenApi.Service
{
    #region Imports

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// 凭证 API
    /// </summary>
    public class VoucherApi : BasicApi
    {
        public const string RESOURCE_ID = "voucher";

        public VoucherApi()
            : base(RESOURCE_ID) { }


        public new Model.BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Get(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
