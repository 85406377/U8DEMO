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
    /// 销售订单
    /// </summary>
    public class Saleorder
    {
        private const string SOURCE = ""; //"OpenAPI4Net.Examples.Saleorder";

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
                SaleorderApi api = new SaleorderApi();
                
                #region 获取单个资源
               
                BusinessObject bo = api.Get("0000000234");
                /*
                _logger.Debug(SOURCE, String.Format("resource_id:{0}", bo.ResourceId));
                _logger.Debug(SOURCE, String.Format("IsError:{0}", bo.IsError));
                _logger.Debug(SOURCE, String.Format("errmsg:{0}", bo.ErrMsg));

                _logger.Info(" 原生结果");
                _logger.Debug(SOURCE, bo.NativeResponseString);

                _logger.Info(" 业务数据");
                if (bo.BodyObject != null)
                    _logger.Debug(SOURCE, bo.BodyObject.ToString());

                _logger.Info(" 业务数据.订单号");
                if (bo.BodyObject != null && (bo.BodyObject["code"] != null))
                {
                    _logger.Debug(SOURCE, bo.BodyObject["code"].ToString());
                    _logger.Debug(SOURCE, bo.BodyObject.GetValue("code").ToString());
                }
                 */
                #endregion

                #region 批量获取资源
                //不支持
                //bo = api.BatchGet(null);
                #endregion

                #region 获取列表
               // _logger.Info("**** list ****");

                IDictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("custcode", "0901");
                bo = api.List(parameters);

               // _logger.Info(" 原生结果");
               // _logger.Debug(SOURCE, bo.NativeResponseString);
                #endregion

                #region 新增
              //  _logger.Info("**** add ****");

                // 场景1：有上游业务
                string biz_id = "0007";//上游id
                String body = "{\"saleorder\":{\"custcode\":\"099901\",\"deptcode\":\"0302\",\"entry\":[{\"inventorycode\":\"1008\",\"quantity\":\"15\",\"quotedprice\":\"200\",\"money\":\"3000\",\"irowno\":\"1\",\"dpredate\":\"2015-10-23\"},{\"inventorycode\":\"0301\",\"quantity\":\"20\",\"quotedprice\":\"30\",\"money\":\"600\",\"irowno\":\"2\",\"dpredate\":\"2015-10-23\"}]}}";
                bo = api.Add(body, biz_id);

                // 场景2：无上游业务
                //如果没有上有业务，请使用 api.add2(body, tradeid) 进行新增
                //string tradeid = (new Trade()).Get().BodyObject.GetValue("tradeid").ToString();
                //bo = api.Add(body, biz_id);

              //  _logger.Info("调用失败：" + bo.IsError);
              //  _logger.Info("失败原因：" + bo.ErrMsg);
              //  _logger.Info("新增的Id=" + bo.Id);
                #endregion
                
                #region 审核
              //  _logger.Info("**** audit ****");
                bo = api.Audit("0000000002", "", "002", "同意", true);
              //  _logger.Info("调用失败：" + bo.IsError);
              //  _logger.Info("失败原因：" + bo.ErrMsg);
                #endregion
                
                #region 弃审
              //  _logger.Info("**** abandon ****");
                bo = api.Abandon("0000000248", "", "00001", "退回");
             //   _logger.Info("调用失败：" + bo.IsError);
             //   _logger.Info("失败原因：" + bo.ErrMsg);
                #endregion

                #region 查看审批进程
              //  _logger.Info("**** history ****");
                bo = api.History("0000000248", "", "00001");
             //   _logger.Info("调用失败：" + bo.IsError);
              //  _logger.Info("失败原因：" + bo.ErrMsg);
            //    _logger.Info(" 原生结果");
             //   _logger.Debug(SOURCE, bo.NativeResponseString);
                #endregion

                #region 查看待办任务
             //   _logger.Info("**** tasks ****");
                bo = api.Tasks("00002", null, null);
              //  _logger.Info("调用失败：" + bo.IsError);
             //   _logger.Info("失败原因：" + bo.ErrMsg);
               // _logger.Info(" 原生结果");
             //   _logger.Debug(SOURCE, bo.NativeResponseString);
                #endregion

            }
            catch (Exception e)
            {
              //  _logger.Info(e.StackTrace);
            }
            finally
            {
              //  _logger.Info("\r\n#### END ####\r\n\r\n");
            }
        }
    }
}
