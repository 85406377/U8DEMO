
namespace Yonyou.OpenApi.Service
{ 
    /// <summary>
    /// 交易单位 API
    /// </summary>
    public class PayunitclassApi : BasicApi
    {
        public const string RESOURCE_ID = "payunitclass";

        public PayunitclassApi()
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
