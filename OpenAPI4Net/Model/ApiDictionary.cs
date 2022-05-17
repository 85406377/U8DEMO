namespace Yonyou.OpenApi.Model
{
    #region imports
    using System;
    using System.Collections;
    using Newtonsoft.Json;
    #endregion

    /// <summary>
    /// 对应 JObject
    /// </summary>
    public class ApiDictionary : DictionaryBase
    {
        #region DictionaryBase members

        public void Add(string name, object value)
        {
            base.InnerHashtable.Add(name, value);
        }

        public void Remove(string name)
        {
            base.InnerHashtable.Remove(name);
        }

        public ICollection Keys()
        {
            return base.InnerHashtable.Keys;
        }

        public ICollection Values()
        {
            return base.InnerHashtable.Values;
        }

        public bool ContainsName(string name)
        {
            return base.InnerHashtable.ContainsKey(name);
        }

        public bool ContainsValue(object value)
        {
            return base.InnerHashtable.ContainsValue(value);
        }

        public object this[string name]
        {
            get { return base.InnerHashtable[name]; }
            set { base.InnerHashtable[name] = value; }
        }

        #endregion

        public bool IsArray(string name)
        {
            Type t = base.InnerHashtable[name].GetType();
            return t.FullName.Equals("Newtonsoft.Json.Linq.JArray", StringComparison.CurrentCultureIgnoreCase);
        }

        public object Get(string name)
        {
            if (base.InnerHashtable[name] == null)
            {
                return null;
            }
            Type t = base.InnerHashtable[name].GetType();
            if (t.FullName.Equals("Newtonsoft.Json.Linq.JArray", StringComparison.CurrentCultureIgnoreCase))
            {
                return new ApiList((Newtonsoft.Json.Linq.JArray)base.InnerHashtable[name]);
            } 
            if (t.FullName.Equals("Newtonsoft.Json.Linq.JObject", StringComparison.CurrentCultureIgnoreCase))
            {
                return JsonConvert.DeserializeObject<ApiDictionary>(base.InnerHashtable[name].ToString());
            }
            return base.InnerHashtable[name].ToString();;
        }

        public ApiList GetArray(string name)
        {
            if (base.InnerHashtable[name] == null)
            {
                return null;
            }
            Type t = base.InnerHashtable[name].GetType();
            if (t.FullName.Equals("Newtonsoft.Json.Linq.JArray", StringComparison.CurrentCultureIgnoreCase))
            {
                return new ApiList((Newtonsoft.Json.Linq.JArray)base.InnerHashtable[name]);
            }
            return null;
        }

        public ApiDictionary GetObject(string name)
        {
            if (base.InnerHashtable[name] == null)
            {
                return null;
            }
            Type t = base.InnerHashtable[name].GetType();
            if (t.FullName.Equals("Newtonsoft.Json.Linq.JObject", StringComparison.CurrentCultureIgnoreCase))
            {
                return JsonConvert.DeserializeObject<ApiDictionary>(base.InnerHashtable[name].ToString());
            }
            return null;
        }

        public object GetValue(string name)
        {
            if (base.InnerHashtable[name] == null)
            {
                return null;
            }
            Type t = base.InnerHashtable[name].GetType();
            if (!t.FullName.Equals("Newtonsoft.Json.Linq.JObject", StringComparison.CurrentCultureIgnoreCase)
                && !t.FullName.Equals("Newtonsoft.Json.Linq.JArray", StringComparison.CurrentCultureIgnoreCase))
            {
                return base.InnerHashtable[name].ToString();
            }
            return null;
        }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
