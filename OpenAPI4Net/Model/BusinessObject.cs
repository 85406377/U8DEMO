namespace Yonyou.OpenApi.Model
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    #endregion

    /// <summary>
    /// Api调用返回给客户端的业务对象封装
    /// </summary>
    public class BusinessObject: ApiResponse
    {
        private static BusinessObject businessObject;
        private static IDictionary<string, object> properties = new Dictionary<string, object>();
        private ApiDictionary full;
        private string resourceId;
        private string method;

        private BusinessObject (Http.Response resp): base(resp) {}

        [JsonIgnore]
        public string ResourceId
        {
            get { return businessObject.resourceId; }
            protected set { businessObject.resourceId = value; }
        }

        [JsonIgnore]
        public string Method
        {
            get { return businessObject.method; }
        }

        /// <summary>
        /// 查询单个资源
        /// </summary>
        /// <param name="resoureId"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static BusinessObject Get(string resoureId, Http.Response resp)
        {
            ConstructBusinessObject("get", resoureId, resp);
            return businessObject;
        }

        /// <summary>
        /// 批量查询
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static BusinessObject BatchGet(string resourceId, Http.Response resp)
        {
            ConstructBusinessObject("batch_get", resourceId, resp);
            return businessObject;
        }

        /// <summary>
        /// 添加一个资源
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static BusinessObject Add(string resourceId, Http.Response resp)
        {
            ConstructBusinessObject("add", resourceId, resp);
            return businessObject;
        }

        /// <summary>
        /// 工作流：审核
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static BusinessObject Audit(string resourceId, Http.Response resp)
        {
            ConstructBusinessObject("audit", resourceId, resp);
            return businessObject;
        }

        /// <summary>
        /// 其他操作
        /// </summary>
        /// <param name="method"></param>
        /// <param name="resourceId"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static BusinessObject Do(string method, string resourceId, Http.Response resp)
        {
            ConstructBusinessObject(method, resourceId, resp);
            return businessObject;
        }

        /// <summary>
        /// 工作流：弃审
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static BusinessObject Abandon(string resourceId, Http.Response resp)
        {
            ConstructBusinessObject("abandon", resourceId, resp);
            return businessObject;
        }

        /// <summary>
        /// 工作流：审批进程
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static BusinessObject History(string resourceId, Http.Response resp)
        {
            ConstructBusinessObject("history", resourceId, resp);
            return businessObject;
        }

        /// <summary>
        /// 工作流：待办任务
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public static BusinessObject Tasks(string resourceId, Http.Response resp)
        {
            ConstructBusinessObject("tasks", resourceId, resp);
            return businessObject;
        }

        private static void ConstructBusinessObject(string method, string resourceId, Http.Response resp)
        {
            if (businessObject == null)
            {
                businessObject = new BusinessObject(resp);
            }
            string body = resp.GetResponseAsString();
            businessObject.NativeResponseString = body;
            businessObject.resourceId = resourceId;
            businessObject.full = businessObject.ParseJson(body);
            businessObject.method = method;
            if (null != businessObject.full.GetValue("errcode"))
            {
                businessObject.ErrCode = businessObject.full.GetValue("errcode").ToString();
            }

            if (businessObject.full.GetValue("errmsg") == null)
            {
                businessObject.ErrMsg = "";
            }
            else
            {
                businessObject.ErrMsg = businessObject.full.GetValue("errmsg").ToString();
            }

            if (!businessObject.IsError)
            {
                if (method.Equals("batch_get"))
                {
                    if (null != businessObject.full.GetValue("page_index"))
                    {
                        businessObject.PageIndex = Int32.Parse(businessObject.full.GetValue("page_index").ToString());
                        businessObject.PageCount = Int32.Parse(businessObject.full.GetValue("page_count").ToString());
                        businessObject.RowCount = Int32.Parse(businessObject.full.GetValue("row_count").ToString());
                        businessObject.RowsPerPage = Int32.Parse(businessObject.full.GetValue("rows_per_page").ToString());
                    }

                  
                }

                if (method.Equals("add"))
                {
                    if (businessObject.full.ContainsName("id"))
                    {
                        businessObject.Id = businessObject.full.GetValue("id").ToString();
                    }

                    if (businessObject.full.ContainsName("tradeid"))
                    {
                        businessObject.TradeId = businessObject.full.GetValue("tradeid").ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Api返回的全部信息
        /// </summary>
        [JsonIgnore]
        public ApiDictionary Full
        {
            get { return this.full; }
        }

        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        public object Body
        {
            get
            {
                return this.Full.Get(businessObject.ResourceId);
            }
        }

        /// <summary>
        /// Api返回的仅业务信息
        /// </summary>
        //[JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        [JsonIgnore]
        public ApiDictionary BodyObject
        {
            get
            {
                return this.Full.GetObject(businessObject.ResourceId);
            }
        }

        /// <summary>
        /// Api返回的仅业务信息
        /// </summary>
        [JsonIgnore]
        public ApiList BodyArray
        {
            get
            {
                return this.Full.GetArray(businessObject.ResourceId);
            }
        }

        [JsonProperty("body_array", NullValueHandling = NullValueHandling.Ignore)]
        public JArray BodyJArray
        {
            get
            {
                if (this.Full.GetArray(businessObject.ResourceId) != null)
                {
                    return this.Full.GetArray(businessObject.ResourceId).GetJArray();
                }
                return null;
            }
        }

        private ApiDictionary ParseJson(string json)
        {
            return JsonConvert.DeserializeObject<ApiDictionary>(json);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this).Replace("body_array", businessObject.ResourceId).Replace("body", businessObject.ResourceId);
        }
    }
}
