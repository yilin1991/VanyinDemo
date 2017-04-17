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
                BindRepList();
            }
        }


        /// <summary>
        /// 绑定文件列表
        /// </summary>
        void BindRepList()
        {
            StringBuilder strWhere = new StringBuilder("1=1");
            pagesize = 10;
            if (!int.TryParse(Request.Params["page"], out page))
            {
                page = 0;
            }
            pcount = bll.GetRecordCount(strWhere.ToString());
            repList.DataSource = bll.GetListByPage(strWhere.ToString(), "SortNum asc,Id asc", pagesize * page + 1, pagesize * page + pagesize);
            repList.DataBind();

        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx?type=" + ddlType.SelectedValue + "&state=" + ddlState.SelectedValue + "&key=" + txtkey.Text);
        }

        /// <summary>
        /// 显示全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }


        /// <summary>
        /// 修改属性
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField lbId = e.Item.FindControl("lbId") as HiddenField;
            Vanyin.Model.Filetable model = bll.GetModel(int.Parse(lbId.Value));
            if (e.CommandName == "lbtnState")
            {
                model.StateInfo = model.StateInfo == 1 ? 0 : 1;
            }
            bll.Update(model);
            BindRepList();
        }
    }
}