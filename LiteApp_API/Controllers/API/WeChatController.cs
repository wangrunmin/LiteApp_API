using LiteApp_API.DB;
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
        /// <summary>
        /// 微信登录使用code换取OpenID及SessionKey
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetSession(string code)
        {
            string appid = ConfigurationManager.AppSettings["appid"].ToString();
            string appsecret = ConfigurationManager.AppSettings["appsecret"].ToString();
            string wxUrl = "https://api.weixin.qq.com/sns/jscode2session?appid=";
            var responseJson = new HttpClient().GetAsync(wxUrl + appid + "&secret=" + appsecret
                + "&js_code=" + code + "&grant_type=authorization_code")
                .Result.Content.ReadAsStringAsync().Result;
            var entJson = new JavaScriptSerializer().Deserialize<WXData>(responseJson);
            try
            {
                using (var ctx = new APIContextDataContext())
                {
                    if (!string.IsNullOrEmpty(entJson.openid))
                    {
                        var olduser = ctx.Users.Where(m => m.WX_OpenID == entJson.openid).FirstOrDefault();
                        if (olduser == null)
                        {
                            var user = new Users() { WX_OpenID = entJson.openid };
                            ctx.Users.InsertOnSubmit(user);
                            ctx.SubmitChanges();
                            using (var ctx2 = new APIContextDataContext())
                            {
                                var newUser = ctx2.Users.Where(m => m.WX_OpenID == entJson.openid).Select(m => new
                                {
                                    id = m.Id,
                                    xingming = m.XingMing,
                                    shoujih = m.ShouJiH,
                                    gongzhong = m.GongZhong
                                }).First();
                                return JsonConvert.SerializeObject(new
                                {
                                    res = newUser,
                                    msg = "新用户"
                                });
                            }
                        }
                        else if (string.IsNullOrEmpty(olduser.XingMing))
                        {
                            using (var ctx2 = new APIContextDataContext())
                            {
                                var newUser = ctx2.Users.Where(m => m.WX_OpenID == entJson.openid).Select(m => new
                                {
                                    id = m.Id,
                                    xingming = m.XingMing,
                                    shoujih = m.ShouJiH,
                                    gongzhong = m.GongZhong
                                }).First();
                                return JsonConvert.SerializeObject(new
                                {
                                    res = newUser,
                                    msg = "新用户"
                                });
                            }
                        }
                        else
                        {
                            using (var ctx2 = new APIContextDataContext())
                            {
                                var newUser = ctx2.Users.Where(m => m.WX_OpenID == entJson.openid).Select(m => new
                                {
                                    id = m.Id,
                                    xingming = m.XingMing,
                                    shoujih = m.ShouJiH,
                                    gongzhong = m.GongZhong
                                }).First();
                                return JsonConvert.SerializeObject(new
                                {
                                    res = newUser,
                                    msg = "老用户"
                                });
                            }
                        }
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
