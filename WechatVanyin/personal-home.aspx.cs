using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class personal_home : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.Member bll = new Vanyin.BLL.Member();

        public Vanyin.Model.Member model = new Vanyin.Model.Member();

        protected void Page_Load(object sender, EventArgs e)
        {

            CheckLogin("personal-home.aspx");
            if (!IsPostBack)
            {
                model = bll.GetModel(int.Parse(Vanyin.Common.Utils.GetCookie("MemberId")));
            }
        }

       

       


    }
}