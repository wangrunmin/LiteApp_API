using LiteApp_API_Auth.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteApp_API_Auth.Filter
{
    public class CustomAuthAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var sessionid = filterContext.ActionParameters["sessionid"].ToString();
                using (var ctx = new SessionContext())
                {
                    var uujuku = ctx.Sessions.Select(m => m.SessionId).ToList();
                    var uujukuid = uujuku[1];
                    var flag = sessionid == uujukuid;
                    var session = ctx.Sessions.Where(m => m.SessionId == sessionid).First();
                    var se = ctx.Sessions.AsQueryable();
                    if (session.ExpireTime.CompareTo(DateTime.Now) < 0)
                    {
                        throw new Exception("过期的Session");
                    }
                }
            }
            catch (Exception e)
            {
                filterContext.Result = new RedirectResult("/Account/Login?exception=" + e.Message);
            }
        }
    }
}