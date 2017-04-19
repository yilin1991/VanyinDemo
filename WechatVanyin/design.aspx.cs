using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class design : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.Category bllCategory = new Vanyin.BLL.Category();
        Vanyin.BLL.DesignOrder bllOrder = new Vanyin.BLL.DesignOrder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDesignType();
            }
        }


        void BindDesignType()
        {
            RepDesignType.DataSource = bllCategory.GetList(0, "StateInfo=1 and ParentId=10001", "SortNum asc,Id asc");
            RepDesignType.DataBind();
        }



    }
}