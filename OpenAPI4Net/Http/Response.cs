using System.Text;
using System.Net;
using System.IO;

namespace Yonyou.OpenApi.Http
{
    public class Response
    {
        public Response(HttpWebResponse resp) 
        {
            this.HttpWebResponse = resp;
        }

        public HttpWebResponse HttpWebResponse { get; private set; }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <returns>响应文本</returns>
        public string GetResponseAsString()
        {
            Encoding encoding = Encoding.GetEncoding(this.HttpWebResponse.CharacterSet);
            return this.GetResponseAsString(encoding);
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public string GetResponseAsString(Encoding encoding)
        {
            System.IO.Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 以字符流的方式读取HTTP响应
                stream = this.HttpWebResponse.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (this.HttpWebResponse != null) this.HttpWebResponse.Close();
            }
        }
    }
}
