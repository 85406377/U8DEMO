
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 现存量 API
    /// </summary>
    public class CurrentstockApi : BasicApi
    {
        public const string RESOURCE_ID = "currentstock";

        public CurrentstockApi()
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