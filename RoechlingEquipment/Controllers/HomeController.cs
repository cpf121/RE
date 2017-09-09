
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult LoginPage()
        {
            // Validate input
            var workNo = string.Empty;
            HomeBusiness.UserLogin("", "", "", out workNo);
            return View();
        }

    }
}
