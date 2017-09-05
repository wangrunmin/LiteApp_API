using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteApp_API_Auth.Controllers
{
    public class DefaultController : Controller
    {
        [Filter.CustomAuth]
        public string Index(string sessionid)
        {
            return "验证通过";
        }
    }
}