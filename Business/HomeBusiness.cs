using CommonFunciton.Enum;
using DataAccess;
using Model;
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
        private static AccountDAL _accountDal=new AccountDAL();
        private static UserDAL _userdal = new UserDAL();
        public static bool UserLogin(string loginName, string password, string isAdmin, out string workNo)
        {
            return _homeDal.UserLogin(loginName, password, isAdmin, out workNo);
        }

        public static UserInfoModel Login(string account, string password)
        {
            var userInfo = new UserInfoModel();
            //根据账号密码获取用户id
            //密码需要加密？？
            var accountInfo = _accountDal.GetAccountByAccount(account);
            if (accountInfo == null)
            {
                throw new Exception("您输入的账号不存在，请先注册。");
            }
            //验证密码是否正确
            if (accountInfo.BAPassword != password)
            {
                throw new Exception("用户名或密码不正确");
            }
            if (accountInfo.BAIsValid == EnabledEnum.UnEnabled.GetHashCode())
            {
                throw new Exception("该账户已无效");
            }
            var user = _userdal.GetUserById(accountInfo.BAUserId);
            if(user!=null)
            {
                if (user.BUIsValid == EnabledEnum.UnEnabled.GetHashCode())
                {
                    throw new Exception("该用户已无效");
                }
                userInfo.UserId = accountInfo.BAUserId;
                userInfo.Surname = user.BUSurname;
                userInfo.Givenname = user.BUGivenname;
                userInfo.JobNumber = user.BUJobNumber;
                userInfo.Sex = user.BUSex;
                userInfo.Avatars = user.BUAvatars;
                userInfo.PhoneNum = user.BUPhoneNum;
                userInfo.Email = user.BUEmail;
                userInfo.DepartId = user.BUDepartId;
                userInfo.IsAdmin = accountInfo.BAType == AccountType.Admin.GetHashCode() ? true : false;
            }
            return userInfo;
        }

        /// <summary>
        /// 描述：根据用户Id获取用户基础信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfoModel Resign(int userId)
        {
            var userInfo = new UserInfoModel();
            var user = _userdal.GetUserById(userId);
            var accountInfo = _accountDal.GetAccountByAccount(userId);
            if (user != null && accountInfo != null)
            {
                userInfo.UserId = accountInfo.BAUserId;
                userInfo.Surname = user.BUSurname;
                userInfo.Givenname = user.BUGivenname;
                userInfo.JobNumber = user.BUJobNumber;
                userInfo.Sex = user.BUSex;
                userInfo.Avatars = user.BUAvatars;
                userInfo.PhoneNum = user.BUPhoneNum;
                userInfo.Email = user.BUEmail;
                userInfo.DepartId = user.BUDepartId;
                userInfo.IsAdmin = accountInfo.BAType == AccountType.Admin.GetHashCode() ? true : false;
            }
            return userInfo;
        }
    }
}
