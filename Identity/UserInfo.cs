using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity
{
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        public static UserInfo UserInfoEntity = null;
    }
}
