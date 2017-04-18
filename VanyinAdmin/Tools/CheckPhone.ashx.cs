using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanyinAdmin.Tools
{
    /// <summary>
    /// CheckPhone 的摘要说明
    /// </summary>
    public class CheckPhone : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Vanyin.BLL.Member bll = new Vanyin.BLL.Member();

            string strAccount = context.Request["param"].ToString();


            JsonData data = new JsonData();


            if (bll.GetRecordCount("Phone='" + strAccount + "'") > 0)
            {
                data["status"] = "n";
                data["info"] = "该手机号已存在，请重新输入！";
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