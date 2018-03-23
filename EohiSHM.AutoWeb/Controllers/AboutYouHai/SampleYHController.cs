using EohiSHM.AutoWeb.WebDAL;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers
{
    /// <summary>
    /// 优海简介
    /// </summary>
    public class SampleYHController : Controller
    {
        //
        // GET: /AboutYH/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltopsy";
            TempData["urltopsyp"] = "urltopsyp";
            //var yhjj = DB.GenericRepository.Get(u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.公司简介);
            //if (yhjj!=null)
            //{

            //}
            //else
            //{
            //    yhjj = new Web_cms_article();
            //}
            return View();
        }

        //
        // GET: /AboutYH/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AboutYH/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AboutYH/Create

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
        // GET: /AboutYH/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AboutYH/Edit/5

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
        // GET: /AboutYH/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AboutYH/Delete/5

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
