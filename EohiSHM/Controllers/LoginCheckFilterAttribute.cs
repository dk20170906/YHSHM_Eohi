using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace EohiSHM.Controllers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class LoginCheckFilterAttribute : ActionFilterAttribute
    {
        public bool IsNeedLogin = true;
    }
}