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
    ///            典型案例详情
    /// </summary>
    public class V5TYCDetailsController : Controller
    {
        //
        // GET: /V5TYCDetails/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        HomeModels homeModels = new HomeModels();
        public ActionResult Index(int id=0)
        {
            TempData["urltopsy"] = "urltopv5tp";
            TempData["urltopsyp"] = "urltopv5tcp";
            homeModels.NewsDetails = DB.GenericRepository.FindById(id);
            if (homeModels.NewsDetails!=null)
            {
            }
            else
            {
                homeModels.NewsDetails = new Web_cms_article();
            }
            return View(homeModels);
        }

        //
        // GET: /V5TYCDetails/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /V5TYCDetails/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /V5TYCDetails/Create

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
        // GET: /V5TYCDetails/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /V5TYCDetails/Edit/5

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
        // GET: /V5TYCDetails/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /V5TYCDetails/Delete/5

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
