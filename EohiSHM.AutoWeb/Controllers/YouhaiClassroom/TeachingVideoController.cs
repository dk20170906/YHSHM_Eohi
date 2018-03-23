using EohiSHM.AutoWeb.ViewModels;
using EohiSHM.AutoWeb.WebDAL;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.YouhaiClassroom
{
    /// <summary>
    /// 优海课堂 教学视频
    /// </summary>
    public class TeachingVideoController : Controller
    {
        //
        // GET: /TeachingVideo/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        HomeModels homeModels = new HomeModels();
        /// <summary>
        /// 每页显示数据的大小
        /// </summary>
        int pagesize = 3;
        public ActionResult Index(int pageindex=0, string Author=null)
        {
            TempData["urltopsy"] = "urltoptv";
            TempData["urltopsyp"] = "urltoptvp";
            int tatalrows = 0;
            //讲师其他视频
            if (Author != null)
            {
                homeModels.YouhaiClassrooms = DB.GenericRepository.LoadPageItems(pagesize, pageindex, out tatalrows, u => u.TypeNote==(int)TypeEnum.教学视频&&u.Author.Contains(Author), u => u.Id, false).ToList();
                if (homeModels.YouhaiClassrooms!=null)
                {
                }
                else
                {
                    homeModels.YouhaiClassrooms = new List<Web_cms_article>() { new Web_cms_article() };
                }
                homeModels.YHVideoFirst = DB.GenericRepository.GetDes(u =>u.TypeNote==(int)TypeEnum.教学视频&& u.VideoFile != null && u.VideoFile.Length > 0&&u.Author.Contains(Author), u => u.Id);
                if (homeModels.YHVideoFirst != null)
                {
                }
                else
                {
                    homeModels.YHVideoFirst = new Web_cms_article();
                }
            }
            else
            {
                homeModels.YouhaiClassrooms = DB.GenericRepository.LoadPageItems(pagesize, pageindex, out tatalrows, u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.教学视频, u => u.Id, false).ToList();
                if (homeModels.YouhaiClassrooms != null)
                {
                }
                else
                {
                    homeModels.YouhaiClassrooms = new List<Web_cms_article>() { new Web_cms_article() };
                }
                homeModels.YHVideoFirst = DB.GenericRepository.GetDes(u =>u.TypeNote==(int)TypeEnum.教学视频&& u.VideoFile != null && u.VideoFile.Length > 0, u => u.Id);
                if (homeModels.YHVideoFirst != null)
                {
                }
                else
                {
                    homeModels.YHVideoFirst = new Web_cms_article();
                }
            }
            ViewBag.tatalrows = tatalrows;
            return View(homeModels);
        }

        //
        // GET: /TeachingVideo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TeachingVideo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TeachingVideo/Create

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
        // GET: /TeachingVideo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TeachingVideo/Edit/5

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
        // GET: /TeachingVideo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TeachingVideo/Delete/5

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
