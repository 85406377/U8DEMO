namespace Yonyou.OpenApi.Service
{
    #region imports

    using Yonyou.OpenApi.Model;
    using System.Collections.Generic;
    using Yonyou.OpenApi.Http;
    using System;
    using Yonyou.OpenApi.Util;

    #endregion

    /// <summary>
    /// 开放平台 API 基类
    /// </summary>
    public class UserApi: Api
    {
        public const string RESOURCE_ID = "user";

        public UserApi()
            : base(RESOURCE_ID) { }

        public UserApi(string fromAccount, string toAccount)
            : base(RESOURCE_ID, fromAccount, toAccount) { }

        public UserApi(string fromAccount, string toAccount, string appKey)
            : base(RESOURCE_ID, fromAccount, toAccount, appKey) { }

        /// <summary>
        /// 工作流：审核
        /// </summary>
        /// <param name="voucherCode">单据编号</param>
        /// <param name="userId">用户id</param>
        /// <param name="personCode">人员编码</param>
        /// <param name="opinion">审批意见</param>
        /// <param name="agree">是否同意</param>
        /// <returns></returns>
        public BusinessObject Login(string userId
            , string password)
        {
            try
            {
                
                string data = String.Format("{{\"user\":{{\"user_id\":\"{0}\",\"password\":\"{1}\"}}}}"
                    , userId
                    , password);

                this.Method = "login";
                BusinessObject bo = BusinessObject.Do(this.Method, this.ResourceId, new Response(Client.Post(this.Url, this.GetSystemParameters(), data)));
                return bo;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }
    }
}
