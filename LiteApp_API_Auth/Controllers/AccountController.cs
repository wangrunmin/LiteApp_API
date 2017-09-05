using LiteApp_API_Auth.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteApp_API_Auth.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public string Login(string username, string password)
        {
            try
            {
                //进行数据处理,可能包括非法字符判断或者解密之类的
                var _username = username.Trim();
                var _password = password.Trim();
                using (var ctx = new SessionContext())
                {
                    //判断账号
                    var user = ctx.Users.Where(m => m.Name == _username).FirstOrDefault();
                    if (user != null)
                    {
                        //省略判断密码
                        var session = new Session()
                        {
                            SessionId = Guid.NewGuid().ToString(),
                            UserId = user.Id,
                            CreateTime = DateTime.Now,
                            ExpireTime = DateTime.Now.AddHours(1)
                        };
                        ctx.Sessions.Add(session);
                        ctx.SaveChanges();
                        return JsonConvert.SerializeObject(session);
                    }
                    else
                    {
                        throw new Exception("账号不存在");
                    }
                }
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(e.Message);
            }
        }
    }
}