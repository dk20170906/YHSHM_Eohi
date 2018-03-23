using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.YouhaiClassroom
{
    /// <summary>
    ///   微课程
    /// </summary>
    public class MicrocurriculumController : Controller
    {
        //
        // GET: /Microcurriculum/

        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltoptv";
            TempData["urltopsyp"] = "urltopmp";
            return View();
        }

        //
        // GET: /Microcurriculum/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Microcurriculum/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Microcurriculum/Create

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
        // GET: /Microcurriculum/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Microcurriculum/Edit/5

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
        // GET: /Microcurriculum/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Microcurriculum/Delete/5

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
