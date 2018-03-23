using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.AutoWeb.Controllers.ProductService
{
    /// <summary>
    /// v5技术平台 Aps产品介绍
    /// </summary>
    public class V5TPPIController : Controller
    {
        //
        // GET: /V5TPPI/
        V5PlatformList v5PlatformList = new V5PlatformList();
        public ActionResult Index(int roofIndex=0)
        {
            TempData["urltopsy"] = "urltopv5tp";
            TempData["urltopsyp"] = "urltopv5tpp";
            v5PlatformList.TabId = roofIndex;
            if (roofIndex==1)
            {
                v5PlatformList.Title = "电商平台";
                v5PlatformList.ImgName = "dianshangpt.jpg";
            }
            else if (roofIndex == 2)
            {
                v5PlatformList.Title = "精益生产咨询";
                v5PlatformList.ImgName = "jysczxfw.jpg";
            }
            else if (roofIndex == 3)
            {
                v5PlatformList.Title = "EOH-APS系统";
                v5PlatformList.ImgName = "EOS-APSsys.png";
            }
            else if (roofIndex == 4)
            {
                v5PlatformList.Title = "工厂场景虚拟现实系统";
                v5PlatformList.ImgName = "gzxn.jpg";
            }
            else if (roofIndex == 5)
            {
                v5PlatformList.Title = "MES";
                v5PlatformList.ImgName = "EOS-MESsys.png";
            }
            else if (roofIndex == 6)
            {
                v5PlatformList.Title = "CRM";
                v5PlatformList.ImgName = "EOS-CRMsys.png";
            }
            else if (roofIndex == 7)
            {
                v5PlatformList.Title = "工业数据管理系统";
                v5PlatformList.ImgName = "gxsjgl.jpg";
            }
            else if (roofIndex == 8)
            {
                v5PlatformList.Title = "ERP";
                v5PlatformList.ImgName = "EOS-ERPsys.png";
            }
            else if (roofIndex == 9)
            {
                v5PlatformList.Title = "生产作业管理系统";
                v5PlatformList.ImgName = "sczyglxt.jpg";
            }
            else
            {
                v5PlatformList.Title = "请情";
                v5PlatformList.ImgName = "sczyglxt.png";
            }



            return View(v5PlatformList);
        }

        //
        // GET: /V5TPPI/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /V5TPPI/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /V5TPPI/Create

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
        // GET: /V5TPPI/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /V5TPPI/Edit/5

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
        // GET: /V5TPPI/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /V5TPPI/Delete/5

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
