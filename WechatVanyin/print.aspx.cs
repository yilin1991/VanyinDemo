using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vanyin.Common;

namespace WechatVanyin
{
    public partial class print : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.Category bll = new Vanyin.BLL.Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("Print.aspx");

            if (!IsPostBack)
            {
                //BindddlType(10002, ddlTypelist);
                BindRepList();
            }
        }


        /// <summary>
        /// 绑定印刷类别
        /// </summary>
        void BindRepList()
        {
            RepList.DataSource = bll.GetList("ParentId=10002");
            RepList.DataBind();
        }

       

    }
}