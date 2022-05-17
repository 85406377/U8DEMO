
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 商业盈利状况评价 API
    /// </summary>
    public class ProductprofitabilityApi : BasicApi
    {
        public const string RESOURCE_ID = "productprofitability";

        public ProductprofitabilityApi()
            : base(RESOURCE_ID) { }


        public new Model.BusinessObject Get(string id)
        {
            throw new System.NotImplementedException();
        }
   
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
