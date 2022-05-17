
namespace Yonyou.OpenApi.Service
{ /// <summary>
    /// 考勤 API
    /// </summary>
    public class AttendanceApi : BasicApi
    {
        public const string RESOURCE_ID = "attendance";

        public AttendanceApi()
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

