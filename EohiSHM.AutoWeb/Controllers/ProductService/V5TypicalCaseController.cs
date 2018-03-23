using EohiSHM.AutoWeb.ViewModels;
using EohiSHM.AutoWeb.WebDAL;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.ProductService
{
    /// <summary>
    /// v5典型案例
    /// </summary>
    public class V5TypicalCaseController : Controller
    {
        //
        // GET: /V5TypicalCase/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        HomeModels homeModels = new HomeModels();
        public ActionResult Index(int pageindex=0)
        {
            TempData["urltopsy"] = "urltopv5tp";
            TempData["urltopsyp"] = "urltopv5tcp";
            int tatalrows = 0;
            homeModels.TypicalCases = DB.GenericRepository.LoadPageItems(8, 0, out tatalrows, u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.典型案例, u => u.Id, false).ToList();
            if (homeModels.TypicalCases != null)
            {
            }
            else
            {
                homeModels.TypicalCases = new List<Web_cms_article>() { new Web_cms_article() };
            }
            ViewBag.tatalrows = tatalrows;
            return View(homeModels);
        }

        //
        // GET: /V5TypicalCase/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /V5TypicalCase/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /V5TypicalCase/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /V5TypicalCase/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /V5TypicalCase/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /V5TypicalCase/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /V5TypicalCase/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
