﻿
using Model.Home;
using Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RoechlingEquipment.Controllers
{
    public class BaseController : Controller
    {


        /// <summary>
        /// 登录用户
        /// </summary>
        public UserLoginInfo LoginUser
        {
            get { return LoginHelper.GetUser(); }
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = RouteData.Values["culture"] as string;

            // Attempt to read the culture cookie from Request
            if (cultureName == null)
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe


            if (RouteData.Values["culture"] as string != cultureName)
            {

                // Force a valid culture in the URL
                RouteData.Values["culture"] = cultureName.ToLowerInvariant(); // lower case too

                // Redirect user
                Response.RedirectToRoute(RouteData.Values);
            }


            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;


            return base.BeginExecuteCore(callback, state);
        }


        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                if (LoginUser != null) return;

                var redirectUri = string.Empty;
                if (Request.Url != null)
                {
                    redirectUri = Request.Url.ToString();
                    var thiscntroller = RouteData.Values["controller"].ToString().ToLower();
                    var thisaction = RouteData.Values["action"].ToString().ToLower();
                    if (thiscntroller == "saashome" && thisaction == "index")
                    {
                        redirectUri = string.Empty;
                    }
                }
                var url = "";//TODO
                var content = new ContentResult { Content = GetNoLoginScript(url) };
                filterContext.Result = content;
            }
            catch (Exception ex)
            {
                #region 系统异常记录天网日志

                var userinfo = LoginUser;
                var jobnum = userinfo == null ? "" : userinfo.UserName;

                #endregion
            }
        }

        public string GetNoLoginScript(string returnUrl)
        {
            var sbScript = new StringBuilder();
            sbScript.Append("<script type='text/javascript'>");
            sbScript.AppendFormat("window.location.href='{0}';", returnUrl);
            sbScript.Append("</script>");
            return sbScript.ToString();
        }
    }
}