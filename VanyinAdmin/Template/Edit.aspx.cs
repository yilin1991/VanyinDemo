using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.Template
{
    public partial class Edit :Vanyin.Web.UI.ManagePage
    {

        Vanyin.BLL.DesignTemplate bll = new Vanyin.BLL.DesignTemplate();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(10001, ddlType, true);

            }
        }




        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.DesignTemplate model = new Vanyin.Model.DesignTemplate();

            model.AddTime = DateTime.Now;
            model.Cycle = txtCycle.Text;
            model.DesignRemark = txtDesignExplain.Text;
            model.DetailRemark = txtDetailRemark.Text;
            model.ImgUrl = txtImg.Text;
            model.IsHot = ckHot.Checked ? 1 : 0;
            model.IsIndex = ckIndex.Checked ? 1 : 0;
            model.IsRec = ckRec.Checked ? 1 : 0;
            model.Num = GetNumId(DateTime.Now);
            model.Price = txtPrice.Text;
            model.PrintRemark = txtPrintExplain.Text;
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.StrKey = txtKey.Text;
            model.SubTitle = txtSubTitle.Text;
            model.Title = txtTitle.Text;
            model.Tools = txtDesignTools.Text;
            model.TypeId = int.Parse(ddlType.SelectedValue);


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