using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
namespace WechatVanyin
{
    public partial class order_list : Vanyin.Web.UI.BasePage
    {
        Vanyin.BLL.DesignOrder bllDesign = new Vanyin.BLL.DesignOrder();
        Vanyin.BLL.PrintOrder bllPrint = new Vanyin.BLL.PrintOrder();
        Vanyin.BLL.ExchangeOrder bllExchange = new Vanyin.BLL.ExchangeOrder();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("personal-home.aspx");

            if (!IsPostBack)
            {
                BindOrderList();
            }
        }


        void BindOrderList()
        {
            DataTable dtDesign = bllDesign.GetList(0, "MemberId=" + Vanyin.Common.Utils.GetCookie("MemberId"), "AddTime desc").Tables[0];
            DataTable dtPrint = bllPrint.GetList(0, "MemberId=" + Vanyin.Common.Utils.GetCookie("MemberId"), "AddTime desc").Tables[0];
            DataTable dtMall = bllExchange.GetList(0, "Member=" + Vanyin.Common.Utils.GetCookie("MemberId"), "AddTime desc").Tables[0];

            DataTable tblDatas = new DataTable("Datas");
            DataColumn dc = null;
            dc = tblDatas.Columns.Add("OrderId", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("OrderNum", Type.GetType("System.String"));

            dc = tblDatas.Columns.Add("StateStyle", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("TypeStyle", Type.GetType("System.String"));

            dc = tblDatas.Columns.Add("OrderType", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("OrderName", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("OrderState", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("OrderDetail", Type.GetType("System.String"));
            dc = tblDatas.Columns.Add("AddTime", Type.GetType("System.String"));

            DataRow newRow;


            foreach (DataRow item in dtDesign.Rows)
            {
                newRow = tblDatas.NewRow();
                newRow["OrderId"] = item["Id"].ToString();
                newRow["OrderNum"] = item["NumId"].ToString();
                newRow["OrderType"] = "设计";

                newRow["TypeStyle"] = "orderdesign";
                newRow["StateStyle"] = 0;

                newRow["OrderName"] = GetDesignName(item["TemplateId"].ToString());

                newRow["OrderState"] = GetStateName(item["StateInfo"].ToString());

                newRow["OrderDetail"] = "DesignOrderDetail.aspx?id=" + item["Id"].ToString();
                newRow["AddTime"] = item["AddTime"].ToString();

                tblDatas.Rows.Add(newRow);
            }

            foreach (DataRow item in dtPrint.Rows)
            {
                newRow = tblDatas.NewRow();
                newRow["OrderId"] = item["Id"].ToString();
                newRow["OrderNum"] = item["NumId"].ToString();
                newRow["OrderType"] = "印刷";

                newRow["TypeStyle"] = "printdesign";
                newRow["StateStyle"] = 0;


                newRow["OrderName"] = new Vanyin.Web.UI.BasePage().GetCategoryName(int.Parse(item["TypeId"].ToString()));

                newRow["OrderState"] = GetStateName(item["StateInfo"].ToString());



                newRow["OrderDetail"] = "PrintOrderDetail.aspx?id=" + item["Id"].ToString();
                newRow["AddTime"] = item["AddTime"].ToString();

                tblDatas.Rows.Add(newRow);
            }

            tblDatas.DefaultView.Sort = "AddTime desc";



            RepOrderList.DataSource = tblDatas;
            RepOrderList.DataBind();

        }


        public string GetDesignName(string tid)
        {
            Vanyin.BLL.DesignTemplate bllTemplate = new Vanyin.BLL.DesignTemplate();

            Vanyin.Model.DesignTemplate model = bllTemplate.GetModel(int.Parse(tid));

            if (model == null)
            {
                return "未知模版";
            }
            else
            {
                return model.Title;
            }


        }




    }
}