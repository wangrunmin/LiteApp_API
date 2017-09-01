using LiteApp_API.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 保存和修改用户数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Save(string data)
        {
            try
            {
                using (var ctx = new APIContextDataContext())
                {
                    var ent = JsonConvert.DeserializeObject<Users>(data);
                    bool update = ent.Id == 0 ? false : true;
                    if (update)
                    {
                        var oldUser = ctx.Users.Where(m => m.Id == ent.Id).First();
                        oldUser.XingMing = ent.XingMing;
                        oldUser.ShouJiH = ent.ShouJiH;
                        oldUser.GongZhong = ent.GongZhong;
                        ctx.SubmitChanges();
                        return JsonConvert.SerializeObject(new
                        {
                            res = "OK",
                            msg = "修改用户信息成功"
                        });
                    }
                    else
                    {

                        var emptyUser = ctx.Users.Where(m => m.Id == ent.Id).First();
                        emptyUser.XingMing = ent.XingMing;
                        emptyUser.ShouJiH = ent.ShouJiH;
                        emptyUser.GongZhong = ent.GongZhong;
                        ctx.SubmitChanges();
                        return JsonConvert.SerializeObject(new
                        {
                            res = "OK",
                            msg = "绑定微信成功"
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
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public string QueryList(string search, int page, int rows)
        {
            try
            {
                var entSearch = JsonConvert.DeserializeObject<Users>(search);
                using (var ctx = new APIContextDataContext())
                {
                    var query = ctx.Users.AsQueryable();
                    if (!string.IsNullOrEmpty(entSearch.Id.ToString()))
                    {
                        query = query.Where(m => m.Id == entSearch.Id);
                    }
                    if (!string.IsNullOrEmpty(entSearch.WX_OpenID))
                    {
                        query = query.Where(m => m.WX_OpenID == entSearch.WX_OpenID);
                    }
                    if (!string.IsNullOrEmpty(entSearch.XingMing))
                    {
                        query = query.Where(m => m.XingMing == entSearch.XingMing);
                    }
                    if (!string.IsNullOrEmpty(entSearch.ShouJiH))
                    {
                        query = query.Where(m => m.ShouJiH == entSearch.ShouJiH);
                    }
                    if (!string.IsNullOrEmpty(entSearch.GongZhong))
                    {
                        query = query.Where(m => m.GongZhong == entSearch.GongZhong);
                    }
                    return JsonConvert.SerializeObject(new
                    {
                        total = query.Count(),
                        rows = query.Skip((page - 1) * rows).Take(rows).ToList()
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
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string DelByID(int ID)
        {
            try
            {
                using (var ctx = new APIContextDataContext())
                {
                    var del = ctx.Users.Where(m => m.Id == ID).First();
                    ctx.Users.DeleteOnSubmit(del);
                    ctx.SubmitChanges();
                    return JsonConvert.SerializeObject(new
                    {
                        Result = "OK",
                        Msg = "用户已删除"
                    });
                }
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject(new
                {
                    Result = "ERROR",
                    Msg = e.Message
                });
            }
        }
    }
}