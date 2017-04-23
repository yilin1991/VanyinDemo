using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Vanyin.Common;

namespace Vanyin.Web.UI
{
    public class BasePage:System.Web.UI.Page
    {
        /// <summary>
        /// 绑定下拉列表类别
        /// </summary>
        public void BindddlType(int PID, DropDownList ddl, bool state = false)
        {

            Vanyin.BLL.Category bll = new BLL.Category();
            Model.Category model = new Model.Category();

            int typelevel = 0;

            if (PID != 0)
            {
                model = bll.GetModel(PID);
                typelevel = model.LevelNum + 1;
            }


            DataTable dt = bll.GetListChild(PID, state);
            foreach (DataRow item in dt.Rows)
            {
                string value = item["Id"].ToString();
                int levelNum = int.Parse(item["LevelNum"].ToString()) - typelevel;
                string title = item["Title"].ToString();

                if (levelNum > 0)
                {
                    title = "|--" + title;
                    title = Utils.StringOfChar(levelNum, "　") + title;
                }

                ddl.Items.Add(new ListItem(title, value));
            }

        }


        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string GetNumId(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks);
            return t.ToString().PadRight(18, '0');
        }


        /// <summary>
        /// 获取类别名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCategoryName(int id)
        {
            BLL.Category bll = new BLL.Category();

            Model.Category model = bll.GetModel(id);


            if (model != null)
            {
                return model.Title;
            }
            else
            {
                return "未找到";
            }

        }


        /// <summary>
        /// 验证是否登录
        /// </summary>
        public void CheckLogin(string backurl)
        {
            if (string.IsNullOrEmpty(Vanyin.Common.Utils.GetCookie("MemberId")))
            {
                Vanyin.Common.Utils.WriteCookie("BackUrl", backurl);
                Response.Redirect("Login.aspx");
            }
            else
            {
                Vanyin.Common.Utils.WriteCookie("BackUrl", "",-1440);
            }

        }



        /// <summary>
        /// 获取设计和印刷订单状态
        /// </summary>
        /// <returns></returns>
        public string GetStateName(string state)
        {
            string strStateName = "";

            switch (state)
            {
                case "0":
                    strStateName = "待确认";
                    break;
                case "1":
                    strStateName = "设计中";
                    break;
                case "2":
                    strStateName = "配送中";
                    break;
                case "3":
                    strStateName = "已完成";
                    break;

                case "5":
                    strStateName = "已取消";
                    break;
            }

            return strStateName;

        }


        /// <summary>
        /// 获取文件服务器地址
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public string GetFileServer(int sid)
        {
            Vanyin.BLL.SystemInfo bll = new BLL.SystemInfo();
            Vanyin.Model.SystemInfo model = bll.GetModel(sid);
            return model.FileServer;
        }

        /// <summary>
        /// 获取城市名称
        /// </summary>
        /// <param name="strcity"></param>
        /// <returns></returns>
        public string GetCityName(string strcity)
        {
            Vanyin.BLL.S_Province bllProvince = new Vanyin.BLL.S_Province();
            Vanyin.BLL.S_City bllCity = new Vanyin.BLL.S_City();
            Vanyin.BLL.S_District bllDistrict = new Vanyin.BLL.S_District();
            string[] strList = strcity.Split('-');

            return bllProvince.GetModel(long.Parse(strList[0])).ProvinceName + bllCity.GetModel(long.Parse(strList[1])).CityName + bllDistrict.GetModel(long.Parse(strList[2])).DistrictName;




        }

    }
}
