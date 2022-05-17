
namespace Yonyou.OpenApi.Service
{
    #region Imports

    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// 应收单 API
    /// </summary>
    public class OughtreceiveApi : BillApi
    {
        public const string RESOURCE_ID = "oughtreceive";

        public OughtreceiveApi()
            : base(RESOURCE_ID) { }


        public new Model.BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Audit(string voucherCode
            , string userId
            , string personCode
            , string opinion
            , bool agree)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Abandon(string voucherCode
            , string userId
            , string personCode
            , string opinion)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject History(string voucherCode
            , string userId
            , string personCode)
        {
            throw new System.NotImplementedException();
        }

        public new Model.BusinessObject Tasks(string personCode
            , int? state
            , string taskDesc)
        {
            throw new System.NotImplementedException();
        }
       
    }
}

