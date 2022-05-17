using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yonyou.OpenApi;
using Yonyou.OpenApi.Service;
using Yonyou.OpenApi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Collections;
using System.Web.Script.Serialization;
namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        public string str1;
        public string str2;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        protected void BindData()
        {
            //List<Product> products = product.GetRepeaterData(prod);
            //string json = JsonConvert.SerializeObject(products);
            SaleorderApi api = new SaleorderApi();
            BusinessObject bo;
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("custcode", "SHNSMCYDYFGS");
            bo = api.List(parameters);
            string json = JsonConvert.SerializeObject(bo);
            JObject jo = (JObject)JsonConvert.DeserializeObject(json);
           // string zone = jo["body_array"][0]["date"].ToString();
           // string zone_en = jo["body_array"][0]["cusabbname"].ToString();
            //str2 += "******************</br></br>" + zone + "***" + zone_en + "*****";
            //dataRepeater.DataSource = json;
            //dataRepeater.DataBind();
            string ssss = "";
            Newtonsoft.Json.Linq.JToken jtoken = jo["body_array"];
            DataTable dt = ToDataTableTwo(jtoken.ToString());
            dataRepeater.DataSource = dt;
            dataRepeater.DataBind();
                //JObject pcount = (JObject)JsonConvert.DeserializeObject(jo["body_array"][0].ToString());
                //IEnumerable<JProperty> properties = pcount.Properties();
            /*
            foreach (JProperty item in jtoken.ToObject<JProperty>())
                {
                    //numTotal += int.Parse(item.Value.ToString());
                    ssss += "******************</br></br>" + item.Name + item.Value;
                    // item.Name 为 键
                    // item.Value 为 值
                }
             */
              ///  str2 = jtoken.ToString();
            }
        public static DataTable ToDataTableTwo(string json)
        {
            //整理json字符串,去除开头的{"data":,不去除就无法使用javaScriptSerializer转换为DataTable
           // json = json.Substring(2, json.Length - 2);
           // json = json.Substring(0, json.Length - 1);

            DataTable dataTable = new DataTable();
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        //Columns
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        //Rows
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }
                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }
    }



}
