namespace OpenAPI4Net.Examples
{
    #region Imports
    using System;
    using Yonyou.OpenApi.Service;
    using Yonyou.OpenApi.Model;

    #endregion

    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        private static Log _logger = new Log();
        private const string SOURCE = ""; //"OpenAPI4Net.Examples.User";

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
                UserApi api = new UserApi();

                #region 登录
                _logger.Info("**** login ****");
                BusinessObject bo = api.Login("002", "2");

                _logger.Info(" 原生结果");
                _logger.Debug(SOURCE, bo.NativeResponseString);

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
