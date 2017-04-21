using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.Template
{
    public partial class Edit : Vanyin.Web.UI.ManagePage
    {

        Vanyin.BLL.DesignTemplate bll = new Vanyin.BLL.DesignTemplate();
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(10001, ddlType, true);

                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }


        void BindDetail(int id)
        {
            Vanyin.Model.DesignTemplate model = bll.GetModel(id);
            ddlType.SelectedValue = model.TypeId.ToString();
            txtCycle.Text = model.Cycle;
            txtDesignExplain.Text = model.DesignRemark;
            txtDesignTools.Text = model.Tools;
            txtDetailRemark.Text = model.DetailRemark;
            txtImg.Text = model.ImgUrl;
            txtIndexImg.Text = model.IndexImg;
            txtKey.Text = model.StrKey;
            txtPrice.Text = model.Price;
            txtPrintExplain.Text = model.PrintRemark;
            txtSortNum.Text = model.SortNum.ToString();
            txtSubTitle.Text = model.SubTitle;
            txtTitle.Text = model.Title;
            ckHot.Checked = model.IsHot == 1 ? true : false;
            ckIndex.Checked = model.IsIndex == 1 ? true : false;
            ckRec.Checked = model.IsRec == 1 ? true : false;
            ckState.Checked = model.StateInfo == 1 ? true : false;

        }



        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.DesignTemplate model = new Vanyin.Model.DesignTemplate();
            bool ifEdit = false;
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                model = bll.GetModel(int.Parse(Request.Params["id"]));
                ifEdit = true;
            }
            else
            {
                model.Num = GetNumId(DateTime.Now);
                model.AddTime = DateTime.Now;
            }

            model.Cycle = txtCycle.Text;
            model.DesignRemark = txtDesignExplain.Text;
            model.DetailRemark = txtDetailRemark.Text;
            model.ImgUrl = txtImg.Text;
            model.IsHot = ckHot.Checked ? 1 : 0;
            model.IsIndex = ckIndex.Checked ? 1 : 0;
            model.IsRec = ckRec.Checked ? 1 : 0;
            model.IndexImg = txtIndexImg.Text;
            model.Price = txtPrice.Text;
            model.PrintRemark = txtPrintExplain.Text;
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.StrKey = txtKey.Text;
            model.SubTitle = txtSubTitle.Text;
            model.Title = txtTitle.Text;
            model.Tools = txtDesignTools.Text;
            model.TypeId = int.Parse(ddlType.SelectedValue);

            if (ifEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("success", "设计模版编辑成功", 1000, "index.aspx"+Request.Url.Query);
                }
                else
                {
                    JsMessage("error", "设计模版编辑失败", 1000, "back");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("success", "设计模版添加成功", 1000, "index.aspx");
                }
                else
                {
                    JsMessage("error", "设计模版添加失败", 1000, "back");
                }
            }




        }
    }
}