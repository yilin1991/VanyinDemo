using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WechatVanyin.Tools
{
    /// <summary>
    /// AddPrintOrder 的摘要说明
    /// </summary>
    public class AddPrintOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Vanyin.BLL.PrintOrder bll = new Vanyin.BLL.PrintOrder();
            Vanyin.Model.PrintOrder model = new Vanyin.Model.PrintOrder();

            JsonData jd = new JsonData();

            model.AddTime = DateTime.Now;
            model.Email = context.Request["txtEmail"].ToString();
            model.Explain = context.Request[""].ToString();
            model.MemberId = 0;
            model.NameInfo = context.Request[""].ToString();
            model.NumId = new Vanyin.Web.UI.BasePage().GetNumId(DateTime.Now);
            model.Phone = context.Request[""].ToString();
            model.Require = context.Request[""].ToString();
            model.StateInfo = 0;
            model.TypeId = int.Parse(context.Request[""].ToString());

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