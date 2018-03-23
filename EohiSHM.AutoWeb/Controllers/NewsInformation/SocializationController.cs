using EohiSHM.AutoWeb.ViewModels;
using EohiSHM.AutoWeb.WebDAL;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.NewsInformation
{
    /// <summary>
    /// 社会活动
    /// </summary>
    public class SocializationController : Controller
    {
        //
        // GET: /Socialization/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        HomeModels homeModels = new HomeModels();
        int pagesize = 10;
        public ActionResult Index(int pageindex=0)
        {
            TempData["urltopsy"] = "urltopcn";
            TempData["urltopsyp"] = "urltopsp";
            int tatalrows = 0;
            homeModels.NewsInformations = DB.GenericRepository.LoadPageItems(pagesize, pageindex, out tatalrows, u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.社会活动, u => u.Id, false).ToList();
            if (homeModels.NewsInformations != null)
            {
            }
            else
            {
                homeModels.NewsInformations = new List<Web_cms_article>() { new Web_cms_article() };
            }
            ViewBag.tatalrows = tatalrows;
            return View(homeModels);
        }

        //
        // GET: /Socialization/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Socialization/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Socialization/Create

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
        // GET: /Socialization/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Socialization/Edit/5

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
        // GET: /Socialization/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Socialization/Delete/5

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
