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
    /// 新闻详情
    /// </summary>
    public class NewsDetailsController : Controller
    {
        //
        // GET: /NewsDetails/
        WebUnitOfWork<Web_cms_article> DB = new WebUnitOfWork<Web_cms_article>();
        HomeModels homeModels = new HomeModels();
        int pagesize = 3;
        public ActionResult Index(int id=0)
        {
            TempData["urltopsy"] = "urltopcn";
            int tatalrows = 0;
            homeModels.NewsDetails = DB.GenericRepository.FindById(id);
            if (homeModels.NewsDetails != null)
            {
                if (homeModels.NewsDetails.TypeNote==(int)TypeEnum.公司新闻)
                {
                    //公司新闻
                    TempData["urltopsyp"] = "urltopcnp";
                    homeModels.NewsInformations = DB.GenericRepository.LoadPageItems(pagesize, 0, out tatalrows, u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.公司新闻, u => u.Id, false).ToList();
                    if (homeModels.NewsInformations != null)
                    {
                    }
                    else
                    {
                        homeModels.NewsInformations = new List<Web_cms_article>() { new Web_cms_article() };
                    }

                    ViewBag.afternews = DB.GenericRepository.FirstOrDefault(u => u.Id > id && u.TypeNote == (int)TypeEnum.公司新闻);
                    ViewBag.beforenews = DB.GenericRepository.GetDes(u => u.Id < id && u.TypeNote == (int)TypeEnum.公司新闻, u => u.Id);
                }
                else      if(homeModels.NewsDetails.TypeNote==(int)TypeEnum.行业资讯)
                {
                    // 行业资讯
                    TempData["urltopsyp"] = "urltopiip";
                    homeModels.NewsInformations = DB.GenericRepository.LoadPageItems(pagesize, 0, out tatalrows, u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.行业资讯, u => u.Id, false).ToList();
                    if (homeModels.NewsInformations != null)
                    {
                    }
                    else
                    {
                        homeModels.NewsInformations = new List<Web_cms_article>() { new Web_cms_article() };
                    }

                    ViewBag.afternews = DB.GenericRepository.FirstOrDefault(u => u.Id > id && u.TypeNote == (int)TypeEnum.行业资讯);
                    ViewBag.beforenews = DB.GenericRepository.GetDes(u => u.Id < id && u.TypeNote == (int)TypeEnum.行业资讯, u => u.Id);
                }
                else if (homeModels.NewsDetails.TypeNote == (int)TypeEnum.社会活动)
                {
                    //社会活动
                    TempData["urltopsyp"] = "urltopsp";
                    homeModels.NewsInformations = DB.GenericRepository.LoadPageItems(pagesize, 0, out tatalrows, u => u.IsVisibel == (int)VisibleEnum.显示 && u.TypeNote == (int)TypeEnum.社会活动, u => u.Id, false).ToList();
                    if (homeModels.NewsInformations != null)
                    {
                    }
                    else
                    {
                        homeModels.NewsInformations = new List<Web_cms_article>() { new Web_cms_article() };
                    }

                    ViewBag.afternews = DB.GenericRepository.FirstOrDefault(u => u.Id > id && u.TypeNote == (int)TypeEnum.社会活动);
                    ViewBag.beforenews = DB.GenericRepository.GetDes(u => u.Id < id && u.TypeNote == (int)TypeEnum.社会活动, u => u.Id);
                }
                else
                {
                    return RedirectToAction("Index", "ErrorHandle");
                }
            }
            else
            {
                homeModels.NewsDetails = new Web_cms_article();
            }
            return View(homeModels);
        }

        //
        // GET: /NewsDetails/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /NewsDetails/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NewsDetails/Create

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
        // GET: /NewsDetails/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /NewsDetails/Edit/5

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
        // GET: /NewsDetails/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /NewsDetails/Delete/5

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
