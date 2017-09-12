
using Business;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoechlingEquipment.Controllers
{
    public class LoginController : UrlController
    {

        public ActionResult LoginPage()
        {
            // Validate input
            var workNo = string.Empty;
            //HomeBusiness.UserLogin("", "", "", out workNo);
            return View();
        }

    }
}
