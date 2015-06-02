using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity
{
    public class UserInfo
    {
        private string _userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _email;
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _phone;
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _avatar = "/Resource/image/avatar1_small.jpg";
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        public static UserInfo LoginedUserInfo = null;
    }
}
