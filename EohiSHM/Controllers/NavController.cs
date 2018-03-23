using EohiSHM.AdmDAL;
using EohiSHM.Common;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.Controllers
{
   [LoginCheckFilter(IsNeedLogin = true)]
    public class NavController : BaseController
    {
      AdmUnitOfWork<Web_admin_menu> Db = new AdmUnitOfWork<Web_admin_menu>();
        AdmUnitOfWork<ConfOption> Dbcfo = new AdmUnitOfWork<ConfOption>();
        MenuListTree listTree = new MenuListTree();
        public ActionResult NavHead()
        {
            return View();
        }
        public ActionResult NavLeft()
        {
            ViewBag.menulist = listTree.CreateMenuModel("100000");
            return View();
        }
        public ActionResult NavFooter()
        {
            ConfOption ConfOption = Dbcfo.GenericRepository.GetAllDes(u => u.Id).FirstOrDefault();
            if (ConfOption==null)
            {
                ConfOption = new ConfOption();
            }
            return View(ConfOption);
        }


    }
}
