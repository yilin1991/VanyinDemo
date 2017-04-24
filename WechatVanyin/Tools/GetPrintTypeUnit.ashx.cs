using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WechatVanyin.Tools
{
    /// <summary>
    /// GetPrintTypeUnit 的摘要说明
    /// </summary>
    public class GetPrintTypeUnit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Vanyin.BLL.Category bll = new Vanyin.BLL.Category();
            context.Response.ContentType = "text/plain";

            JsonData jd = new JsonData();

            Vanyin.Model.Category model = bll.GetModel(int.Parse(context.Request["id"].ToString()));

            jd["unit"] = model.SubTitle;

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