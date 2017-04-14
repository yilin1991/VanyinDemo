using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace VanyinAdmin.FileManage
{
    public partial class Index : Vanyin.Web.UI.ManagePage
    {


        Vanyin.BLL.Filetable bll = new Vanyin.BLL.Filetable();

        public int page;
        public int pagesize;
        public int pcount;

        public StringBuilder strUrl = new StringBuilder();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


        /// <summary>
        /// 绑定文件列表
        /// </summary>
        void BindRepList()
        {

        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 显示全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelectAll_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 修改属性
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}