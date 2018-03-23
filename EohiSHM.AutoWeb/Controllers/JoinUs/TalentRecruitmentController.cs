using EohiSHM.AutoWeb.ViewModels;
using EohiSHM.AutoWeb.WebDAL;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.JoinUs
{
    /// <summary>
    /// 人才招聘
    /// </summary>
    public class TalentRecruitmentController : Controller
    {
        //
        // GET: /TalentRecruitment/
        WebUnitOfWork<Web_Recruit> DB = new WebUnitOfWork<Web_Recruit>();
        HomeModels homeModels = new HomeModels();
        public ActionResult Index()
        {
            TempData["urltopsy"] = "urltopti";
            TempData["urltopsyp"] = "urltoptrp";
           var list= DB.GenericRepository.GetAll(u => u.Id > 0);
            if (list!=null)
            {
                list.ForEach(u =>
                {
                    u.TermOfValidity = u.Valid_Time.ToString().Substring(10);
                });
                homeModels.Webrec = list;
            }
            else
            {
                homeModels.Webrec = new List<Web_Recruit>() { new Web_Recruit()  };
            }
            return View(homeModels);
        }

        //
        // GET: /TalentRecruitment/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TalentRecruitment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TalentRecruitment/Create

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
        // GET: /TalentRecruitment/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TalentRecruitment/Edit/5

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
        // GET: /TalentRecruitment/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TalentRecruitment/Delete/5

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
