using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Vanyin.Common;

namespace VanyinAdmin.Category
{
    public partial class Edit : Vanyin.Web.UI.ManagePage
    {
        Vanyin.BLL.Category bll = new Vanyin.BLL.Category();

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(0, ddlParentType);

                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
                if (!string.IsNullOrEmpty(Request.Params["pid"]))
                {
                    ddlParentType.SelectedValue = Request.Params["pid"];
                }

            }
        }

        /// <summary>
        /// 绑定类别详情
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            Vanyin.Model.Category model = bll.GetModel(id);

            ddlParentType.SelectedValue = model.ParentId.ToString();
            txtdefaultimg.Text = model.DefaultImgUrl;
            txtExplain.Text = model.Explain;
            txtSortNum.Text = model.SortNum.ToString();
            txtSubTitle.Text = model.SubTitle.ToString();
            txtTitle.Text = model.Title;
            txtTypeImg.Text = model.ImgUrl;
            ckState.Checked = model.StateInfo == 1 ? true : false;

        }





        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.Category model = new Vanyin.Model.Category();

            bool ifEdit = false;
            if (string.IsNullOrWhiteSpace(Request.Params["id"]))
            {
                model.NumId = GetNumId(DateTime.Now).ToString().PadRight(18, '0');
            }
            else
            {
                model = bll.GetModel(int.Parse(Request.Params["id"]));
                ifEdit = true;
            }

            model.DefaultImgUrl = txtdefaultimg.Text;
            model.Explain = txtExplain.Text;
            model.ImgUrl = txtTypeImg.Text;
            if (ddlParentType.SelectedValue == "0")
            {
                model.LevelNum = 0;
            }
            else
            {
                model.LevelNum = bll.GetModel(int.Parse(ddlParentType.SelectedValue)).LevelNum + 1;
            }

            model.ParentId = int.Parse(ddlParentType.SelectedValue);
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.SubTitle = txtSubTitle.Text;
            model.Title = txtTitle.Text;

            if (ifEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("success", "类别编辑成功", 1000, "index.aspx");
                }
                else
                {
                    JsMessage("success", "类别编辑失败", 1000, "back");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("success", "类别添加成功", 1000, "index.aspx");
                }
                else
                {
                    JsMessage("success", "类别添加失败", 1000, "back");
                }
            }
        }




    }
}