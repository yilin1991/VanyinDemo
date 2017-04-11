using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.Category
{
    public partial class index : System.Web.UI.Page
    {
        Vanyin.BLL.Category bll = new Vanyin.BLL.Category();
        public string namenull = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepList(0);

            }
        }


        /// <summary>
        /// 绑定类别列表
        /// </summary>
        void BindRepList(int parentId)
        {
            DataTable dt= bll.GetListChild(parentId);

            repList.DataSource = dt;
         
            repList.DataBind();
        }

        protected void repList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal LitFirst = (Literal)e.Item.FindControl("LitFirst");
                HiddenField txtClassLayer = (HiddenField)e.Item.FindControl("txtClassLayer");
                string LitStyle = "<span style=padding-left:{0}px;display:inline-block;>{1}</span>";
               

                int classLayer = Convert.ToInt32(txtClassLayer.Value);
                if (classLayer == 0)
                {
                    LitFirst.Text = "";
                }
                else
                {
                    LitFirst.Text = string.Format(LitStyle, classLayer * 18, "|--");
                }
            }
        }
    }
}