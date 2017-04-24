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

        public string strHtml = "";
        public string strPmid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("Address.aspx");
            if (!IsPostBack)
            {
                BindRepList();
                BindPmid();
            }
        }

        /// <summary>
        /// 绑定收货地址列表
        /// </summary>
        void BindRepList()
        {
            RepAddressList.DataSource = bll.GetList(0, "MemberId=" + Vanyin.Common.Utils.GetCookie("MemberId")+ " and StateInfo=1", "Id desc");
            RepAddressList.DataBind();
        }


        /// <summary>
        /// 绑定选择按钮
        /// </summary>
        public string BindSelect(string aid)
        {
            if (!string.IsNullOrEmpty(Request.Params["pid"]))
            {
                return "<a href='integral-order.aspx?pmid=" + Request.Params["pid"] + "&aid="+aid+"'>选择</a>";
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 绑定
        /// </summary>
        void BindPmid()
        {
            if (!string.IsNullOrEmpty(Request.Params["pid"]))
            {
                strPmid = "?pmid=" + Request.Params["pid"];
            }
            else
            {
                strPmid = "";
            }
        }


    }
}