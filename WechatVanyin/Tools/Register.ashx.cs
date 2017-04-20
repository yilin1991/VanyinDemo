using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WechatVanyin.Tools
{
    /// <summary>
    /// Register 的摘要说明
    /// </summary>
    public class Register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            Vanyin.BLL.Member bll = new Vanyin.BLL.Member();
            Vanyin.Model.Member model = new Vanyin.Model.Member();
            JsonData jd = new JsonData();

            string phone = context.Request["txtAccount"].ToString();
            string pwd = Vanyin.Common.DESEncrypt.Encrypt( context.Request["txtPassword"].ToString());


            model.Account = phone;
            model.NumId = new Vanyin.Web.UI.BasePage().GetNumId(DateTime.Now);

            model.AddTime = DateTime.Now;
            model.Phone = phone;
            model.Pwd = pwd;
            model.StateInfo = 1;
            model.TypeId = 10011;

            int mid = bll.Add(model);

            if (mid > 0)
            {
                jd["state"] = "success";
                Vanyin.Common.Utils.WriteCookie("Account", phone, 9999999);
                Vanyin.Common.Utils.WriteCookie("MemberId", mid.ToString(), 9999999);


                if (string.IsNullOrEmpty(Vanyin.Common.Utils.GetCookie("BackUrl")))
                {
                    jd["backurl"] = "";
                }
                else
                {
                    jd["backurl"] = Vanyin.Common.Utils.GetCookie("BackUrl");
                }
            }
            else
            {
                jd["state"] = "error";
                jd["msg"] = "服务器发生未知错误，请稍候重试";
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