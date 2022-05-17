
namespace Yonyou.OpenApi.Service
{ 
    /// <summary>
    /// 自由项 API
    /// </summary>
    public class FreearchApi : BasicApi
    {
        public const string RESOURCE_ID = "freearch";

        public FreearchApi()
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
