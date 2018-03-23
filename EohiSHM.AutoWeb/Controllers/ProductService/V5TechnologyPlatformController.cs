using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.ProductService
{
    /// <summary>
    /// v5技术平台
    /// </summary>
    public class V5TechnologyPlatformController : Controller
    {
        //
        // GET: /V5TechnologyPlatform/

        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltopv5tp";
            TempData["urltopsyp"] = "urltopv5tpp";
            return View();
        }

        //
        // GET: /V5TechnologyPlatform/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /V5TechnologyPlatform/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /V5TechnologyPlatform/Create

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
        // GET: /V5TechnologyPlatform/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /V5TechnologyPlatform/Edit/5

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
        // GET: /V5TechnologyPlatform/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /V5TechnologyPlatform/Delete/5

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
