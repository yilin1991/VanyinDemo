﻿using System;
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
            model.Explain = "";
            model.MemberId = int.Parse(Vanyin.Common.Utils.GetCookie("MemberId"));
            model.PrintNum = context.Request["txtNum"].ToString();
            model.NameInfo = context.Request["txtName"].ToString();
            model.NumId = new Vanyin.Web.UI.BasePage().GetNumId(DateTime.Now);
            model.Phone = context.Request["txtPhone"].ToString();
            model.Require = context.Request["txtRemark"].ToString();
            model.StateInfo = 0;
            model.TypeId = int.Parse(context.Request["ddlTypelist"].ToString());

            int orderId = bll.Add(model);


            if (orderId > 0)
            {
                jd["state"] = "success";
                jd["orderId"] =orderId ;
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