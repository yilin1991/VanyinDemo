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
    /// GetDistrict 的摘要说明
    /// </summary>
    public class GetDistrict : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Vanyin.BLL.S_District bll = new Vanyin.BLL.S_District();

            DataSet ds = bll.GetList(0, "CityID=" + context.Request["cityId"].ToString(), "DistrictID asc");
            StringBuilder strHtml = new StringBuilder("<option value=\"\">请选择区县</option>");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                strHtml.Append("<option value=\"" + item["DistrictID"].ToString() + "\">" + item["DistrictName"].ToString() + "</option>");
            }
            JsonData jd = new JsonData();
            jd["districtList"] = strHtml.ToString();
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