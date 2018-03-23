using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers
{
    /// <summary>
    /// 播放记录
    /// </summary>
    public class PlayRecordController : Controller
    {
        //
        // GET: /PlayRecord/

        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltoppr";
            return View();
        }

        //
        // GET: /PlayRecord/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PlayRecord/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PlayRecord/Create

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
        // GET: /PlayRecord/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PlayRecord/Edit/5

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
        // GET: /PlayRecord/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PlayRecord/Delete/5

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
