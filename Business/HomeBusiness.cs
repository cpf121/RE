using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HomeBusiness
    {
        private static HomeDAL _homeDal = new HomeDAL();
        public static bool UserLogin(string loginName, string password, string isAdmin, out string workNo)
        {
            return _homeDal.UserLogin(loginName, password, isAdmin, out workNo);
        }
    }
}
