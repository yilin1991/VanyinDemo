using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WechatVanyin.Tools
{
    /// <summary>
    /// AddDesignOrder 的摘要说明
    /// </summary>
    public class AddDesignOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            JsonData jd = new JsonData();

            Vanyin.BLL.DesignOrder bll = new Vanyin.BLL.DesignOrder();
            Vanyin.Model.DesignOrder model = new Vanyin.Model.DesignOrder();


            model.AddTime = DateTime.Now;
            model.DesignRequire = context.Request["txtremark"].ToString();
            model.Email = context.Request["txtemail"].ToString();
            model.Explain = "";
            model.IfPrint = context.Request["ckprint"].ToString()=="true"?1:0;
            model.MemberId = int.Parse(Vanyin.Common.Utils.GetCookie("MemberId"));
            model.NameInfo = context.Request["txtname"].ToString();
            model.NumId = new Vanyin.Web.UI.BasePage().GetNumId(DateTime.Now);
            model.Phone = context.Request["txttel"].ToString();
            model.TypeId = int.Parse(context.Request["ddlType"].ToString());
            model.TemplateId = int.Parse(context.Request["hidTemId"].ToString());
            model.StateInfo = 0;

            int orderId = bll.Add(model);


            if (orderId > 0)
            {
                jd["state"] = "success";
                jd["orderId"] = orderId;
            }
            else
            {
                jd["state"] = "error";
                jd["msg"] = "对不起，您的订单提交失败，请稍候重试！";
            }


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