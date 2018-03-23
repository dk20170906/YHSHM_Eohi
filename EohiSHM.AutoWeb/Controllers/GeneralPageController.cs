using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers
{
    public class GeneralPageController : Controller
    {

        public ActionResult TopHeader()
        {
            return View();
        }
        /// <summary>
        /// 顶部导航
        /// </summary>
        /// <returns></returns>
        public ActionResult NavHeader()
        {
            return View();
        }
        /// <summary>
        ///  模板头部
        /// </summary>
        /// <returns></returns>
        public ActionResult Header()
        {
            return View();
        }
        /// <summary>
        /// 模板底部
        /// </summary>
        /// <returns></returns>
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult LayoutLogin()
        {
            return View();
        }
    }
}
