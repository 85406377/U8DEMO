
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 部门 API
    /// </summary>
    public class DepartmentApi: BasicApi
    {
        public const string RESOURCE_ID = "department";

        public DepartmentApi()
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
