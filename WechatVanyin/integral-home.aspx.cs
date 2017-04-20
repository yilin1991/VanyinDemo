using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class integral_home : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.ProductMall bllMall = new Vanyin.BLL.ProductMall();


        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("personal-home.aspx");
            if (!IsPostBack)
            {
                BindMallList();
            }
        }

        /// <summary>
        /// 绑定兑换商品列表
        /// </summary>
        void BindMallList()
        {
            RepMallList.DataSource = bllMall.GetList(0, "StateInfo=1", "SortNum asc");
            RepMallList.DataBind();
        }


    }
}