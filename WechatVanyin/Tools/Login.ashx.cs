using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WechatVanyin.Tools
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            JsonData jd = new JsonData();

            Vanyin.BLL.Member bll = new Vanyin.BLL.Member();

            string account = context.Request["txtAccount"].ToString();
            string pwd = context.Request["txtPassword"].ToString();

            System.Data.DataTable dt = bll.GetList("(Account='"+account+ "' or Phone='"+account+ "') and Pwd='" +Vanyin.Common.DESEncrypt.Encrypt(pwd)+"'").Tables[0];

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["StateInfo"].ToString() == "1")
                {
                    jd["state"] = "success";
                    jd["backurl"] = Vanyin.Common.Utils.GetCookie("BackUrl");

                    Vanyin.Common.Utils.WriteCookie("Account", dt.Rows[0]["Account"].ToString(), 9999999);
                    Vanyin.Common.Utils.WriteCookie("MemberId", dt.Rows[0]["Id"].ToString(), 9999999);
                }
                else
                {
                    jd["state"] = "error";
                    jd["msg"] = "您的帐号已被禁止登录，详细信息请联系管理员！";
                }

            }
            else
            {
                jd["state"] = "error";
                jd["msg"] = "用户名或密码输入不正确，请重新输入！";
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