using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC_API.Controllers
{
    public class WeChatController : Controller
    {
        public string GetSession(string code)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var httpClient = new HttpClient();
            string appid = ConfigurationManager.AppSettings["appid"].ToString();
            string appsecret = ConfigurationManager.AppSettings["appsecret"].ToString();
            var responseJson = httpClient.GetAsync("https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + appsecret + "&js_code=" + code + "&grant_type=authorization_code").Result.Content.ReadAsStringAsync().Result;
            WXData jc = js.Deserialize<WXData>(responseJson);
            try
            {
                using (var ctx = new DB.APIContextDataContext())
                {
                    if (!string.IsNullOrEmpty(jc.openid))
                    {
                        var olduser = ctx.Users.Where(m => m.WX_OpenID == jc.openid);
                        if (olduser == null)
                        {
                            var user = new DB.Users() { WX_OpenID = jc.openid };
                            ctx.Users.InsertOnSubmit(user);
                            ctx.SubmitChanges();
                            return JsonConvert.SerializeObject(new
                            {
                                res = "OK",
                                msg = "新用户"
                            });
                        }
                        return JsonConvert.SerializeObject(new
                        {
                            res = "OK",
                            msg = "老用户"
                        });
                    }
                    else
                    {
                        return JsonConvert.SerializeObject(new
                        {
                            res = "ERROR",
                            msg = "获取OpenID失败"
                        });
                    }
                }
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new
                {
                    res = "ERROR",
                    msg = e.Message
                });
            }

        }

        public class WXData
        {
            public string session_key { get; set; }
            public string expires_in { get; set; }
            public string openid { get; set; }
        }
    }
}
