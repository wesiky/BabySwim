using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Drawing;

namespace Enums
{
    public class ConfigSetting
    {
        public static string ProjectName = ConfigurationManager.AppSettings["ProjectName"];//软件名称
        public static string ProjectIconPath = ConfigurationManager.AppSettings["ProjectIcon"];//默认图标途径
        public static Icon ProjectIcon = new System.Drawing.Icon(ConfigSetting.ProjectIconPath);//默认图标
        public static string TextForeColorName = ConfigurationManager.AppSettings["TextForeColor"];//标题颜色文本
        public static Color TextForeColor = ColorTranslator.FromHtml(TextForeColorName);//标题颜色
        public static string TryOutCourseID = ConfigurationManager.AppSettings["TryOutCourseID"];//试听课ID
        public static string EvaluateFilePath = ConfigurationManager.AppSettings["EvaluateFilePath"];//评价文件目录
        public static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];//Api地址
    }
}
