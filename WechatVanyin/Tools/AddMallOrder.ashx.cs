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
            Vanyin.BLL.ProductMall bllMall = new Vanyin.BLL.ProductMall();
            Vanyin.BLL.Integral bllIntegral = new Vanyin.BLL.Integral();
            Vanyin.Model.Integral modelIntegral = new Vanyin.Model.Integral();

            int mallIntegral= bllMall.GetModel(int.Parse(context.Request["hidpmid"].ToString())).Integral;


            if (mallIntegral <= new Vanyin.Web.UI.BasePage().GetUsableIntegral(Vanyin.Common.Utils.GetCookie("MemberId")))
            {

                model.AddressInfoId = int.Parse(context.Request["hidaid"].ToString());
                model.Addtime = DateTime.Now;
                model.Integral = mallIntegral;
                model.Mall = int.Parse(context.Request["hidpmid"].ToString());
                model.Member = int.Parse(Vanyin.Common.Utils.GetCookie("MemberId"));
                model.Num = new Vanyin.Web.UI.BasePage().GetNumId(DateTime.Now);
                model.OrderNum = 1;
                model.StateInfo = 0;
                model.Remark = context.Request["txtRemark"].ToString();
                int orderId = bll.Add(model);


                if (orderId > 0)
                {
                    modelIntegral.AddTime = DateTime.Now;
                    modelIntegral.Explain = "兑换商品";
                    modelIntegral.Identifier = model.Num;
                    modelIntegral.TypeId = 10039;
                    modelIntegral.MemberId = int.Parse(Vanyin.Common.Utils.GetCookie("MemberId"));
                    modelIntegral.Num = int.Parse("-" + model.Integral.ToString());

                    bllIntegral.Add(modelIntegral);

                    jd["state"] = "success";
                    jd["orderId"] = orderId;
                }
                else
                {
                    jd["state"] = "error";
                    jd["msg"] = "对不起，您的订单提交失败，请稍候重试！";
                }
            }
            else
            {
                jd["state"] = "error";
                jd["msg"] = "对不起，积分不足无法兑换！";
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