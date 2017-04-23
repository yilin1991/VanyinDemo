using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.Technology
{
    public partial class Edit : Vanyin.Web.UI.ManagePage
    {
        Vanyin.BLL.Technology bll = new Vanyin.BLL.Technology();
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(10040, ddlType);
                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }


        /// <summary>
        /// 绑定工艺材质详细信息
        /// </summary>
        void BindDetail(int id)
        {
            Vanyin.Model.Technology model = bll.GetModel(id);

            txtDescribe.Text = model.Describe;
            txtExplain.Text = model.Explain;
            txtImg.Text = model.ImgUrl;
            txtTitle.Text = model.Title;
            ckState.Checked = model.StateInfo == 1 ? true : false;
            ckHot.Checked = model.IsHot == 1 ? true : false;
            ckIndex.Checked = model.IsIndex == 1 ? true : false;
            ckRec.Checked = model.IsRec == 1 ? true : false;
            ddlType.SelectedValue = model.TypeId.ToString();
        }

        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.Technology model = new Vanyin.Model.Technology();

            bool ifEdit = false;

            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                ifEdit = true;
            }
            else
            {
                model.NumId = GetNumId(DateTime.Now);
            }


            model.Describe = txtDescribe.Text;
            model.Explain = txtExplain.Text;
            model.ImgUrl = txtImg.Text;
            model.IsHot = ckHot.Checked ? 1 : 0;
            model.IsIndex = ckIndex.Checked ? 1 : 0;
            model.IsRec = ckRec.Checked ? 1 : 0;
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.Title = txtTitle.Text;
            model.TypeId = int.Parse(ddlType.SelectedValue);

            if (ifEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("success", "工艺材质信息编辑成功", 1000, "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("success", "工艺材质信息编辑失败", 1000, "back");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("success", "工艺材质添加成功", 1000, "index.aspx");
                }
                else
                {
                    JsMessage("success", "工艺材质添加失败", 1000, "back");
                }
            }
        }
    }
}