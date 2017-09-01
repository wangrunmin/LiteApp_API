using LiteApp_API.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_API.Controllers
{
    public class EntryController : Controller
    {
        public class searchEntity
        {
            public string Id { get; set; }
            public string UserId { get; set; }
            public string WX_OpenID { get; set; }
            public string Date { get; set; }
            public string LiuShuiH { get; set; }
            public string ChiMa { get; set; }
            public string ShiShu { get; set; }
            public string BeiZhu { get; set; }
        }
        /// <summary>
        /// 保存和修改单条记货记录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Save(string data)
        {
            try
            {
                using (var ctx = new APIContextDataContext())
                {
                    var ent = JsonConvert.DeserializeObject<Entries>(data);
                    bool update = ent.Id == 0 ? false : true;
                    if (update)
                    {
                        var oldEnt = ctx.Entries.Where(m => m.Id == ent.Id).First();
                        //oldEnt.Id = ent.Id;
                        //oldEnt.UserId = ent.UserId;
                        oldEnt.Date = ent.Date;
                        oldEnt.LiuShuiH = ent.LiuShuiH;
                        oldEnt.ChiMa = ent.ChiMa;
                        oldEnt.ShiShu = ent.ShiShu;
                        oldEnt.BeiZhu = ent.BeiZhu;
                        return JsonConvert.SerializeObject(new
                        {
                            res = "OK",
                            msg = "修改成功"
                        });
                    }
                    else
                    {

                        if (string.IsNullOrEmpty(ent.UserId.ToString()) ||
                            string.IsNullOrEmpty(ent.Date) ||
                            string.IsNullOrEmpty(ent.LiuShuiH) ||
                            string.IsNullOrEmpty(ent.ShiShu))
                        {
                            return JsonConvert.SerializeObject(new
                            {
                                res = "FAILD",
                                msg = "保存失败," + JsonConvert.SerializeObject(ent)
                            });
                        }
                        ctx.Entries.InsertOnSubmit(ent);
                        ctx.SubmitChanges();
                        return JsonConvert.SerializeObject(new
                        {
                            res = "OK",
                            msg = "保存成功"
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
        /// 查询记货记录
        /// </summary>
        /// <param name="search"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public string QueryList(string search, int page, int rows)
        {
            try
            {
                var entSearch = JsonConvert.DeserializeObject<searchEntity>(search);
                using (var ctx = new APIContextDataContext())
                {
                    var query = ctx.Entries.AsQueryable();
                    if (!string.IsNullOrEmpty(entSearch.Id))
                    {
                        query = query.Where(m => m.Id.ToString() == entSearch.Id);
                    }
                    if (!string.IsNullOrEmpty(entSearch.UserId))
                    {
                        query = query.Where(m => m.UserId.ToString() == entSearch.UserId);
                    }
                    if (!string.IsNullOrEmpty(entSearch.WX_OpenID))
                    {
                        var userid = ctx.Users.Where(m => m.WX_OpenID == entSearch.WX_OpenID).Select(m => m.Id).First();
                        query = query.Where(m => m.Id == userid);
                    }
                    if (!string.IsNullOrEmpty(entSearch.Date))
                    {
                        query = query.Where(m => m.Date == entSearch.Date);
                    }
                    if (!string.IsNullOrEmpty(entSearch.LiuShuiH))
                    {
                        query = query.Where(m => m.LiuShuiH == entSearch.LiuShuiH);
                    }
                    if (!string.IsNullOrEmpty(entSearch.ChiMa))
                    {
                        query = query.Where(m => m.ChiMa == entSearch.ChiMa);
                    }
                    if (!string.IsNullOrEmpty(entSearch.ShiShu))
                    {
                        query = query.Where(m => m.ShiShu == entSearch.ShiShu);
                    }
                    if (!string.IsNullOrEmpty(entSearch.BeiZhu))
                    {
                        query = query.Where(m => m.BeiZhu == entSearch.BeiZhu);
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
        /// 删除一条记货记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string DelByID(int ID)
        {
            try
            {
                using (var ctx = new APIContextDataContext())
                {
                    var del = ctx.Entries.Where(m => m.Id == ID).First();
                    ctx.Entries.DeleteOnSubmit(del);
                    ctx.SubmitChanges();
                    return JsonConvert.SerializeObject(new
                    {
                        Result = "OK",
                        Msg = "数据已删除"
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