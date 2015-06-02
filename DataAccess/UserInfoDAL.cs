using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using Identity;
using Tools;

namespace DataAccess
{
    public static class UserInfoDAL
    {
        public static UserInfo GetUserInfo(string userName, string password)
        {
            string dataPath = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            string xmlData = XFileOperate.ReadFile(dataPath);
            DataSet dataSet = XXMLHelper.ConvertXMLToDataSet(xmlData);
            // 查找第一个满足条件的数据
            DataRow userInfoRow = dataSet.Tables["UserInfo"].AsEnumerable().FirstOrDefault(row => row["userName"].ToString() == userName && row["password"].ToString() == password);
            if (userInfoRow != null)
            {
                return new UserInfo()
                {
                    UserName = userInfoRow["userName"].ToString(),
                    Email = userInfoRow["email"].ToString(),
                    Phone = userInfoRow["phone"].ToString()
                };
            }
            else
            {
                return null;
            }
        }
    }
}
