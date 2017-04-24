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
        Vanyin.BLL.Member bllMember = new Vanyin.BLL.Member();
        public Vanyin.Model.Member modelMember = new Vanyin.Model.Member();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("personal-home.aspx");
            if (!IsPostBack)
            {
                BindMallList();
                modelMember = bllMember.GetModel(int.Parse(Vanyin.Common.Utils.GetCookie("MemberId")));
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