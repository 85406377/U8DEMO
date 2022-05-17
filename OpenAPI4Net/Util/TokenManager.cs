
namespace Yonyou.OpenApi.Model
{
    #region imports

    using System;

    #endregion

    /// <summary>
    /// Token 生命周期维护器。平台 Token 生效期为 2 小时，SDK 1小时55分钟为重新获取新 token 的周期。
    /// </summary>
    public class TokenManager
    {
        private static long? timestamp; 
        private const long MILLISECONDS_EXPIRED = 6900000; //1000 * 60 * 60 * 2 - 1000 * 60 * 5 (1小时55分钟);
        private static string token = String.Empty;

        public static string GetToken()
        {
            long nowTimestamp = (long)DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds;
            if ((timestamp == null)
                || (nowTimestamp - timestamp > MILLISECONDS_EXPIRED))
            {
                BusinessObject bo = (new Token()).Get();
                if (!bo.IsError)
                {
                    TokenManager.token = bo.Full.GetObject("token").GetValue("id").ToString();
                }

                TokenManager.timestamp = (long)DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds;
            }
            return TokenManager.token;
        }
    }
}
