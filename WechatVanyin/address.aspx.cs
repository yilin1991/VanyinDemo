using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class address : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.Address bll = new Vanyin.BLL.Address();
        Vanyin.BLL.S_City bllCity = new Vanyin.BLL.S_City();
        Vanyin.BLL.S_District bllDistrict = new Vanyin.BLL.S_District();
        Vanyin.BLL.S_Province bllProvince = new Vanyin.BLL.S_Province();


        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("Address.aspx");
            if (!IsPostBack)
            {
                BindRepList();
            }
        }

        /// <summary>
        /// 绑定收货地址列表
        /// </summary>
        void BindRepList()
        {
            RepAddressList.DataSource = bll.GetList(0, "MemberId=" + Vanyin.Common.Utils.GetCookie("MemberId"), "Id desc");
            RepAddressList.DataBind();
        }





    }
}