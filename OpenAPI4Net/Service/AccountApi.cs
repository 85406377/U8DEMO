
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// U8账套 API
    /// </summary>
    public class AccountApi : BasicApi
    {
        public const string RESOURCE_ID = "account";

        public AccountApi()
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
