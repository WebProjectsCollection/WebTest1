using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_MVC.Common;

namespace UI_MVC.Filters
{
    /// <summary>
    /// 表示需要用户登录才可以使用的特性
    /// 如果不需要处理用户登录，则请指定AllowAnonymousAttribute属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        #region 构造函数

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public AuthorizationAttribute()
        {
            // 读取配置文件设置参数
            string authUrl = Config.LoginUrl;
            string saveKey = Config.AuthSaveKey;
            string saveType = Config.AuthSaveType;

            if (false == string.IsNullOrEmpty(authUrl))
            {
                this._LoginUrl = authUrl;
            }
            if (false == string.IsNullOrEmpty(saveKey))
            {
                this._AuthSaveKey = saveKey;
            }
            if (false == string.IsNullOrEmpty(saveType))
            {
                this._AuthSaveType = saveType;
            }

        }

        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="loginUrl">表示没有登录跳转的登录地址</param>
        public AuthorizationAttribute(string loginUrl)
            : this()
        {
            this._LoginUrl = loginUrl;
        }

        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="authUrl">表示没有登录跳转的登录地址</param>
        /// <param name="saveKey">表示登录用来保存登陆信息的键名</param>
        public AuthorizationAttribute(string authUrl, string saveKey)
            : this(authUrl)
        {
            this.AuthSaveKey = saveKey;
        }

        /// <summary>
        /// 构造函数重载
        /// </summary>
        /// <param name="authUrl">表示没有登录跳转的登录地址</param>
        /// <param name="saveKey">表示登录用来保存登陆信息的键名</param>
        /// <param name="saveType">表示登录用来保存登陆信息的方式</param>
        public AuthorizationAttribute(string authUrl, string saveKey, string saveType)
            : this(authUrl, saveKey)
        {
            this._AuthSaveType = saveType;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 获取或者设置一个值，该值表示登录地址
        /// 如果web.config中末定义AuthUrl的值，则默认为：/user/login.html
        /// </summary>
        private string _LoginUrl = "/user/login.html";
        public string LoginUrl
        {
            get { return _LoginUrl.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("用于验证用户登录信息的登录地址不能为空！");
                }
                else
                {
                    _LoginUrl = value.Trim();
                }
            }
        }

        /// <summary>
        /// 获取或者设置一个值，该值表示Cookies/Session用来保存登陆信息的键名
        /// 如果web.config中末定义AuthSaveKey的值，则默认为LoginedUser
        /// </summary>
        private string _AuthSaveKey = "LoginedUser";
        public string AuthSaveKey
        {
            get { return _AuthSaveKey.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("用于保存登陆信息的键名不能为空！");
                }
                else
                {
                    this._AuthSaveKey = value.Trim();
                }
            }
        }

        /// <summary>
        /// 获取或者设置一个值，该值用来保存登录信息的方式
        /// 如果web.config中末定义AuthSaveType的值，则默认为Cookie保存
        /// </summary>
        private string _AuthSaveType = "Cookie";
        public string AuthSaveType
        {
            get { return _AuthSaveType.Trim().ToUpper(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("用于保存登陆信息的方式不能为空，只能为【Cookie】或者【Session】！");
                }
                else
                {
                    _AuthSaveType = value.Trim().ToUpper();
                }
            }
        }

        #endregion

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext == null)
            {
                throw new Exception("此特性只适合于Web应用程序使用！");
            }
            else
            {
                switch (AuthSaveType)
                {
                    case "SESSION":
                        if (filterContext.HttpContext.Session == null)
                        {
                            throw new Exception("服务器Session不可用！");
                        }
                        else if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                                && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                        {
                            if (filterContext.HttpContext.Session[AuthSaveKey] == null)
                            {
                                filterContext.Result = new RedirectResult(LoginUrl);
                            }
                        }
                        break;
                    case "COOKIE":
                        if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                            && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                        {
                            HttpCookie cookie = filterContext.HttpContext.Request.Cookies[AuthSaveKey];
                            if (cookie == null)
                            {
                                filterContext.Result = new RedirectResult(LoginUrl);
                            }
                            else if (cookie.Values["islocked"] == "islocked")
                            {
                                filterContext.Result = new RedirectResult("/Extra/Lock.html");
                            }
                        }
                        break;
                    default:
                        throw new ArgumentNullException("用于保存登陆信息的方式不能为空，只能为【Cookie】或者【Session】！");
                }
            }
        }

    }
}