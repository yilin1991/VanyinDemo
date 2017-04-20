using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class DesignOrderDetail : Vanyin.Web.UI.BasePage
    {

        Vanyin.BLL.DesignOrder bll = new Vanyin.BLL.DesignOrder();
        Vanyin.BLL.DesignTemplate bllTemplate = new Vanyin.BLL.DesignTemplate();
        public Vanyin.Model.DesignOrder model = new Vanyin.Model.DesignOrder();
        public Vanyin.Model.DesignTemplate modelTemplate = new Vanyin.Model.DesignTemplate();

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("personal-home.aspx");
            if (!IsPostBack)
            {
                BindDetail();
            }
        }


        void BindDetail()
        {
            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                modelTemplate = bllTemplate.GetModel(model.TemplateId);
                if (model.StateInfo == 3 || model.StateInfo == 5)
                {
                    
                    btnOk.CssClass = "btnorderdetailhide";
                }
            }
            else
            {
                Response.Redirect("order-list.aspx");
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.DesignOrder model1 = bll.GetModel(int.Parse(Request.Params["id"]));
            model1.StateInfo = 3;
            bll.Update(model1);
            BindDetail();
        }
    }
}