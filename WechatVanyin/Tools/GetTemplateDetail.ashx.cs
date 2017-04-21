using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WechatVanyin.Tools
{
    /// <summary>
    /// GetTemplateDetail 的摘要说明
    /// </summary>
    public class GetTemplateDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var temId = context.Request["temId"].ToString();
            Vanyin.BLL.DesignTemplate bll = new Vanyin.BLL.DesignTemplate();

            JsonData jd = new JsonData();

            Vanyin.Model.DesignTemplate model = bll.GetModel(int.Parse(temId));

            jd["imgurl"] = new Vanyin.Web.UI.BasePage().GetFileServer(10000) + model.ImgUrl;
            jd["title"] = model.Title;
            



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