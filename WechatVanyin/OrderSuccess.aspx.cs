using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class OrderSuccess : Vanyin.Web.UI.BasePage
    {

        public string orderNum;
        public string orderDetail;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("index.aspx");

            if (!IsPostBack)
            {
                BindUrl();
            }
        }


        void BindUrl()
        {
            if (string.IsNullOrEmpty(Request.Params["orderid"]) || string.IsNullOrEmpty(Request.Params["type"]))
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                if (string.Equals(Request.Params["type"], "print"))
                {
                    Vanyin.BLL.PrintOrder bll = new Vanyin.BLL.PrintOrder();

                    Vanyin.Model.PrintOrder model = bll.GetModel(int.Parse(Request.Params["orderid"]));
                    orderNum = model.NumId;
                    orderDetail = "PrintOrderDetail.aspx?id=" + model.Id;
                }
                if (string.Equals(Request.Params["type"], "design"))
                {
                    Vanyin.BLL.PrintOrder bll = new Vanyin.BLL.PrintOrder();

                    Vanyin.Model.PrintOrder model = bll.GetModel(int.Parse(Request.Params["orderid"]));
                    orderNum = model.NumId;
                    orderDetail = "DesignOrderDetail.aspx?id=" + model.Id;
                }
                if (string.Equals(Request.Params["type"], "mall"))
                {
                    Vanyin.BLL.ExchangeOrder bll = new Vanyin.BLL.ExchangeOrder();

                    Vanyin.Model.ExchangeOrder model = bll.GetModel(int.Parse(Request.Params["orderid"]));
                    orderNum = model.Num;
                    orderDetail = "MallDetail.aspx?id=" + model.Id;
                }
                



            }
        }



    }
}