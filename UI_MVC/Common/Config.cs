﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Tools;

namespace UI_MVC.Common
{
    public static class Config
    {
        /// <summary>
        /// 获取配置文件版本
        /// </summary>
        public static string Version
        {
            get
            {
                return XConfig.GetValue<string>("Version");
            }
        }

        /// <summary>
        /// 是否为发布版本
        /// </summary>
        public static bool IsPublish
        {
            get
            {
                return XConfig.GetValue<bool>("IsPublish");
            }
        }

        /// <summary>
        /// 资源文件路径
        /// </summary>
        public static string ResourcePath
        {
            get
            {
                return XConfig.GetValue<string>("ResourcePath");
            }
        }
    }
}