using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        public string Register(string data)
        {
            try
            {
                var ent = JsonConvert.DeserializeObject<DB.Users>(data);
                using (var ctx = new DB.APIContextDataContext())
                {
                    var emptyUser = ctx.Users.Where(m => m.WX_OpenID == ent.WX_OpenID).First();
                    emptyUser.XingMing = ent.XingMing;
                    emptyUser.ShouJiH = ent.ShouJiH;
                    emptyUser.GongZhong = ent.GongZhong;
                    ctx.SubmitChanges();
                    return JsonConvert.SerializeObject(new
                    {
                        res = "OK",
                        msg = "注册成功"
                    });
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
        public string GetUserList()
        {
            try
            {
                using (var ctx = new DB.APIContextDataContext())
                {
                    return JsonConvert.SerializeObject(ctx.Users.ToList());
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
    }
}