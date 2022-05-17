namespace OpenAPI4Net.Examples
{
    #region Imports
    using System;
    using Yonyou.OpenApi.Service;
    using Yonyou.OpenApi.Model;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// 其他出库单
    /// </summary>
    public class Otherout
    {
        private static Log _logger = new Log();
        private const string SOURCE = ""; //"OpenAPI4Net.Examples.Otherout";

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
                OtheroutApi api = new OtheroutApi();

                #region 获取单个资源
                _logger.Info("**** get ****");
                BusinessObject bo = api.Get("0000000008");
                _logger.Debug(SOURCE, String.Format("resource_id:{0}", bo.ResourceId));

                _logger.Info(" 原生结果");
                _logger.Debug(SOURCE, bo.NativeResponseString);
                _logger.Debug(SOURCE, String.Format("IsError:{0}", bo.IsError));
                _logger.Debug(SOURCE, String.Format("errmsg:{0}", bo.ErrMsg));

                _logger.Info(" 业务数据");
                if (bo.BodyObject != null)
                    _logger.Debug(SOURCE, bo.BodyObject.ToString());

                _logger.Info(" 业务数据.订单号");
                if (bo.BodyObject != null && (bo.BodyObject["code"] != null))
                {
                    _logger.Debug(SOURCE, bo.BodyObject["code"].ToString());
                    _logger.Debug(SOURCE, bo.BodyObject.GetValue("code").ToString());
                }
                #endregion

                #region 批量获取资源
                //不支持批量查询
                //bo = api.BatchGet(null);
                #endregion

                #region 获取列表
                _logger.Info("**** list ****");

                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("warehousecode", "42");
                bo = api.List(parameters);

                _logger.Info(" 原生结果");
                _logger.Debug(SOURCE, bo.NativeResponseString);
                #endregion

                #region 新增
                _logger.Info("**** add ****");

                // 场景1：有上游业务
                string biz_id = "0008";//上游id
                String body = "{\"otherout\":{\"header\":{\"warehousecode\":\"42\"},\"entry\":[{\"inventorycode\":\"1001\",\"quantity\":\"2\",\"assitantunit\":\"0502\",\"irate\":\"50\",\"number\":\"0.04\"},{\"inventorycode\":\"1002\",\"quantity\":\"3\",\"assitantunit\":\"0402\",\"irate\":\"12\",\"number\":\"0.25\"},{\"inventorycode\":\"1003\",\"quantity\":\"4\",\"assitantunit\":\"0201\",\"irate\":\"1\",\"number\":\"4\"}]}}";
                bo = api.Add(body, biz_id);

                // 场景2：无上游业务
                //如果没有上有业务，请使用 api.add2(body, tradeid) 进行新增
                //string tradeid = (new Trade()).Get().BodyObject.GetValue("tradeid").ToString();
                //bo = api.Add(body, biz_id);

                _logger.Info("调用失败：" + bo.IsError);
                _logger.Info("失败原因：" + bo.ErrMsg);
                _logger.Info("新增的Id=" + bo.Id);
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
