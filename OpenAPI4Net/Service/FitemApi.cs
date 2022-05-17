
namespace Yonyou.OpenApi.Service
{
    /// <summary>
    /// 项目 API
    /// </summary>
   public  class FitemApi : BasicApi
    {
       public const string RESOURCE_ID = "fitem";

       public FitemApi()
           : base(RESOURCE_ID){ }

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
