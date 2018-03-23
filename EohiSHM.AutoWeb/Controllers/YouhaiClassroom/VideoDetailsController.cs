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
    /// 视频详情
    /// </summary>
    public class VideoDetailsController : Controller
    {
        //
        // GET: /VideoDetails/
        // GET: /TeachingVideo/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        HomeModels homeModels = new HomeModels();
        int pagesize = 3;
        public ActionResult Index(int id)
        {
            TempData["urltopsy"] = "urltoptv";
            Web_cms_article web_Cms_Article = DB.GenericRepository.FindById(id);
            if (web_Cms_Article!=null)
            {
                web_Cms_Article.Cre_Time = web_Cms_Article.Cre_date.ToString();
            }
            else
            {
                web_Cms_Article = new Web_cms_article();
            }
            int tatolrows = 0;
        var list = DB.GenericRepository.LoadPageItems(pagesize, 0, out tatolrows, u => u.TypeNote==(int)TypeEnum.教学视频, u => u.Id, false).ToList();
            if (list != null&& list.Count>0)
            {
                list.ForEach(u =>
                {
                    u.Cre_Time = u.Cre_date.ToString();
                });
            }
            else
            {
                list = new List<Web_cms_article>() { new Web_cms_article() };
            }
            ViewBag.afternews = DB.GenericRepository.FirstOrDefault(u => u.Id > id&&u.TypeNote==(int)TypeEnum.教学视频);
            ViewBag.beforenews = DB.GenericRepository.GetDes(u => u.Id < id && u.TypeNote == (int)TypeEnum.教学视频, u => u.Id);
            homeModels.YouhaiClassrooms = list;
            homeModels.YHVideoFirst = web_Cms_Article;
            return View(homeModels);
        }

        //
        // GET: /VideoDetails/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /VideoDetails/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VideoDetails/Create

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
        // GET: /VideoDetails/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /VideoDetails/Edit/5

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
        // GET: /VideoDetails/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /VideoDetails/Delete/5

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
