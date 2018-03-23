using EohiSHM.AdmDAL;
using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EohiSHM.Controllers
{
    [LoginCheckFilter(IsNeedLogin = false)]
    public class UserLoginController : BaseController
    {
        //
        // GET: /Admin/Login/
        //
        // GET: /Admin/Login/
        AdmUnitOfWork<Web_admin_account> Db = new AdmUnitOfWork<Web_admin_account>();
        public ActionResult Index()
        {
            //ssGetRegionCode();
            ViewBag.ReturnUrl = Request.QueryString["ReturnUrl"];
            if (TempData.ContainsKey("loginerr"))
            {
                string err = TempData["loginerr"].ToString();
                string errmsg = TempData["loginerrmsg"].ToString();
                ViewBag.err = err;
                ViewBag.errmsg = errmsg;
            }
            return View();
            //return PartialView();//会将页面的Layout自动设为null
        }
        private void GetList()
        {

        }


        public ActionResult Login(Web_admin_account adminAccount, string ReturnUrl, string code)
        {
            if (string.IsNullOrEmpty(code) || Session["code"] == null)
            {
                TempData["loginerr"] = "err";
                TempData["loginerrmsg"] = "验证码已失效";
                return RedirectToAction("Index", "UserLogin", ViewBag);
            }
            else
            {
                if (code.ToLower() != Session["code"].ToString().ToLower())
                {
                    TempData["loginerr"] = "err";
                    TempData["loginerrmsg"] = "验证码错误";
                    return RedirectToAction("Index", "UserLogin", ViewBag);
                }
            }

            Web_admin_account user = Db.GenericRepository.Get(u => u.Accountname == adminAccount.Accountname);
            if (user == null)
            {
                //登陆失败;
                //ViewBag.err = "err";
                //ViewBag.errmsg = "账号未注册！";
                TempData["loginerr"] = "err";
                TempData["loginerrmsg"] = "账号未注册";
                return RedirectToAction("Index", "UserLogin", ViewBag);
            }
            else
            {
                //判断密码;
                if (user.Psw != adminAccount.Psw)
                {
                    //登陆失败
                    TempData["loginerr"] = "err";
                    TempData["loginerrmsg"] = "密码错误";
                    return RedirectToAction("Index", "UserLogin", ViewBag);
                }
                else
                {
                    //登陆成功;
                    CreateSession(user);
                    var ggg = Request.UrlReferrer.OriginalString;
                    Session["RegionCode"] = null;
                    //跳转
                    if (string.IsNullOrEmpty(ReturnUrl))
                    {

                        return RedirectToAction("Index", "Home");//如果登录成功跳转的页面。

                    }
                    else
                    {
                        return Redirect(ReturnUrl);

                    }
                }
            }

        }



        private void CreateSession(Web_admin_account user)
        {
            //session处理;
            Web_admin_account entity = new Web_admin_account();
            entity.Accountname = user.Accountname;
            //entity.pwd = "";
            HttpContext.Session["admin"] = entity;
        }


        public ActionResult Logout()
        {
            //
            HttpContext.Session["admin"] = null;

            return RedirectToAction("Index", "UserLogin");
        }
        //获取验证码
        public ActionResult Get()
        {
            Common.ValidateCode ValidateCode = new Common.ValidateCode();
            string code = ValidateCode.CreateValidateCode(4);//生成验证码，传几就是几位验证码
            Session["code"] = code;
            byte[] buffer = ValidateCode.CreateValidateGraphic(code);//把验证码画到画布
            return File(buffer, "image/jpeg");
        }
        //

    }
}
