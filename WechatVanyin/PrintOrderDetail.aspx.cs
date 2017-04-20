using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class PrintOrderDetail : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.PrintOrder bll = new Vanyin.BLL.PrintOrder();
      
        public Vanyin.Model.PrintOrder model = new Vanyin.Model.PrintOrder();
        public string strbtnhide;

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("personal-home.aspx");
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Vanyin.Model.PrintOrder model1 = bll.GetModel(int.Parse(Request.Params["id"]));


            model1.StateInfo = 3;

            bll.Update(model1);
            BindDetail();

        }



        void BindDetail()
        {
            if (int.TryParse(Request.Params["id"], out id))
            {
                model = bll.GetModel(id);
                if (model.StateInfo == 3 || model.StateInfo == 5)
                {
                    strbtnhide = "btnorderdetailhide";
                    btnOk.CssClass = "btnorderdetailhide";
                }
            }
            else
            {
                Response.Redirect("order-list.aspx");
            }
        }


    }
}