using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class MallDetail : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.ProductMall bllMall = new Vanyin.BLL.ProductMall();
        Vanyin.BLL.ExchangeOrder bllOrder = new Vanyin.BLL.ExchangeOrder();
        Vanyin.BLL.Address bllAddress = new Vanyin.BLL.Address();

        public Vanyin.Model.ExchangeOrder modelOrder = new Vanyin.Model.ExchangeOrder();
        public Vanyin.Model.Address modelAddress = new Vanyin.Model.Address();
        public Vanyin.Model.ProductMall modelMall = new Vanyin.Model.ProductMall();
        int eoid;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("personal-home.aspx");

            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["id"], out eoid))
                {
                    BindDetail(eoid);
                }
                else
                {
                    Response.Redirect("order-list.aspx");
                }
            }
        }


        void BindDetail(int id)
        {
            modelOrder = bllOrder.GetModel(id);
            if (modelOrder.StateInfo == 3 || modelOrder.StateInfo == 5)
            {

                btnOk.CssClass = "btnorderdetailhide";
            }
            modelAddress = bllAddress.GetModel(modelOrder.AddressInfoId);
            modelMall = bllMall.GetModel(modelOrder.Mall);
        }

        /// <summary>
        /// 确认收货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.ExchangeOrder model1 = bllOrder.GetModel(int.Parse(Request.Params["id"]));
            model1.StateInfo = 3;
            bllOrder.Update(model1);
            BindDetail(int.Parse(Request.Params["id"]));
        }
    }
}