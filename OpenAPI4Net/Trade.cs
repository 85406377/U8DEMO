namespace Yonyou.OpenApi
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
    public class Trade
    {
        private static readonly string ERR_MSG_SDK_RUNTIME_ERROR = "OpenAPI-SDK Runtime Error.";
        private static Log _logger = new Log();

        private IDictionary<string, string> systemParameters = new Dictionary<string, string>();

        private string appKey;
        private string fromAccount;
        private string baseUrl;

        public static Http.WebUtils Client = new Http.WebUtils();

        public Trade()
        {
            try
            {
                this.LoadConfig();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

        public Trade(string fromAccount, string appKey, string appSecret)
            : this()
        {
            this.fromAccount = fromAccount;
            this.appKey = appKey;
        }

        private void LoadConfig()
        {
            this.appKey = Config.GetInstance().AppKey;
            this.fromAccount = Config.GetInstance().FromAccount;
            this.baseUrl = Config.GetInstance().BaseUrl;
        }

        private IDictionary<string, string> GetSystemParameters()
        {
            if (this.systemParameters.Count == 0)
            {
                this.systemParameters.Add("app_key", this.appKey);
                this.systemParameters.Add("token", TokenManager.GetToken());

                if (!String.IsNullOrEmpty(this.fromAccount))
                    this.systemParameters.Add("from_account", this.fromAccount);

            }
            return this.systemParameters;
        }

        private string Url
        {
            get { return this.baseUrl + "system/" + this.ResourceId; }
        }

        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceId
        {
            get { return "tradeid"; }
        }

        public BusinessObject Get()
        {
            try
            {
                return BusinessObject.Get(this.ResourceId, new Response(Client.Get(this.Url, this.GetSystemParameters())));
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }
    }
}
