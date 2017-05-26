using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using WeChatAPI.Model;
using System.Web.Script.Serialization;
using WeChatAPI.Helpers;
using System.Net;

namespace WeChatAPI
{
   public class WeChaMethod
    {

        private SimpleCacheProvider _cache;
        const string CACHE_ACCESS_TOKEN = "CACHE_ACCESS_TOKEN";

        /// <summary>
        /// 第三方用户唯一凭证
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 第三方用户唯一凭证密钥，即appsecret
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 全局唯一票据
        /// </summary>
        public string Access_Token { get; set; }


        /// <summary>
        /// 微信操作时必须初始化的
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="secret"></param>
        public WeChaMethod(string appId, string secret)
        {
            AppId = appId;
            Secret = secret;
        }

        /// <summary>
        /// access_token是公众号的全局唯一票据，公众号调用各接口时都需使用access_token。正常情况下access_token有效期为7200秒，重复获取将导致上次获取的access_token失效。由于获取access_token的api调用次数非常有限，建议开发者全局存储与更新access_token，频繁刷新access_token会导致api调用受限，影响自身业务。
        /// </summary>
        /// <param name="appid">第三方用户唯一凭证</param>
        /// <param name="secret">第三方用户唯一凭证密钥，即appsecret</param>
        /// <returns></returns>
        public AccessToken GetAccessToken()
        {
            //格式化请求字符串
            string url = string.Format(UrlHelper.GetAccessToken, AppId, Secret);
            //获取返回结果
            string accessToken = HttpHelper.Get(url);

            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<AccessToken>(accessToken);

        }



        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        public string AccessToken()
        {

            var token = _cache.GetCache(CACHE_ACCESS_TOKEN);
            if (token != null)
                return token.ToString();
            try
            {
                string result = HttpGet(string.Format(CACHE_ACCESS_TOKEN, this.AppId, this.Secret));
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Dictionary<string, object> jsonObj = serializer.Deserialize<dynamic>(result);
                if (jsonObj.ContainsKey("access_token"))
                {
                    token = jsonObj["access_token"].ToString();
                    this._cache.SetCache(CACHE_ACCESS_TOKEN, token.ToString(), 7000);
                }
                else
                {
                    //为了程序正常运行，不抛出错误，可以记录日志
                    token = jsonObj["errmsg"];
                }
            }
            catch
            {
                //为了程序正常运行，不抛出错误，可以记录日志
                token = "there_is_an_error_when_getting_token";
            }
            
            return token.ToString();



        }

        /// <summary>
        /// 后台发起http请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <returns>请求结果字符串</returns>
        private string HttpGet(string url)
        {
            return new WebClient().DownloadString(url);
        }



        #region 消息管理

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <returns></returns>
        public ErrorMessage SendTextMessage(string openId, string content)
        {
            string messageContent = "{\"touser\":\"" + openId + "\",\"msgtype\":\"text\",\"text\":{\"content\":\"" + content + "\"}}";
            string returnMessage = HttpHelper.Post(messageContent, string.Format(UrlHelper.SendMessage, Access_Token));
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<ErrorMessage>(returnMessage);
        }

        #endregion



        #region 用户管理
        /// <summary>
        /// 获取用户基本信息
        /// </summary> 
        /// <param name="openid">普通用户的标识，对当前公众号唯一</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <returns></returns>
        public string GetUserInfo(string openid, string lang = "ch_CN")
        {
            string url = string.Format(UrlHelper.GetUserInfoToken, Access_Token, openid, lang);
            return HttpHelper.Get(url);
        }


        /// <summary>
        /// 检测该用户是否关注了本公众号
        /// </summary>
        /// <param name="openId">openId对当前公众号唯一</param>
        /// <returns></returns>
        public bool CheckFocus(string openId)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            UserInfo model = js.Deserialize<UserInfo>(GetUserInfo(openId));

            if (model.subscribe == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获取关注者列表
        /// </summary>
        /// <param name="next_openid"></param>
        /// <returns></returns>
        public string GetFocusUsers(string next_openid = "")
        {
            string url = string.Format(UrlHelper.GetFocusUsers, Access_Token, next_openid);
            return HttpHelper.Get(url);
        }


        /// <summary>
        /// 获取用户的性别
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public string GetUserSex(string sex)
        {

            string strSex = string.Empty;
            switch (sex)
            {
                case "0":
                    strSex = "未知";
                    break;
                case "1":
                    strSex = "男";
                    break;
                case "2":
                    strSex = "女";
                    break;
            }

            return strSex;



        }


        #endregion



    }
}
