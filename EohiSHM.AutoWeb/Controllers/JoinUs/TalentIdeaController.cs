using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.JoinUs
{
    /// <summary>
    /// 人才理念
    /// </summary>
    public class TalentIdeaController : Controller
    {
        //
        // GET: /TalentIdea/

        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltopti";
            TempData["urltopsyp"] = "urltoptip";
            return View();
        }

        //
        // GET: /TalentIdea/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TalentIdea/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TalentIdea/Create

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
        // GET: /TalentIdea/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TalentIdea/Edit/5

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
        // GET: /TalentIdea/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TalentIdea/Delete/5

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
