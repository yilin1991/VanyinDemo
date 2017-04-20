using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.SystemInfo
{
    public partial class Edit : Vanyin.Web.UI.ManagePage
    {
        Vanyin.BLL.SystemInfo bll = new Vanyin.BLL.SystemInfo();
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }

        /// <summary>
        /// 绑定系统设置详情
        /// </summary>
        void BindDetail(int id)
        {
            Vanyin.Model.SystemInfo model = bll.GetModel(id);

            txtCopyright.Text = model.WebCopyright;
            txtFileServer.Text = model.FileServer;
            txtIcp.Text = model.WebICP;
            txtTitle.Text = model.Title;
            txtWebDescribe.Text = model.WebDescribe;
            txtWebName.Text = model.WebName;
            txtWebtKey.Text = model.WebKey;
            txtWebUrl.Text = model.WebUrl;         
        }



        /// <summary>
        /// 信息提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.SystemInfo model = new Vanyin.Model.SystemInfo();
            bool ifEdit = false;

            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                ifEdit = true;
            }


            model.FileServer = txtFileServer.Text;
            model.Title = txtTitle.Text;
            model.WebCopyright = txtCopyright.Text;
            model.WebDescribe = txtWebDescribe.Text;
            model.WebICP = txtIcp.Text;
            model.WebKey = txtWebtKey.Text;
            model.WebName = txtWebName.Text;
            model.WebUrl = txtWebUrl.Text;

            if (ifEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("success", "系统信息编辑成功", 1000, "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("success", "系统信息编辑失败", 1000, "back");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("success", "系统信息添加成功", 1000, "index.aspx");
                }
                else
                {
                    JsMessage("success", "系统信息添加失败", 1000, "back");
                }
            }

        }
    }
}