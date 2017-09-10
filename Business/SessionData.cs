using CommonFunciton;
using Model;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Business
{
    public class SessionData
    {
        public static UserInfoModel UserInfo
        {
            set
            {
                HttpContext.Current.Session[Constant.sesionKey.UserInfo] = value;
            }
            get
            {
                var person = HttpContext.Current.Session[Constant.sesionKey.UserInfo] as UserInfoModel;
                if (person == null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var business = new HomeBusiness();
                    person = business.Resign(Convert.ToInt32(HttpContext.Current.User.Identity.Name));
                    if (person != null)
                    {
                        SessionData.UserInfo = person;
                        bool remeber = !person.IsAdmin;
                        FormsAuthentication.SetAuthCookie(person.UserId.ToString(), remeber);
                    }
                    else
                    {
                        HttpContext.Current.Session.Clear();
                        FormsAuthentication.SignOut();
                    }
                }
                return person;
            }
        }
    }
}
