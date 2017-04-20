using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WechatVanyin.Tools
{
    /// <summary>
    /// QuitLogin 的摘要说明
    /// </summary>
    public class QuitLogin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Vanyin.Common.Utils.WriteCookie("Account", "", -1440);
            Vanyin.Common.Utils.WriteCookie("MemberId", "", -1440);

            context.Response.Redirect("/index.aspx");
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