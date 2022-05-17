
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 计量单位 API
    /// </summary>
    public class UnitApi : BasicApi
    {
        public const string RESOURCE_ID = "unit";

        public UnitApi() : base(RESOURCE_ID) { }


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