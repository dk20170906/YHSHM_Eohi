using EohiSHM.AutoWeb.ViewModels;
using EohiSHM.AutoWeb.WebDAL;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers
{
    public class TeamYHController : Controller
    {
        //
        // GET: /TeamYH/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        HomeModels homeModels = new HomeModels();
        public ActionResult Index(int pageindex=0)
        {
            TempData["urltopsy"] = "urltopsy";
            TempData["urltopsyp"] = "urltoptyhp";
            int totalrows = 0;
            homeModels.TeamsYh = DB.GenericRepository.LoadPageItems(6, pageindex, out totalrows, u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.优海团队, u => u.Id, false).ToList();
            if (homeModels.TeamsYh!=null)
            {
            }
            else
            {
                homeModels.TeamsYh = new List<Web_cms_article>() { new Web_cms_article() };
            }
            ViewBag.tatalrows = totalrows;
            return View(homeModels);
        }

        //
        // GET: /TeamYH/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TeamYH/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TeamYH/Create

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
        // GET: /TeamYH/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TeamYH/Edit/5

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
        // GET: /TeamYH/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TeamYH/Delete/5

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
