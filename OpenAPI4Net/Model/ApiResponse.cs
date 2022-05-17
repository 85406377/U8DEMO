using Newtonsoft.Json;

namespace Yonyou.OpenApi.Model
{
    /// <summary>
    /// Api 返回
    /// </summary>
    public abstract class ApiResponse 
    {

        public ApiResponse(Http.Response resp) 
        {
            this.Response = resp;
        }

        [JsonIgnore]
        Http.Response Response { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty("errcode")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        /// <summary>
        /// 响应原始内容
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string HttpBodyString { get; set; }

        /// <summary>
        /// 交易号
        /// </summary>
        [JsonProperty("tradeid", NullValueHandling = NullValueHandling.Ignore)]
        public string TradeId { get; set; }

        /// <summary>
        /// 新增资源返回的id
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 批量查询(batch_get)返回的页号
        /// </summary>
        [JsonProperty("page_index", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageIndex { get; set; }

        /// <summary>
        /// 批量查询(batch_get)返回的总行数
        /// </summary>
        [JsonProperty("row_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? RowCount { get; set; }

        /// <summary>
        /// 批量查询(batch_get)返回的每页行数
        /// </summary>
        [JsonProperty("rows_per_page", NullValueHandling = NullValueHandling.Ignore)]
        public int? RowsPerPage { get; set; }

        /// <summary>
        /// 批量查询(batch_get)返回的页数
        /// </summary>
        [JsonProperty("page_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageCount { get; set; }

        /// <summary>
        /// HTTP 原生响应
        /// </summary>
        [JsonIgnore]
        public string NativeResponseString { get; set; }

        /// <summary>
        /// 响应结果是否错误
        /// </summary>
        [JsonIgnore]
        public bool IsError
        {
            get 
            {
                if (string.IsNullOrEmpty(this.ErrCode))
                    this.ErrCode = "0";
                return !this.ErrCode.Equals("0"); 
            }
        }

    }
}
