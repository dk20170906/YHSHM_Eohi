using EohiSHM.AdmDAL;
using EohiSHM.Common;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.Controllers
{
     [LoginCheckFilter(IsNeedLogin = true)]
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        AdmUnitOfWork<Web_cms_article> Db = new AdmUnitOfWork<Web_cms_article>();
        string ImageUrl = ConfigurationManager.AppSettings["ImageUrl"].ToString();
        Dictionary<int, string> namesenum = EnumToDic.GetEnumToDic();
        public ActionResult Index()
        {
            ViewBag.namesenum = namesenum;
            return View();
        }
        [ValidateInput(false)]
        public JsonResult getlist(int page = 0, int limit = 10, int typeid = 0, string title = null, string Subtitle = null, string Cre_man = null, string Mod_man = null, string timeb = null, string timel = null)
        {
            List<Web_cms_article> list = new List<Web_cms_article>();
            List<FilterModel> FMlist = null;
            //搜索
            if (typeid >= 0)
            {
                FMlist = new List<FilterModel>() { new FilterModel() { Action = "=", Column = "TypeNote", DataType = "int", Logic = "AND", Value = typeid.ToString() } };
            }
            else
            {
                FMlist = new List<FilterModel>();
            }

            if (!string.IsNullOrEmpty(title))
            {
                FMlist.Add(new FilterModel() { Action = "in", Column = "title", DataType = "1", Logic = "AND", Value = title });
            }
            if (!string.IsNullOrEmpty(Subtitle))
            {
                FMlist.Add(new FilterModel() { Action = "in", Column = "subtitle", DataType = "1", Logic = "AND", Value = Subtitle });
            }
            if (!string.IsNullOrEmpty(Cre_man))
            {
                FMlist.Add(new FilterModel() { Action = "in", Column = "Cre_man", DataType = "1", Logic = "AND", Value = Cre_man });
            }
            if (!string.IsNullOrEmpty(Mod_man))
            {
                FMlist.Add(new FilterModel() { Action = "in", Column = "Mod_man", DataType = "1", Logic = "AND", Value = Mod_man });
            }
            if (!string.IsNullOrEmpty(timeb))
            {
                FMlist.Add(new FilterModel() { Action = ">=", Column = "Cre_date", DataType = "DateTime", Logic = "AND", Value = timeb });
            }
            if (!string.IsNullOrEmpty(timel))
            {
                FMlist.Add(new FilterModel() { Action = "<=", Column = "Cre_date", DataType = "DateTime", Logic = "AND", Value = timel });
            }
            var vxm = TrendsLamadaHelper<Web_cms_article>.GetFilterExpression(FMlist);
            int rows = 0;
            if (vxm != null)
            {
                list = Db.GenericRepository.LoadPageItems(limit, page, out rows, vxm, u => u.Id, false).ToList();
            }
            else
            {
                list = Db.GenericRepository.LoadPageItems(limit, page, out rows, u => u.Id > 0, u => u.Id, false).ToList();
            }
            if (list.Count > 0)
            {

                list.ForEach(
                    u =>
                    {
                        if (u.TypeNote != null)
                        {
                            u.TypeNoteStr = Enum.GetName(typeof(TypeEnum), (int)u.TypeNote);
                        };
                        if (u.IsVisibel != null)
                        {
                            u.IsVisibelStr = Enum.GetName(typeof(VisibleEnum), (int)u.IsVisibel) + " " + u.Usetype;
                        }
                        u.Cre_Time = u.Cre_date.ToString();
                        u.PubdateStr = u.Pubdate.ToString();
                        u.Mod_Time = u.Mod_date.ToString();
                        u.ConductsTimestr = u.ConductsTime.ToString();
                        if (u.AppendixName == null || u.AppendixName.Length == 0)
                        {
                            u.AppendixStr = "未上传附件";
                        }
                        else
                        {
                            u.AppendixStr = "已上传附件";

                        }
                        if (u.ConductsTime != null)
                        {
                            u.ConductsTimestr = u.ConductsTime.ToString();
                        }
                    });
            }
            //使用cookit判断创建修改文章类型
            HttpCookie cookie = Request.Cookies["typenoteedit"];
            if (cookie != null)
            {
                cookie = null;
                cookie = new HttpCookie("typenoteedit");
            }
            else
            {
                cookie = new HttpCookie("typenoteedit");
            }
            cookie.Values.Set("typenoteint", typeid.ToString());
            Response.SetCookie(cookie);
            return Json(new
            {
                code = 0,
                msg = "",
                count = rows,
                data = list
            },
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int? id)
        {
            Dictionary<int, string> namesenum = EnumToDic.GetEnumToDic();

            ViewBag.namesenum = namesenum;
            Web_cms_article Web_cms_article = null;
            if (ModelState.IsValid)
            {
                Web_cms_article = Db.GenericRepository.FindById(id);

                if (Web_cms_article == null)
                {
                    Web_cms_article = new Web_cms_article();
                    Web_cms_article.Previewimg = "~";
                }
                else
                {
                    if (Web_cms_article.Previewimg != null || Web_cms_article.Previewimg != "")
                    {
                        Web_cms_article.Previewimg = "~/UploadFile/Images/" + Web_cms_article.Previewimg;
                    }
                }

            }
            TypeEnum typeEnum = new TypeEnum();
            ViewBag.typeenum = typeEnum;
            return View(Web_cms_article);
        }
        [HttpPost]
        public JsonResult UqloadFileTxt()
        {

            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                string folderpath = "/UploadFile/Images/";//上传图片的文件夹
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(Server.MapPath(folderpath));
                }
                string ext1 = Path.GetExtension(file.FileName);
                if (ext1 != ".gif" && ext1 != ".jpg" && ext1 != ".jpeg" && ext1 != ".png")
                {
                    return Json(new
                    {
                        code = 1,
                        msg = "文件格式不正确!"
                    },
                JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string name = DateTime.Now.ToString("yyyyMMddHHmmssff");
                    string ext = Path.GetExtension(file.FileName);
                    string downpath = folderpath + name + ext;
                    string filepath = Server.MapPath(folderpath) + name + ext;
                    file.SaveAs(filepath);
                    return Json(new
                    {
                        code = 0,
                        msg = "上传成功!",
                        data = new
                        {
                            src = ImageUrl + downpath,
                            title = name + ext
                        }

                    },
                   JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    code = 1,
                    msg = "上传失败!"
                },
                  JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult UqloadFile()
        {
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                string folderpath = "/UploadFile/Images/";//上传图片的文件夹
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(Server.MapPath(folderpath));
                }
                string ext1 = Path.GetExtension(file.FileName);
                if (ext1 != ".gif" && ext1 != ".jpg" && ext1 != ".jpeg" && ext1 != ".png")
                {
                    return Json(new
                    {
                        code = 1,
                        msg = "文件格式不正确!"
                    },
                JsonRequestBehavior.AllowGet);
                }
                else
                {
                    string name = DateTime.Now.ToString("yyyyMMddHHmmssff");
                    string ext = Path.GetExtension(file.FileName);
                    string downpath = folderpath + name + ext;
                    string filepath = Server.MapPath(folderpath) + name + ext;
                    file.SaveAs(filepath);
                    return Json(new
                    {
                        code = 0,
                        msg = "上传成功!",
                        data = new
                        {
                            src = ImageUrl + downpath,
                            title = name + ext
                        }

                    },
                   JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new
                {
                    code = 1,
                    msg = "上传失败!"
                },
                  JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult UqloadFileZip()
        {

            // var filessd= files;
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                string ext1 = Path.GetExtension(file.FileName);
                string folderpath = "/UploadFile/TradeJournal/";//上传行来杂志文件

                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(Server.MapPath(folderpath));
                }

                string name = DateTime.Now.ToString("yyyyMMddHHmmssff");
                string ext = Path.GetExtension(file.FileName);
                string downpath = folderpath + name + ext;
                string filepath = Server.MapPath(folderpath) + name + ext;
                file.SaveAs(filepath);
                return Json(new
                {
                    code = 0,
                    msg = "上传成功!",
                    data = new
                    {
                        src = ImageUrl + downpath,
                        title = name + ext
                    }

                },
               JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(new
                {
                    code = 1,
                    msg = "上传失败!"
                },
                  JsonRequestBehavior.AllowGet);
            }
        }
        //
        // POST: /Admin/Article/Edit/5
        public JsonResult UqloadVideo()
        {
            // var filessd= files;
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                string ext1 = Path.GetExtension(file.FileName);
                string folderpath = "/UploadFile/Video/";//上传行来杂志文件

                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(Server.MapPath(folderpath));
                }

                string name = DateTime.Now.ToString("yyyyMMddHHmmssff");
                string ext = Path.GetExtension(file.FileName);
                string downpath = folderpath + name + ext;
                string filepath = Server.MapPath(folderpath) + name + ext;
                file.SaveAs(filepath);
                return Json(new
                {
                    code = 0,
                    msg = "上传成功!",
                    data = new
                    {
                        src = ImageUrl + downpath,
                        title = name + ext
                    }

                },
               JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(new
                {
                    code = 1,
                    msg = "上传失败!"
                },
                  JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(int id, Web_cms_article Web_cms_article, string TypeNoteEdit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Web_cms_article.Mod_date = DateTime.Now;
                    if (Web_cms_article.IsVisibel != 1)
                    {
                        Web_cms_article.IsVisibel = 0;
                    }
                    if (Web_cms_article.TypeNote == 256)
                    {

                        if (Web_cms_article.Usetype != null)
                        {
                            var web_Cms_Articllist = Db.GenericRepository.GetAll<Web_cms_article>(u => u.Usetype == Web_cms_article.Usetype);
                            if (web_Cms_Articllist.Count > 0)
                            {
                                web_Cms_Articllist.ForEach(u =>
                                {
                                    u.Usetype = null;
                                });
                                Db.GenericRepository.UpdateAll(web_Cms_Articllist);
                            }
                        }
                    }
                    else
                    {
                        Web_cms_article.Usetype = null;
                    }
                    if (id > 0)
                    {
                        Web_cms_article.Mod_date = DateTime.Now;
                        Db.GenericRepository.Update(Web_cms_article);
                    }
                    else
                    {
                        Web_cms_article.Cre_date = DateTime.Now;
                        Db.GenericRepository.Insert(Web_cms_article);
                    }
                    if (Web_cms_article.TypeNote<0)
                    {
                        HttpCookie cookie = Request.Cookies["typenoteedit"];
                        if (cookie != null && cookie["typenoteint"].ToString() != "")
                        {
                            Web_cms_article.TypeNote = Convert.ToInt32(cookie["typenoteint"].ToString());
                        }
                    }
                    if (Web_cms_article.CountNo > 0)
                    {
                    }
                    else
                    {
                        Web_cms_article.CountNo = 1;
                    }
                    if (Web_cms_article.VideoFile != null)
                    {
                        Web_cms_article.AppendixStr = "已上传视频";
                    }
                    else
                    {
                        Web_cms_article.AppendixStr = "未上传视频";
                    }
                    Db.Save();
                    //   return RedirectToAction("Index");
                    return Json(new { success = true, msg = "保存成功！" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, msg = "保存失败！" });
                }
            }
            return Json(new { success = false, msg = "保存失败！" });
        }


        public ActionResult Details(int id)
        {
            Web_cms_article newsM = Db.GenericRepository.GetById(id);
            return View(newsM);
        }
        //
        // GET: /Admin/Article/Delete/5

        //
        // POST: /Admin/Article/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Db.GenericRepository.Delete(id);
                Db.Save();
                return Json(new { state = 1, msg = "删除成功！" });
            }
            catch
            {
                return Json(new { statu = 0, msg = "删除失败！" });
            }
        }
    }
}
