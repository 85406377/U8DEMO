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
    public abstract class Api
    {
        protected static readonly string ERR_MSG_SDK_RUNTIME_ERROR = "OpenAPI-SDK Runtime Error.";
        protected const int MAX_TIMES_TRADEID_RETRY = 20;
        protected static Log _logger = new Log();
        private IDictionary<string, string> systemParameters = new Dictionary<string, string>();

        private string resourceId;
        private string appKey;
        private string fromAccount;
        private string toAccount;
        private string baseUrl;
        private string method;

        public static Http.WebUtils Client = new Http.WebUtils();

        public Api(string resourceId)
        {
            try
            {
                this.resourceId = resourceId;
                this.LoadConfig();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new ApiException(ERR_MSG_SDK_RUNTIME_ERROR, e);
            }
        }

        public Api(string resourceId, string fromAccount, string toAccount)
            : this(resourceId)
        {
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
        }

        public Api(string resourceId, string fromAccount, string toAccount, string appKey)
            : this(resourceId, fromAccount, toAccount)
        {
            this.appKey = appKey;
        }

        public IDictionary<string, string> SystemParameters { get { return this.systemParameters; } }

        protected IDictionary<string, string> GetSystemParameters()
        {
            if (this.systemParameters.Count == 0)
            {
                this.systemParameters.Add("app_key", this.AppKey);

                if (!String.IsNullOrEmpty(this.FromAccount))
                    this.systemParameters.Add("from_account", this.FromAccount);

                if (!String.IsNullOrEmpty(this.ToAccount))
                    this.systemParameters.Add("to_account", this.ToAccount);
            }
            if (this.systemParameters.ContainsKey("token"))
            {
                this.systemParameters["token"] = TokenManager.GetToken();
            }
            else
            {
                this.systemParameters.Add("token", TokenManager.GetToken());
            }
            return this.systemParameters;
        }

        protected IDictionary<string, string> CombineParameters(IDictionary<string, string> systemParameters,
            IDictionary<string, string> apiParameters)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> entry in systemParameters)
            {
                parameters.Add(entry);
            }
            if (apiParameters != null)
            {
                foreach (KeyValuePair<string, string> entry in apiParameters)
                {
                    parameters.Add(entry);
                }
            }
            return parameters;
        }

        private void LoadConfig()
        {
            this.appKey = Config.GetInstance().AppKey;
            this.fromAccount = Config.GetInstance().FromAccount;
            this.toAccount = Config.GetInstance().ToAccount;
            this.baseUrl = Config.GetInstance().BaseUrl;
        }

        public string AppKey
        {
            get { return appKey; }
        }

        public string ToAccount
        {
            get { return toAccount; }
        }

        public string FromAccount
        {
            get { return fromAccount; }
        }

        public string Method 
        {
            get
            {
                return method;
            }
            protected set
            {
                method = value;
            }
        }

        protected string BaseUrl { get { return this.baseUrl; } }

        public string Url
        {
            get
            {
                if (this.Method.Equals("list"))
                {
                    return this.baseUrl + "api/" + this.resourceId + "/batch_get";
                }
                else
                {
                    return this.baseUrl + "api/" + this.resourceId + "/" + this.method;
                }
            }
        }

        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceId
        {
            get
            {
                if (this.Method.Equals("list"))
                {
                    return this.resourceId + "list";
                }
                else
                {
                    return this.resourceId;
                }
            }
            protected set
            {
                this.resourceId = value;
            }
        }
    }
}
