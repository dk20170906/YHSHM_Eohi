using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers
{
    public class GProductServiceController : Controller
    {
        /// <summary>
        ///  模板头部
        /// </summary>
        /// <returns></returns>
        public ActionResult Header()
        {
            return View();
        }
    }
}
