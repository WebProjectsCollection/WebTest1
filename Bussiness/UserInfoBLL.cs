using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess;
using Identity;

namespace Bussiness
{
    public class UserInfoBLL
    {
        public static bool CheckUserInfo(string userName, string password)
        {
            UserInfo loginedUser = UserInfoDAL.GetUserInfo(userName, password);
            if (loginedUser == null)
            {
                // 登录失败
                return false;
            }
            else
            {
                UserInfo.LoginedUserInfo = loginedUser;
                return true;
            }
        }
    }
}
