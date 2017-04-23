using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WechatVanyin.Tools
{
    /// <summary>
    /// AddMallOrder 的摘要说明
    /// </summary>
    public class AddMallOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            JsonData jd = new JsonData();

            Vanyin.BLL.ExchangeOrder bll = new Vanyin.BLL.ExchangeOrder();
            Vanyin.Model.ExchangeOrder model = new Vanyin.Model.ExchangeOrder();

            model.AddressInfoId = int.Parse(context.Request["hidaid"].ToString());
            model.Addtime = DateTime.Now;
            model.Integral = 10;
            model.Mall = int.Parse(context.Request["hidpmid"].ToString());
            model.Member = int.Parse(Vanyin.Common.Utils.GetCookie("MemberId"));
            model.Num = new Vanyin.Web.UI.BasePage().GetNumId(DateTime.Now);
            model.OrderNum = 0;
            model.StateInfo = 0;
            model.Remark = context.Request["txtRemark"].ToString();
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

            context.Response.Write("Hello World");
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