using Business;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RoechlingEquipment.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Demo()
        {
            return View();
        }

        }

        public ActionResult Login(LoginModel model)
        {
            var msg = string.Empty;
            var success = false;

            try
            {
                var result = HomeBusiness.Login(model.Account,model.PassWord);
                bool remeber = !result.IsAdmin;
                FormsAuthentication.SetAuthCookie(result.UserId.ToString(), remeber);
                SessionData.UserInfo = result;
                success = true;
                msg = "登录成功";
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return Json(new { Message = msg, Success = success });
    }
}
