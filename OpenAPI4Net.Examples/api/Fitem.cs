namespace OpenAPI4Net.Examples
{
    #region Imports
    using System;
    using Yonyou.OpenApi.Service;
    using Yonyou.OpenApi.Model;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// 项目
    /// </summary>
    public class Fitem
    {
        private static Log _logger = new Log();
        private const string SOURCE = ""; //"OpenAPI4Net.Examples.Fitem";

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
                FitemApi api = new FitemApi();
               
                #region 获取单个项目
                //不支持
                //BusinessObject bo = api.Get(null);
                #endregion

                #region 批量获取资源
                _logger.Info("**** batch_get ****");

                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("code_begin", "01");
                parameters.Add("code_end", "10");
                BusinessObject bo = api.BatchGet(parameters);

                _logger.Debug(SOURCE, String.Format("IsError:{0}", bo.IsError));
                _logger.Debug(SOURCE, String.Format("errmsg:{0}", bo.ErrMsg));

                _logger.Info(" 原生结果");
                _logger.Debug(SOURCE, bo.NativeResponseString);

                _logger.Info(" 提取第1行");
                if (bo.BodyArray != null && bo.BodyArray.GetObject(0) != null)
                    _logger.Info(bo.BodyArray.GetObject(0).ToString());

                _logger.Info(" 提取第1行.citemcode");
                if (bo.BodyArray != null
                    && bo.BodyArray.GetObject(0) != null
                    && bo.BodyArray.GetObject(0).GetValue("citemcode") != null)
                    _logger.Info(bo.BodyArray.GetObject(0).GetValue("citemcode").ToString());

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
