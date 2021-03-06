﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness;
using UI_MVC.Common;
using UI_MVC.Filters;

namespace UI_MVC.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// 如果用户未登录，返回登录页面；否则跳往首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]//匿名访问（这里是一个特例，表示这个方法不需要验证用户登录状态）
        public ActionResult Login()
        {
            // 验证Cookies，判断用户是否已经登录
            if (Request.Cookies[Config.AuthSaveKey] != null && Identity.UserInfo.LoginedUserInfo != null)
            {
                // 跳转到首页
                Response.Redirect("/");
                return null;
            }
            return View();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string userName, string password)
        {
            // 验证登录信息
            if (UserInfoBLL.CheckUserInfo(userName, password))
            {
                // 写Cookies
                HttpCookie _cookie = new HttpCookie(Config.AuthSaveKey);
                _cookie.Values.Add("name", userName);
                Response.Cookies.Add(_cookie);
                return Json(new { Message = "OK" });
            }
            else
            {
                return Json(new { Message = "Error" });
            }
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            // 清除登录用户的Cookies
            if (Request.Cookies[Config.AuthSaveKey] != null)
            {
                HttpCookie _cookie = Request.Cookies[Config.AuthSaveKey];
                _cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(_cookie);
            }
            Identity.UserInfo.LoginedUserInfo = null;
            Response.Redirect(Config.LoginUrl);
            return null;
        }

    }
}
