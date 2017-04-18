using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Vanyin.Common;

namespace Vanyin.Web.UI
{
    public class ManagePage : Vanyin.Web.UI.BasePage
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


      


        



    }
}
