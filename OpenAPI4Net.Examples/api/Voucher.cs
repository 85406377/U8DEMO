namespace OpenAPI4Net.Examples
{
    #region Imports
    using System;
    using Yonyou.OpenApi.Service;
    using Yonyou.OpenApi.Model;
    #endregion

    /// <summary>
    /// 凭证
    /// </summary>
    public class Voucher
    {
        private static Log _logger = new Log();
        private const string SOURCE = ""; //"OpenAPI4Net.Examples.Voucher";

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
                VoucherApi api = new VoucherApi();
               
                #region 获取单个凭证
                //不支持查询单个凭证
                //BusinessObject bo = api.Get("01");
                #endregion

                #region 批量获取凭证
                //不支持批量查询凭证，抛出异常
               // bo = api.BatchGet(null);
               
                #endregion
                
                #region 新增一个凭证
                _logger.Info("#### voucher/add ####\r\n");
                string biz_id = "0007";//上游id
                //请求体
                string body="{\"voucher\":{\"accounting_period\":\"1\",\"credit\":{\"entry\":[{\"abstract\":\"222222\",\"account_code\":\"122102\",\"auxiliary\":{\"dept_id\":\"0301\",\"personnel_id\":\"00033\"},\"credit_quantity\":\"0\",\"document_date\":\"2015-01-06\",\"document_id\":\"321654\",\"entry_id\":\"2\",\"exchange_rate2\":\"0\",\"natural_credit_currency\":\"1000\",\"primary_credit_amount\":\"0\"}]},\"date\":\"2015-01-06\",\"debit\":{\"entry\":[{\"abstract\":\"222222\",\"account_code\":\"100202\",\"auxiliary\":{},\"debit_quantity\":\"0\",\"document_date\":\"2015-01-06\",\"document_id\":\"1234567\",\"entry_id\":\"1\",\"exchange_rate2\":\"0\",\"natural_debit_currency\":\"1000\",\"primary_debit_amount\":\"0\",\"settlement\":\"8\"}]},\"enter\":\"demo\",\"fiscal_year\":\"2015\",\"voucher_type\":\"记\"}}";
                BusinessObject bo = api.Add(body, biz_id);
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
