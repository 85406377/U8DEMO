
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 供应商类别 API
    /// </summary>
    public class VendorclassApi : BasicApi
    {
        public const string RESOURCE_ID = "vendorclass";

        public VendorclassApi()
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
