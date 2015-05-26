using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace Tools
{
    public class XConfig
    {
        /// <summary>
        /// 获得值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="isDecode">是否解码</param>
        /// <returns>结果</returns>
        public static T GetValue<T>(string key, bool isDecode = true)
        {
            var value = ConfigurationManager.AppSettings[key];
            var type = typeof(T);
            if (type == typeof(string) && isDecode)
            {
                value = HttpUtility.HtmlDecode(value);
            }
            if (type.IsEnum)
            {
                return (T)Enum.Parse(type, value, true);
            }
            else
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
        }

        /// <summary>
        /// 获得值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="split">分割符</param>
        /// <param name="isDecode">是否解码</param>
        /// <returns>结果</returns>
        public static T[] GetValues<T>(string key, char split = '|', bool isDecode = true)
        {
            var value = ConfigurationManager.AppSettings[key];
            return ParseArray<T>(value, split, isDecode);
        }

        /// <summary>
        /// 解析为数组
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="value">值</param>
        /// <param name="split">分割符</param>
        /// <param name="isDecode">是否解码</param>
        /// <returns>结果</returns>
        public static T[] ParseArray<T>(string value, char split = '|', bool isDecode = true)
        {
            var type = typeof(T);
            if (type == typeof(string) && isDecode)
            {
                value = HttpUtility.HtmlDecode(value);
            }
            T[] array = null;
            if (!string.IsNullOrEmpty(value))
            {
                array = value.Split(split).Select(item =>
                {
                    if (type.IsEnum)
                    {
                        return (T)Enum.Parse(type, item, true);
                    }
                    else
                    {
                        return (T)Convert.ChangeType(item, typeof(T));
                    }
                }).ToArray();
            }
            return array;
        }

    }
}
