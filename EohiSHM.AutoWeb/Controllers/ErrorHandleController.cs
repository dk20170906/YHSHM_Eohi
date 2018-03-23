using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers
{
    public class ErrorHandleController : Controller
    {
        //
        // GET: /ErrorHandle/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /ErrorHandle/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ErrorHandle/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ErrorHandle/Create

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
        // GET: /ErrorHandle/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ErrorHandle/Edit/5

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
        // GET: /ErrorHandle/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ErrorHandle/Delete/5

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
