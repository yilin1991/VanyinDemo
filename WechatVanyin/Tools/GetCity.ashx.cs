using LitJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace WechatVanyin.Tools
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

            DataSet ds = bll.GetList(0, "ProvinceID=" + context.Request["provinceId"].ToString(), "CityID asc");
            StringBuilder strHtml = new StringBuilder("<option value=\"\">请选择城市</option>");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                strHtml.Append("<option value=\"" + item["CityID"].ToString() + "\">" + item["CityName"].ToString() + "</option>");
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