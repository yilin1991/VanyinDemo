﻿using System;
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



    }
}
