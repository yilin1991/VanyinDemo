using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.FileManage
{
    public partial class Edit : Vanyin.Web.UI.ManagePage
    {
        Vanyin.BLL.Filetable bll = new Vanyin.BLL.Filetable();

        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(10008, ddlType);
                if (int.TryParse(Request.Params["id"], out id))
                {
                    BindDetail(id);
                }
            }


        }


        /// <summary>
        /// 绑定文件详细信息
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            Vanyin.Model.Filetable model = bll.GetModel(id);

            txtImg.Text = model.ImgUrl;
            txtLink.Text = model.LinkUrl;
            txtSortNum.Text = model.SortNum.ToString();
            txtTitle.Text = model.Title;
            ddlType.SelectedValue = model.TypeId.ToString();
            ckHot.Checked = model.IsHot == 1 ? true : false;
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
            Vanyin.Model.Filetable model = new Vanyin.Model.Filetable();

            bool ifEdit = false;

            if (string.IsNullOrEmpty(Request.Params["id"]))
            {
                model.Num = GetNumId(DateTime.Now);
                model.Addtime = DateTime.Now;
            }
            else
            {
                model = bll.GetModel(int.Parse(Request.Params["id"]));
                ifEdit = true;
            }


            model.ImgUrl = txtImg.Text;
            model.IsHot = ckHot.Checked ? 1 : 0;
            model.IsRec = ckRec.Checked ? 1 : 0;
            model.LinkUrl = txtLink.Text;
            model.SortNum = int.Parse(txtSortNum.Text);
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.Title = txtTitle.Text;
            model.TypeId = int.Parse(ddlType.SelectedValue);


            if (ifEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("success", "文件信息编辑成功", 1000, "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("success", "文件信息编辑失败", 1000, "back");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("success", "文件添加成功", 1000, "index.aspx");
                }
                else
                {
                    JsMessage("success", "文件添加失败", 1000, "back");
                }
            }



        }
    }
}