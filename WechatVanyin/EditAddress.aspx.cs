using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WechatVanyin
{
    public partial class EditAddress : Vanyin.Web.UI.BasePage
    {

        Vanyin.BLL.S_Province bllProvince = new Vanyin.BLL.S_Province();
        Vanyin.BLL.S_District bllDistrict = new Vanyin.BLL.S_District();
        Vanyin.BLL.S_City bllCity = new Vanyin.BLL.S_City();
        Vanyin.BLL.Address bllAddress = new Vanyin.BLL.Address();
        int id;




        public Vanyin.Model.Address model = new Vanyin.Model.Address();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin("Address.aspx");

            if (!IsPostBack)
            {
                BindProvince();
                if (int.TryParse(Request.Params["Id"], out id))
                {
                    BindDetail(id);
                }

            }
        }

        /// <summary>
        /// 绑定省份
        /// </summary>
        void BindProvince()
        {
            RepProvince.DataSource = bllProvince.GetList(0, "", "ProvinceID asc");
            RepProvince.DataBind();
        }


        /// <summary>
        /// 绑定收货信息详细
        /// </summary>
        /// <param name="id"></param>
        void BindDetail(int id)
        {
            model = bllAddress.GetModel(id);

            string[] strCityList = model.City.Split('-');

            RepCity.DataSource = bllCity.GetList("ProvinceID=" + strCityList[0]);
            RepCity.DataBind();


            RepDistrict.DataSource = bllDistrict.GetList("CityId=" + strCityList[1]);
            RepDistrict.DataBind();

        }



    }
}