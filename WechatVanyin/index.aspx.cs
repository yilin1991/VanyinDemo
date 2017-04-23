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
        Vanyin.BLL.DesignTemplate bllTemplate = new Vanyin.BLL.DesignTemplate();
      public  List<Vanyin.Model.DesignTemplate> modelTemplate = new List<Vanyin.Model.DesignTemplate>();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIndexBanner();
                BindRepType();
                BindRecTemplate();
                BindTechnology();
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


        /// <summary>
        /// 绑定推荐模版
        /// </summary>
        void BindRecTemplate()
        {
           modelTemplate = bllTemplate.GetModelList("IsIndex=1 and StateInfo=1");
        }


        /// <summary>
        /// 绑定工艺材质
        /// </summary>
        void BindTechnology()
        {
            Vanyin.BLL.Technology bll = new Vanyin.BLL.Technology();

            RepTechnology.DataSource = bll.GetList(0, "StateInfo=1 and IsIndex=1", "SortNum asc,Id desc");
            RepTechnology.DataBind();

        }

    }
}