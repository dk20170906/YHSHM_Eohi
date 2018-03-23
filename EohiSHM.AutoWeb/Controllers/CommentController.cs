using EohiSHM.AutoWeb.WebDAL;
using EohiSHM.Common;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.YouhaiClassroom
{
    /// <summary>
    /// 发表评论
    /// </summary>
    /// 
    public class CommentController : Controller
    {
        //
        // GET: /Comment/
        Web_Commentary web_Commentary = new Web_Commentary();
        WebUnitOfWork<Web_Commentary> DB = new WebUnitOfWork<Web_Commentary>();
        /// <summary>
        /// 评论区显示的评论条数
        /// </summary>
        int pagezise = 5;
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 页面加载评论
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCommList(int?AId)
        {
            int totalrows = 0;
            var list = DB.GenericRepository.LoadPageItems(pagezise, 0, out totalrows, u => u.Id > 0&&u.ArticleId==AId, u => u.Id, false).ToList();
            if (list != null && list.Count > 0)
            {
            }
            else
            {
                list = new List<Web_Commentary>() { new Web_Commentary() };
            }
            // return RedirectToAction("Index");
            return Json(new
            {
                code = 1,
                totalrows= totalrows,
                datalist = list,
            },
              JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 点赞
        /// </summary>
        /// <returns></returns>
        public JsonResult GiveTheThumbsUp(int?id)
        {
            Web_Commentary web_Commentary= DB.GenericRepository.FindById(id);
            web_Commentary.ALaud++;
            DB.GenericRepository.Update(web_Commentary);
            DB.Save();
            return Json(new {

                dataup = web_Commentary.ALaud
                   
            }, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Comment/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Comment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comment/Create

        [HttpPost]
        public JsonResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                web_Commentary.PublicationContent = collection["PublicationContent"];
                web_Commentary.ArticleId = Convert.ToInt32(collection["AId"]);
                web_Commentary.UserIpAddress = Request.UserHostAddress;
                web_Commentary.Cre_Time = DateTime.Now;
                web_Commentary.UserAddress = collection["UserAddress"];
                web_Commentary.ALaud = 0;
                web_Commentary.Cre_TimeStr = DateTime.Now.ToString("yyyy-MM-dd");
                DB.GenericRepository.Insert(web_Commentary);
                DB.Save();
                int totalrows = 0;
                var list = DB.GenericRepository.LoadPageItems(pagezise, 0, out totalrows, u => u.Id > 0&&u.ArticleId == web_Commentary.ArticleId, u => u.Id, false).ToList();
                if (list != null && list.Count > 0)
                {
                }
                else
                {
                    list = new List<Web_Commentary>() { new Web_Commentary() };
                }
                // return RedirectToAction("Index");
                return Json(new
                {
                    code = 1,
                    datalist = list,
                    totalrows = totalrows,
                    msg = "评论成功!"

                },
                  JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //return View();
                return Json(new
                {
                    code = 0,
                    msg = "评论失败!"
                },
                 JsonRequestBehavior.AllowGet);
            }

        }

        //
        // GET: /Comment/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Comment/Edit/5

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
        // GET: /Comment/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Comment/Delete/5

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
