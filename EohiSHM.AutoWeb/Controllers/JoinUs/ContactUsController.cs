using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.JoinUs
{
    /// <summary>
    /// 联系我们
    /// </summary>
    public class ContactUsController : Controller
    {
        //
        // GET: /contactUs/

        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltopti";
            TempData["urltopsyp"] = "urltopcup";
            return View();
        }

        //
        // GET: /contactUs/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /contactUs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /contactUs/Create

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
        // GET: /contactUs/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /contactUs/Edit/5

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
        // GET: /contactUs/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /contactUs/Delete/5

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
