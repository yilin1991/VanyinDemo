using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace WechatVanyin
{
    public partial class design_template : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.DesignTemplate bll = new Vanyin.BLL.DesignTemplate();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("design.aspx");

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.Params["type"]))
                {
                    Response.Redirect("design.aspx");
                }
                else
                {
                    BindTemplateList();
                }
            }
        }


        /// <summary>
        /// 绑定模版列表
        /// </summary>
        void BindTemplateList()
        {
            repTemplate.DataSource = bll.GetList(0, "StateInfo=1 and TypeId="+int.Parse(Request.Params["type"]), "SortNum desc,Id desc");
            repTemplate.DataBind();
        }



        public string GetTemplateKey(string strkey)
        {
            StringBuilder strHtml = new StringBuilder();

            string[] strKeylist = strkey.Split('|');
            for (int i = 0; i < strKeylist.Length; i++)
            {
                strHtml.Append("<span>");
                strHtml.Append(strKeylist[i]);
                strHtml.Append("</span>");
            }

            return strHtml.ToString();

        }



    }
}