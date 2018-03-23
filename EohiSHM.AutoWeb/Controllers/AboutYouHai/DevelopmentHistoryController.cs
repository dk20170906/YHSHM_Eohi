using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers
{
    /// <summary>
    /// 发展历程
    /// </summary>
    public class DevelopmentHistoryController : Controller
    {
        //
        // GET: /DevelopmentHistory/

        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltopsy";
            TempData["urltopsyp"] = "urltopdhp";
            return View();
        }

        //
        // GET: /DevelopmentHistory/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /DevelopmentHistory/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DevelopmentHistory/Create

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
        // GET: /DevelopmentHistory/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /DevelopmentHistory/Edit/5

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
        // GET: /DevelopmentHistory/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /DevelopmentHistory/Delete/5

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
