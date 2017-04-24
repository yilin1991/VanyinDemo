using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class integral_detailed : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.Integral bll = new Vanyin.BLL.Integral();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("personal-home.aspx");
            if (!IsPostBack)
            {
                BindIntegral();
            }
        }


        /// <summary>
        /// 绑定积分列表
        /// </summary>
        void BindIntegral()
        {

            RepIntegral.DataSource = bll.GetList(0, "MemberId=" + Vanyin.Common.Utils.GetCookie("MemberId"), "AddTime desc");
            RepIntegral.DataBind();
        }


    }
}