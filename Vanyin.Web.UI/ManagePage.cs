using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Vanyin.Common;

namespace Vanyin.Web.UI
{
    public class ManagePage : System.Web.UI.Page
    {

        /// <summary>
        /// 弹出提示框
        /// </summary>
        public void JsMessage(string state, string text, int endTime, string linkUrl)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "ShowMessage(\"" + state + "\",\"" + text + "\"," + endTime + ",\"" + linkUrl + "\")\n";
            msbox += "</script>\n";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "JsPrint", msbox);
        }


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
                int levelNum = int.Parse(item["LevelNum"].ToString())-typelevel;
                string title = item["Title"].ToString();

                if (levelNum>0)
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


    }
}
