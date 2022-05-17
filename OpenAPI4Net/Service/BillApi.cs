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
    /// 开放平台表单类 API 基类
    /// </summary>
    public abstract class BillApi: BasicApi
    {
        public BillApi(string resourceId):base(resourceId) {}

        public BillApi(string resourceId, string fromAccount, string toAccount)
            : base(resourceId, fromAccount, toAccount) {}

        public BillApi(string resourceId, string fromAccount, string toAccount, string appKey)
            : base(resourceId, fromAccount, toAccount, appKey) { }

        public new string Url
        {
            get
            {
                if (this.Method.Equals("list"))
                {
                    return this.BaseUrl + "api/" + this.ResourceId + "/batch_get";
                }
                else
                {
                    return this.BaseUrl + "api/" + this.ResourceId + "/" + this.Method;
                }
            }
        }

        /// <summary>
        /// 单据列表查询
        /// </summary>
        /// <param name="parameters">查询参数</param>
        /// <returns></returns>
        public BusinessObject List(IDictionary<string, string> parameters)
        {
            try
            {
                this.Method = "list";
                return BusinessObject.BatchGet(this.ResourceId
                    , new Response(Client.Get(this.Url, this.CombineParameters(this.GetSystemParameters(), parameters))));
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

        /// <summary>
        /// 工作流：审核
        /// </summary>
        /// <param name="voucherCode">单据编号</param>
        /// <param name="userId">用户id</param>
        /// <param name="personCode">人员编码</param>
        /// <param name="opinion">审批意见</param>
        /// <param name="agree">是否同意</param>
        /// <returns></returns>
        public BusinessObject Audit(string voucherCode
            , string userId
            , string personCode
            , string opinion
            , bool agree)
        {
            try
            {
                this.Method = "audit";
                string data = String.Format("{{\"{5}\":{{\"voucher_code\":\"{0}\",\"user_id\":\"{1}\",\"person_code\":\"{2}\",\"opinion\":\"{3}\",\"agree\":\"{4}\"}}}}"
                    , voucherCode
                    , userId
                    , personCode
                    , opinion
                    , agree ? "1" : "0"
                    , this.ResourceId);
                    
                BusinessObject bo = BusinessObject.Audit(this.ResourceId, new Response(Client.Post(this.Url, this.GetSystemParameters(), data)));
                return bo;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

        
        /// <summary>
        /// 工作流：弃审
        /// </summary>
        /// <param name="voucherCode">单据编号</param>
        /// <param name="userId">用户id</param>
        /// <param name="personCode">人员编码</param>
        /// <param name="opinion">审批意见</param>
        /// <returns></returns>
        public BusinessObject Abandon(string voucherCode
            , string userId
            , string personCode
            , string opinion)
        {
            try
            {
                this.Method = "abandon";
                string data = String.Format("{{\"{4}\":{{\"voucher_code\":\"{0}\",\"user_id\":\"{1}\",\"person_code\":\"{2}\",\"opinion\":\"{3}\"}}}}"
                , voucherCode
                , userId
                , personCode
                , opinion
                , this.ResourceId);
                    
                BusinessObject bo = BusinessObject.Abandon(this.ResourceId, new Response(Client.Post(this.Url, this.GetSystemParameters(), data)));
                return bo;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

        /// <summary>
        /// 审批进程
        /// </summary>
        /// <param name="voucherCode">单据编号</param>
        /// <param name="userId">用户id</param>
        /// <param name="personCode">人员编码</param>
        /// <returns></returns>
        public BusinessObject History(string voucherCode
            , string userId
            , string personCode)
        {
            try
            {
                this.Method = "history";
                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("person_code", personCode);
                parameters.Add("user_id", userId);
                parameters.Add("voucher_code", voucherCode);

                return BusinessObject.BatchGet(this.ResourceId
                    , new Response(Client.Get(this.Url, this.CombineParameters(this.GetSystemParameters(), parameters))));
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

        /// <summary>
        /// 待办任务
        /// </summary>
        /// <param name="parameters">查询参数</param>
        /// <returns></returns>
        public BusinessObject Tasks(string personCode
            , int? state
            , string taskDesc)
        {
            try
            {
                this.Method = "tasks";
                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("person_code", personCode);
                if (state != null)
                {
                    parameters.Add("state", state.ToString());
                }
                parameters.Add("task_desc", taskDesc);

                return BusinessObject.BatchGet(this.ResourceId
                    , new Response(Client.Get(this.Url, this.CombineParameters(this.GetSystemParameters(), parameters))));
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

    }
}
