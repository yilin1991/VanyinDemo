using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
using System.Text;
using System.Data;
namespace VanyinAdmin.Tools
{
    /// <summary>
    /// GetCity 的摘要说明
    /// </summary>
    public class GetCity : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            Vanyin.BLL.S_City bll = new Vanyin.BLL.S_City();

            DataSet ds = bll.GetList(0, "ProvinceID="+context.Request["provinceId"].ToString(), "ProvinceID asc");
            StringBuilder strHtml = new StringBuilder();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                strHtml.Append("<option value=\""+item["ProvinceID"].ToString()+"\">"+item["ProvinceName"].ToString() + "</option>");
            }
            JsonData jd = new JsonData();
            jd["cityList"] = strHtml.ToString();
            context.Response.Write(jd.ToJson());

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}