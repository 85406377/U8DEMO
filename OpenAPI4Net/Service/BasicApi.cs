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
    public abstract class BasicApi: Api
    {
        public BasicApi(string resourceId)
            : base(resourceId) { }

        public BasicApi(string resourceId, string fromAccount, string toAccount)
            : base(resourceId, fromAccount, toAccount) { }

        public BasicApi(string resourceId, string fromAccount, string toAccount, string appKey)
            : base(resourceId, fromAccount, toAccount, appKey) { }

        /// <summary>
        /// 获取单个资源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessObject Get(string id)
        {
            try
            {
                this.Method = "get";
                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("id", id);
                return BusinessObject.Get(this.ResourceId
                    , new Response(Client.Get(this.Url, this.CombineParameters(this.GetSystemParameters(), parameters))));
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

        /// <summary>
        /// 批量查询
        /// </summary>
        /// <param name="parameters">查询参数</param>
        /// <returns></returns>
        public BusinessObject BatchGet(IDictionary<string, string> parameters)
        {
            try
            {
                this.Method = "batch_get";
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
        /// 有上游业务的新增，比如网上报销单生成凭证。
        /// </summary>
        /// <param name="data">凭证数据</param>
        /// <param name="biz_id">上游主键</param>
        /// <returns></returns>
        public BusinessObject Add(string data, string biz_id)
        {
            try
            {
                this.Method = "add";
                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("biz_id", biz_id);
                BusinessObject bo = BusinessObject.Add(this.ResourceId, new Response(Client.Post(this.Url, this.CombineParameters(this.GetSystemParameters(), parameters), data)));
                if (bo.IsError)
                {
                    return bo;
                }
                
                if (bo.Full.ContainsName("url"))
                {
                    int pingAfter = int.Parse(bo.Full.GetValue("ping_after").ToString());
                    int counter = 0;
                    String url = bo.Full.GetValue("url").ToString();
                    bool success = false;

                    // 同步获取新增结果，重试 MAX_TIMES_TRADEID_RETRY 次
                    while (counter < MAX_TIMES_TRADEID_RETRY && !success)
                    {
                        counter++;
                        System.Threading.Thread.Sleep(1000 * pingAfter);
                        bo = BusinessObject.Add(this.ResourceId, new Response(Client.Get(url, null)));
                        success = !bo.Full.ContainsName("url");
                    }
                }
                return bo;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

        /// <summary>
        /// 无上游关系的新增
        /// </summary>
        /// <param name="data">凭证数据</param>
        /// <param name="tradeid">交易号</param>
        /// <returns></returns>
        public BusinessObject Add2(string data, string tradeid)
        {
            try
            {
                this.Method = "add";
                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("tradeid", tradeid);
                BusinessObject bo = BusinessObject.Add(this.ResourceId, new Response(Client.Post(this.Url, this.CombineParameters(this.GetSystemParameters(), parameters), data)));
                if (bo.IsError)
                {
                    return bo;
                }

                if (bo.Full.ContainsName("url"))
                {
                    int pingAfter = int.Parse(bo.Full.GetValue("ping_after").ToString());
                    int counter = 0;
                    String url = bo.Full.GetValue("url").ToString();
                    bool success = false;

                    while (counter < MAX_TIMES_TRADEID_RETRY && !success)
                    {
                        counter++;
                        System.Threading.Thread.Sleep(1000 * pingAfter);
                        bo = BusinessObject.Add(this.ResourceId, new Response(Client.Get(url, null)));
                        success = !bo.Full.ContainsName("url");
                    }
                }
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
