namespace OpenAPI4Net.Examples
{
    #region Imports
    using System;
    using Yonyou.OpenApi;
    using Yonyou.OpenApi.Service;
    using Yonyou.OpenApi.Model;
    using System.Collections.Generic;
    #endregion
    /// <summary>
    /// 账套
    /// </summary>
    public class Account
    {
        private static Log _logger = new Log();
        private const string SOURCE = ""; //"OpenAPI4Net.Examples.Account";

        /// <summary>
        ///  测试
        /// </summary>
        /// <remarks>
        /// 所有返回的业务对象 .ToString() 返回 json 字符串；
        /// 
        /// 返回的业务对象可以通过 BodyObject 属性检索数据；(ApiDictionary 字典) 
        ///      示例：
        ///          {
        ///              "inventory":
        ///              { 
        ///                  "code": "01", 
        ///                  "name": "PC"
        ///              }
        ///          }
        ///          BusinessObject.BodyObject["code"]               -> "01"
        ///          BusinessObject.BodyObject.GetValue("code")      -> "01"
        ///      
        /// 若遇到 json 数组，请通过 BodyArray 属性检索数据；(ApiList 列表）
        ///      示例：
        ///          {
        ///              "inventory":
        ///              { 
        ///                  "code": "01", 
        ///                  "entry":[
        ///                  {
        ///                      "free1": "红色"
        ///                  },
        ///                  {
        ///                      "free1": "蓝色"
        ///                  }]
        ///              }
        ///          }
        ///          BusinessObject.BodyArray.GetObject(1).GetValue("free1")      -> "蓝色"
        /// </remarks>
        public static void Test()
        {
            try
            {
                AccountApi api = new AccountApi();

                #region 获取单个资源
                _logger.Info("**** get ****");

                BusinessObject bo = api.Get("999");
                _logger.Debug(SOURCE, String.Format("resource_id:{0}", bo.ResourceId));
                _logger.Debug(SOURCE, String.Format("IsError:{0}", bo.IsError));
                _logger.Debug(SOURCE, String.Format("errmsg:{0}", bo.ErrMsg));

                _logger.Info(" 原生结果");
                _logger.Debug(SOURCE, bo.NativeResponseString);

                _logger.Info(" 业务数据");
                if (bo.BodyObject != null)
                    _logger.Debug(SOURCE, bo.BodyObject.ToString());

                _logger.Info(" 业务数据.编码");
                if (bo.BodyObject != null && (bo.BodyObject["code"] != null))
                {
                    _logger.Debug(SOURCE, bo.BodyObject["code"].ToString());
                    _logger.Debug(SOURCE, bo.BodyObject.GetValue("code").ToString());
                }
                #endregion

                #region 批量获取资源
                _logger.Info("**** batch_get ****");

                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("code_begin", "100");
                parameters.Add("code_end", "999");
                bo = api.BatchGet(parameters);

                _logger.Debug(SOURCE, String.Format("IsError:{0}", bo.IsError));
                _logger.Debug(SOURCE, String.Format("errmsg:{0}", bo.ErrMsg));

                _logger.Info(" 原生结果");
                _logger.Debug(SOURCE, bo.NativeResponseString);

                _logger.Info(" 提取第1行");
                if (bo.BodyArray != null && bo.BodyArray.GetObject(0) != null)
                    _logger.Info(bo.BodyArray.GetObject(0).ToString());

                _logger.Info(" 提取第1行.code");
                if (bo.BodyArray != null
                    && bo.BodyArray.GetObject(0) != null
                    && bo.BodyArray.GetObject(0).GetValue("code") != null)
                    _logger.Info(bo.BodyArray.GetObject(0).GetValue("code").ToString());
                #endregion

                #region 新增
                //不支持
                //bo = api.Add(null, null);
                #endregion
            }
            catch (Exception e)
            {
                _logger.Info(e.StackTrace);
            }
            finally
            {
                _logger.Info("\r\n#### END ####\r\n\r\n");
            }
        }
    }
}
