using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class index : Vanyin.Web.UI.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIndexBanner();
                BindRepType();
                
            }
        }


        void BindIndexBanner()
        {
            Vanyin.BLL.Filetable bll = new Vanyin.BLL.Filetable();
            repIndexBanner.DataSource = bll.GetList(0, "StateInfo=1 and TypeId=10022", "SortNum asc");
            repIndexBanner.DataBind();
        }



        /// <summary>
        /// 绑定印刷类别
        /// </summary>
        void BindRepType()
        {
            Vanyin.BLL.Category bll = new Vanyin.BLL.Category();

            repTypeList.DataSource = bll.GetList(9,"ParentId=10002 and StateInfo=1","SortNum asc");
            repTypeList.DataBind();
        }

    }
}