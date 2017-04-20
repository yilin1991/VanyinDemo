using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.SystemInfo
{
    public partial class Index : Vanyin.Web.UI.ManagePage
    {
        Vanyin.BLL.SystemInfo bll = new Vanyin.BLL.SystemInfo();

        public int pagesize;
        public int page;
        public int pcount;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepList();
            }
        }



        /// <summary>
        /// 绑定系统设置列表
        /// </summary>
        void BindRepList()
        {
            pagesize = 10;
            if (!int.TryParse(Request.Params["page"], out page))
            {
                page = 0;
            }
            pcount = bll.GetRecordCount("");
            repList.DataSource = bll.GetListByPage("", "Id asc", pagesize * page + 1, pagesize * page + pagesize);
            repList.DataBind();

        }


    }
}