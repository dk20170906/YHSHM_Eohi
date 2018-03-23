using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers
{
    /// <summary>
    ///               资质荣誉
    /// </summary>
    public class QualificationHonorController : Controller
    {
        //
        // GET: /QualificationHonor/

        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltopsy";
            TempData["urltopsyp"] = "urltopqhp";
            return View();
        }

        //
        // GET: /QualificationHonor/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /QualificationHonor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QualificationHonor/Create

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
        // GET: /QualificationHonor/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /QualificationHonor/Edit/5

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
        // GET: /QualificationHonor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /QualificationHonor/Delete/5

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
