using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class integral_order : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.ProductMall bllMall = new Vanyin.BLL.ProductMall();
        Vanyin.BLL.ExchangeOrder bllOrder = new Vanyin.BLL.ExchangeOrder();
        Vanyin.BLL.Address bllAddress = new Vanyin.BLL.Address();

        int pmid;
        int aid;
        public Vanyin.Model.ProductMall modelMall = new Vanyin.Model.ProductMall();


        public Vanyin.Model.Address modelAddress = new Vanyin.Model.Address();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("integral-home.aspx");
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["pmid"], out pmid))
                {
                    BindMall(pmid);
                    BindDefaultAddress();
                }
                else
                {
                    Response.Redirect("integral-home.aspx");
                }
            }
        }


        /// <summary>
        /// 绑定兑换商品详情
        /// </summary>
        /// <param name="pmid"></param>
        void BindMall(int pmid)
        {
            modelMall = bllMall.GetModel(pmid);

            


        }


        void BindDefaultAddress()
        {
            if (string.IsNullOrEmpty(Request.Params["aid"]))
            {
                List<Vanyin.Model.Address> addressList = bllAddress.GetModelList("MemberId="+Vanyin.Common.Utils.GetCookie("MemberId"));
                if (addressList.Count > 0)
                {
                    modelAddress = addressList[0];
                }

            }
            else
            {
                modelAddress=bllAddress.GetModel(int.Parse(Request.Params["aid"]));
            }
        }


    }
}