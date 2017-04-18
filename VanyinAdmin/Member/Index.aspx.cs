using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace VanyinAdmin.Member
{
    public partial class Index : Vanyin.Web.UI.ManagePage
    {
        Vanyin.BLL.Member bll = new Vanyin.BLL.Member();
        public int pagesize;
        public int page;
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
        /// 绑定会员列表
        /// </summary>
        void BindRepList()
        {
            StringBuilder strWhere = new StringBuilder("1=1");

            if (!string.IsNullOrEmpty(Request.Params["type"]) && !string.Equals(Request.Params["type"], "0"))
            {
                strWhere.Append(" and TypeId=" + Request.Params["type"]);
                ddlType.SelectedValue = Request.Params["type"];
                strUrl.Append("&type=" + Request.Params["type"]);
            }
            if (!string.IsNullOrEmpty(Request.Params["state"]) && !string.Equals(Request.Params["state"], "0"))
            {
                switch (Request.Params["state"])
                {
                    case "1":
                        strWhere.Append(" and StateInfo=1");
                        break;
                    case "2":
                        strWhere.Append(" and StateInfo=0");
                        break;
                }

                ddlState.SelectedValue = Request.Params["state"];
                strUrl.Append("&state=" + Request.Params["state"]);
            }
            if (!string.IsNullOrEmpty(Request.Params["key"]))
            {

                strWhere.Append(" and (NameInfo like '%" + Request.Params["key"] + "%' or Account like '%"+Request.Params["key"]+"%' or Phone='"+Request.Params["key"]+"')");

                txtkey.Text = Request.Params["key"];
                strUrl.Append("&key=" + Request.Params["key"]);
            }

            pagesize = 10;
            if (!int.TryParse(Request.Params["page"], out page))
            {
                page = 0;
            }
            pcount = bll.GetRecordCount(strWhere.ToString());
            repList.DataSource = bll.GetListByPage(strWhere.ToString(), "AddTime desc,Id desc", pagesize * page + 1, pagesize * page + pagesize);
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
        /// 修改状态
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField lbId = e.Item.FindControl("lbId") as HiddenField;
            Vanyin.Model.Member model = bll.GetModel(int.Parse(lbId.Value));
            if (e.CommandName == "lbtnState")
            {
                model.StateInfo = model.StateInfo == 1 ? 0 : 1;
            }
            bll.Update(model);
            BindRepList();
        }
    }
}