using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Yonyou.OpenApi.Http
{
    public class HttpClient
    {
        private WebUtils _webUtils = new WebUtils();

        public Response Get(string url, IDictionary<string, string> parameters)
        {
            return new Response(this.WebUtils.Get(url, parameters));
        }

        public Response Post(string url, IDictionary<string, string> parameters, string data)
        {
            return new Response(this.WebUtils.Post(url, parameters, data));
        }

        protected WebUtils WebUtils
        {
            get { return this._webUtils; }
        }



    }
}
