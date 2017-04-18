using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanyinAdmin.Member
{
    public partial class Edit :Vanyin.Web.UI.ManagePage
    {
        Vanyin.BLL.Member bll = new Vanyin.BLL.Member();
        int id;
        public string checkAccount = "/Tools/CheckAccount.ashx";
        public string checkPhone = "/Tools/CheckPhone.ashx";
        public string account = "";
        public string phone = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindddlType(10010, ddlType);
                if (int.TryParse(Request.Params["id"], out id))
                {
                    checkAccount= checkPhone = "";
                   
                    BindDetail(id);
                }
            }
        }


        /// <summary>
        /// 绑定会员详细信息
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            Vanyin.Model.Member model = bll.GetModel(id);
            
            txtEmail.Text = model.Email;
            txtExplain.Text = model.Explain;
            txtImg.Text = model.HeaderImg;
            txtNickname.Text = model.Nickname;
            
            txtPwd.Text = Vanyin.Common.DESEncrypt.Decrypt(model.Pwd);
            ckState.Checked = model.StateInfo == 1 ? true : false;
            ddlType.SelectedValue = model.TypeId.ToString();
            account = model.Account;
            phone = model.Phone;
        }



        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.Member model = new Vanyin.Model.Member();
            bool ifEdit = false;

            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                ifEdit = true;
            }
            else
            {
                model.NumId = GetNumId(DateTime.Now);
                model.AddTime = DateTime.Now;
            }


            model.Account = Request.Form["txtAccount"].ToString();
            model.AddressInfo = "";
            model.Email = txtEmail.Text;
            model.Explain = txtExplain.Text;
            model.HeaderImg = txtImg.Text;
            model.NameInfo = "";
            model.Nickname = txtNickname.Text;
            model.Phone = Request.Form["txtPhone"].ToString();
            model.Pwd = Vanyin.Common.DESEncrypt.Encrypt(txtPwd.Text.Trim());
            model.StateInfo = ckState.Checked ? 1 : 0;
            model.TypeId = int.Parse(ddlType.SelectedValue);

            if (ifEdit)
            {
                if (bll.Update(model))
                {
                    JsMessage("success", "会员信息编辑成功", 1000, "index.aspx" + Request.Url.Query);
                }
                else
                {
                    JsMessage("success", "会员信息编辑失败", 1000, "back");
                }
            }
            else
            {
                if (bll.Add(model) > 0)
                {
                    JsMessage("success", "会员添加成功", 1000, "index.aspx");
                }
                else
                {
                    JsMessage("success", "会员添加失败", 1000, "back");
                }
            }



        }
    }
}