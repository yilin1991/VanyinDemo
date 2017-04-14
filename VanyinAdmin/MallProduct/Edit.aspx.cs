using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.MallProduct
{
    public partial class Edit : Vanyin.Web.UI.ManagePage
    {
        Vanyin.BLL.ProductMall bll = new Vanyin.BLL.ProductMall();

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(10006,ddlType);

                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }
        }


        /// <summary>
        /// 绑定详细信息
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            Vanyin.Model.ProductMall model = bll.GetModel(id);
            txtImg.Text = model.ImgUrl;
            txtIntegral.Text = model.Integral.ToString();
            txtMallDetail.Text = model.Remark;
            txtPrice.Text = model.Price;
            txtSortNum.Text = model.SortNum.ToString();
            txtStock.Text = model.Stock.ToString();
            txtTitle.Text = model.NameInfo;
            ddlType.SelectedValue = model.MallType.ToString();
            ckState.Checked = model.StateInfo == 1 ? true : false;


        }


        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.ProductMall model = new Vanyin.Model.ProductMall();

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

            model.Attribute = "";
            model.ImgUrl = txtImg.Text;
            model.Integral = int.Parse(txtIntegral.Text);
            model.MallType = int.Parse(ddlType.SelectedValue);
            model.NameInfo = txtTitle.Text;
            model.Price = txtPrice.Text;
            model.Remark = txtMallDetail.Text;
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.Stock = int.Parse(txtStock.Text);

            if (ifEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("success", "兑换商品编辑成功", 1000, "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("success", "兑换商品编辑失败", 1000, "back");
                }
            }
            else
            {
                if (bll.Add(model)>0)
                {
                    JsMessage("success", "兑换商品添加成功", 1000, "index.aspx");
                }
                else
                {
                    JsMessage("success", "兑换商品添加失败", 1000, "back");
                }
            }


        }
    }
}