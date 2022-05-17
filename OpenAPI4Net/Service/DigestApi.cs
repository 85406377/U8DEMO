
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 常用摘要 API
    /// </summary>
    public class DigestApi : BasicApi
    {
        public const string RESOURCE_ID = "digest";

        public DigestApi()
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

