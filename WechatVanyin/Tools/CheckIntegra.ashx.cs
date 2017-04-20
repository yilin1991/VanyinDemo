using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using LitJson;

namespace WechatVanyin.Tools
{
    /// <summary>
    /// CheckIntegra 的摘要说明
    /// </summary>
    public class CheckIntegra : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Vanyin.BLL.Integral bllIntegral = new Vanyin.BLL.Integral();
            Vanyin.BLL.ProductMall bllMall = new Vanyin.BLL.ProductMall();

            DataTable dt = bllIntegral.GetList("MemberId=" + Vanyin.Common.Utils.GetCookie("MemberId")).Tables[0];

            int countIntegral = 0;

            foreach (DataRow item in dt.Rows)
            {
                countIntegral += int.Parse(item["Num"].ToString());
            }

            Vanyin.Model.ProductMall model = bllMall.GetModel(int.Parse(context.Request["pmid"].ToString()));

            JsonData jd = new JsonData();

            if (model.Integral <= countIntegral)//可以兑换
            {
                jd["state"] = "success";
            }
            else
            {
                jd["state"] = "error";
                jd["msg"] = "积分不足，无法兑换该商品";
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