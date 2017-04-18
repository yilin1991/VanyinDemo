using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanyinAdmin.Tools
{
    /// <summary>
    /// CheckAccount 的摘要说明
    /// </summary>
    public class CheckAccount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Vanyin.BLL.Member bll = new Vanyin.BLL.Member();

            string strAccount = context.Request["param"].ToString();


            JsonData data = new JsonData();


            if (bll.GetRecordCount("Account='" + strAccount + "'") > 0)
            {
                data["status"] = "n";
                data["info"] = "您输入的用户名已存在请重新输入！";
            }
            else
            {
                data["status"] = "y";
            }

            context.Response.Write(data.ToJson());
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