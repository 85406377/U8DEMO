namespace Yonyou.OpenApi.Model
{
    #region imports

    using System;
    using Newtonsoft.Json;
    using System.Collections;
    using Newtonsoft.Json.Linq;

    #endregion imports

    /// <summary>
    /// 对应 JArray
    /// </summary>
    public class ApiList
    {
        private JArray array;

        public ApiList(JArray array)
        {
            this.array = array;
        }

        public JArray GetJArray()
        {
            return array;
        }

        public IList GetArray()
        {
            return array;
        }

        public int Count
        {
            get { return array.Count; }
        }

        public ApiDictionary this[int index]
        {
            get { return this.GetObject(index); }
        }

        public ApiDictionary GetObject(int index)
        {
            Type t = array[index].GetType();
            if (t.FullName.Equals("Newtonsoft.Json.Linq.JObject", StringComparison.CurrentCultureIgnoreCase))
            {
                return JsonConvert.DeserializeObject<ApiDictionary>(array[index].ToString());
            }
            return null;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(array);
        }
    }
}
