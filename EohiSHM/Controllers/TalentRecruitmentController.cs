using EohiSHM.AdmDAL;
using EohiSHM.Common;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.Controllers
{
    [LoginCheckFilter(IsNeedLogin = true)]
    public class TalentRecruitmentController : BaseController
    {
        //
        // GET: /TalentRecruitment/
        AdmUnitOfWork<Web_Recruit> Db = new AdmUnitOfWork<Web_Recruit>();
        string ImageUrl = ConfigurationManager.AppSettings["ImageUrl"].ToString();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Getlist(int page = 0, int limit = 10)
        {
            int rows = 0;
            List<Web_Recruit> list = Db.GenericRepository.GetAll<Web_Recruit>(u => u.Id>0);
    
            if (list.Count > 0)
            {
                list.ForEach(
                          u =>
                          {
                              if (u.IsVisibel != null)
                              {
                                  u.IsVisibelStr = Enum.GetName(typeof(VisibleEnum), (int)u.IsVisibel);
                              }
                              u.Cre_date = u.Cre_Time.ToString();
                              u.TermOfValidity = u.Valid_Time.ToString().Substring(10);
                          });
            }
            return Json(new
            {
                code = 0,
                msg = "",
                count = rows,
                data = list
            },
                JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /TalentRecruitment/Details/5

        public ActionResult Details(int id)
        {
            try
            {
              
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }



        //
        // GET: /TalentRecruitment/Edit/5

        public ActionResult Edit(int? id)
        {
            Web_Recruit webmodel = null;
            try
            {
                 webmodel = Db.GenericRepository.FindById(id);
                if (webmodel!=null)
                {

                }
                else
                {
                    webmodel = new Web_Recruit();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(webmodel);
        }

        //
        // POST: /TalentRecruitment/Edit/5

        [HttpPost]
        public JsonResult Edit(int id, Web_Recruit web_recruit)
        {
            try
            {
                if (id>0)
                {
                    Db.GenericRepository.Update(web_recruit);
                }
                else
                {
                    Db.GenericRepository.Insert(web_recruit);
                }
                web_recruit.Cre_date = DateTime.Now.ToString("yyyy年MM月dd日");
                Db.Save();
              //  return RedirectToAction("Index");
                return Json(new { success = true, msg = "保存成功！" });
            }
            catch
            {
                //  return View();
                return Json(new { success = false, msg = "保存失败！" });
            }
        }

        //
        // GET: /TalentRecruitment/Delete/5

        public ActionResult Delete(int? id)
        {
          
            return View();
        }

        //
        // POST: /TalentRecruitment/Delete/5

        [HttpPost]
        public JsonResult Delete(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Db.GenericRepository.Delete(id);
                Db.Save();
                //return RedirectToAction("Index");
                return Json(new { state = 1, msg = "删除成功！" });
            }
            catch
            {
              //  return View();
                return Json(new { state = 0, msg = "删除失败！" });
            }
        }
    }
}
