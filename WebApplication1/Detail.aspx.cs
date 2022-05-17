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
using System.Net;

namespace WebApplication1
{
    public partial class Detail : System.Web.UI.Page
    {
        public string str1;
        public string str2;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        protected void BindData()
        {
            str1 = Request["orderid"];
            SaleorderApi api = new SaleorderApi();
            BusinessObject bo = api.Get(str1);
            string json = JsonConvert.SerializeObject(bo);
            JObject jo = (JObject)JsonConvert.DeserializeObject(json);
            Newtonsoft.Json.Linq.JToken jtoken = jo["body"]["entry"];
            //str1 = jo.ToString();
            DataTable dt = ToDataTableTwo(jtoken.ToString());
            dataRepeater.DataSource = dt;
            dataRepeater.DataBind();

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