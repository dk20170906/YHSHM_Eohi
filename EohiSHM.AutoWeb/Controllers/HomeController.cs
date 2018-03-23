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
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        HomeModels homeModels = new HomeModels();
        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltophome";
            int totalrows = 0;
         var NewsInformations= DB.GenericRepository.LoadPageItems(3, 0, out totalrows, u => u.IsVisibel == (int)VisibleEnum.显示 &&u.TypeNote==(int)TypeEnum.公司新闻, u => u.Id, false).ToList();
            if (NewsInformations!=null)
            {
                homeModels.NewsInformations = NewsInformations;
            }
            else
            {
                homeModels.NewsInformations = new List<Web_cms_article>() { new Web_cms_article ()};
            }

            homeModels.YHVideoFirst = DB.GenericRepository.GetAllDes(u=>u.VideoFile!=null&&u.VideoFile.Length>0,u=>u.Id).FirstOrDefault();
            if (homeModels.YHVideoFirst != null)
            {
            }
            else
            {
                homeModels.YHVideoFirst = new Web_cms_article();
            }
            homeModels.TypicalCases = DB.GenericRepository.LoadPageItems(8, 0, out totalrows, u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.典型案例, u => u.Id, false).ToList();
            if (homeModels.TypicalCases!=null)
            {
            }
            else
            {
                homeModels.TypicalCases = new List<Web_cms_article>() { new Web_cms_article() };
            }
            homeModels.YouhaiClassrooms = DB.GenericRepository.GetAllDes(u => u.Id > 0);
            if (homeModels.YouhaiClassrooms!=null)
            {
            }
            else
            {
                homeModels.YouhaiClassrooms = new List<Web_cms_article>() { new Web_cms_article() };
            }
            return View(homeModels);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

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
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
