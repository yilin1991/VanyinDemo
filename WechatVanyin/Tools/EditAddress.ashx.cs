using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
namespace WechatVanyin.Tools
{
    /// <summary>
    /// EditAddress 的摘要说明
    /// </summary>
    public class EditAddress : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            JsonData jd = new JsonData();
            Vanyin.BLL.Address bll = new Vanyin.BLL.Address();
            Vanyin.Model.Address model = new Vanyin.Model.Address();

            model.AddressInfo = context.Request["txtAddress"].ToString();
            model.AddTime = DateTime.Now;
            model.City = context.Request["ddlProvince"].ToString() + "-" + context.Request["ddlCity"].ToString() + "-" + context.Request["ddlDistrict"].ToString();
            model.IsDefault = 1;
            model.MemberId = int.Parse(Vanyin.Common.Utils.GetCookie("MemberId").ToString());
            model.TypeName = "";
            model.Phone = context.Request["txtPhone"].ToString();
            model.Name = context.Request["txtName"].ToString();
            model.StateInfo = 1;


            if (context.Request["hidAid"].ToString() != "")
            {

                model.Id = int.Parse(context.Request["hidAid"].ToString());

                if (bll.Update(model))
                {


                    jd["state"] = "success";
                    jd["id"] = model.Id;
                }
                else
                {
                    jd["state"] = "error";
                    jd["msg"] = "对不起，您的订单提交失败，请稍候重试！";
                }
            }
            else
            {

                int aid = bll.Add(model);


                if (aid > 0)
                {
                    jd["state"] = "success";
                    jd["id"] = aid;
                }
                else
                {
                    jd["state"] = "error";
                    jd["msg"] = "对不起，您的订单提交失败，请稍候重试！";
                }

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