namespace OpenAPI4Net.Examples
{
    #region Imports
    using System;
    using Yonyou.OpenApi;
    using Yonyou.OpenApi.Service;
    using Yonyou.OpenApi.Model;
    #endregion

    /// <summary>
    /// 商旅订单
    /// </summary>
    public class Businesstravelorder
    {
        private static Log _logger = new Log();
        private const string SOURCE = ""; //"OpenAPI4Net.Examples.Businesstravelorder";

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
                BusinesstravelorderApi api = new BusinesstravelorderApi();

                #region 获取单个资源
                _logger.Info("**** get ****");

                BusinessObject bo = api.Get("1084460662");
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
                #endregion

                #region 批量获取资源
                //不支持
                //bo = api.BatchGet(null);
                #endregion

                #region 新增
                _logger.Info("**** add ****");

                // 场景1：有上游业务
                string biz_id = "0007";//上游id
                String body = "{\"businesstravelorder\":{\"OrderID\":\"1084460663\",\"Amount\":\"1287\",\"UID\":\"2106338909\",\"OrderDate\":\"2015-9-23 10:20:48\",\"CorporationName\":\"携程商旅公司（测试222）\",\"entry\":{\"OrderCode\":\"1084460662\",\"PassengerName\":\"xxx\",\"NationalityCode\":\"CN\",\"NationalityName\":\"中国大陆\",\"CardTypeName\":\"身份证\",\"CardTypeNumber\":\"211003197706202116\",\"PassengerNamePY\":\"xxx_py\",\"AirlineCode\":\"MU\",\"AirLineName\":\"东方航空\",\"DCityCode\":\"SHA\",\"DCityName\":\"上海\",\"ACityCode\":\"BJS\",\"ACityName\":\"北京\",\"DPortCode\":\"SHA\",\"DPortName\":\"虹桥\",\"APortCode\":\"PEK\",\"APortName\":\"首都\",\"TakeOffTime\":\"2014-12-25 13:00:00\",\"ArrivalTime\":\"2014-12-25 15:20:00\",\"ClassName\":\"经济舱\",\"Price\":\"11079\",\"PrintPrice\":\"11309\",\"ServerFee\":\"109\",\"CorpPrice\":\"11079\",\"AmountSub\":\"12779\",\"Tax\":\"509\",\"OilFee\":\"1209\",\"StandardPrice\":\"11309\"}}}";
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
