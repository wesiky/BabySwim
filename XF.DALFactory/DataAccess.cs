using System;
using System.Reflection;
using System.Configuration;
using XF.IDAL;
using XF.Lib;

namespace XF.DALFactory
{
    /// <summary>
    /// 抽象工厂模式
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DataDAL"];

        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }

        /// <summary>
        /// 创建Base_BOM数据层接口。
        /// </summary>
        public static XF.IDAL.ISysManage CreateSysManage()
        {
            string ClassNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.ISysManage)objType;
        }

        /// <summary>
        /// 创建权限标识数据层接口
        /// </summary>
        public static XF.IDAL.IXF_AuthorityDir CreateXF_AuthorityDir()
        {
            string ClassNamespace = AssemblyPath + ".XF_AuthorityDir";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IXF_AuthorityDir)objType;
        }

        /// <summary>
        /// 创建系统配置数据层接口
        /// </summary>
        public static XF.IDAL.IXF_Configuration CreateXF_Configuration()
        {

            string ClassNamespace = AssemblyPath + ".XF_Configuration";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IXF_Configuration)objType;
        }

        /// <summary>
        /// 创建分组数据层接口
        /// </summary>
        public static XF.IDAL.IXF_Groups CreateXF_Groups()
        {
            string ClassNamespace = AssemblyPath + ".XF_Groups";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IXF_Groups)objType;
        }

        /// <summary>
        /// 创建菜单管理数据层接口
        /// </summary>
        public static XF.IDAL.IXF_Modules CreateXF_Modules()
        {
            string ClassNamespace = AssemblyPath + ".XF_Modules";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IXF_Modules)objType;
        }

        /// <summary>
        /// 创建角色管理数据层接口
        /// </summary>
        public static XF.IDAL.IXF_Roles CreateXF_Roles()
        {
            string ClassNamespace = AssemblyPath + ".XF_Roles";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IXF_Roles)objType;
        }

        /// <summary>
        /// 创建用户数据层接口
        /// </summary>
        public static XF.IDAL.IXF_Users CreateXF_Users()
        {
            string ClassNamespace = AssemblyPath + ".XF_Users";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IXF_Users)objType;
        }

        /// <summary>
        /// 创建XF_UserGroup数据层接口
        /// </summary>
        public static XF.IDAL.IXF_UserGroup CreateXF_UserGroup()
        {
            string ClassNamespace = AssemblyPath + ".XF_UserGroup";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IXF_UserGroup)objType;
        }
        /// <summary>
        /// 创建Assist_Notice数据层接口。
        /// </summary>
        public static XF.IDAL.IAssist_Notice CreateAssist_Notice()
        {

            string ClassNamespace = AssemblyPath + ".Assist_Notice";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IAssist_Notice)objType;
        }

        /// <summary>
        /// 创建Base_Course数据层接口。
        /// </summary>
        public static XF.IDAL.IBase_Course CreateBase_Course()
        {

            string ClassNamespace = AssemblyPath + ".Base_Course";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IBase_Course)objType;
        }

        /// <summary>
        /// 创建Base_Customer数据层接口。
        /// </summary>
        public static XF.IDAL.IBase_Customer CreateBase_Customer()
        {

            string ClassNamespace = AssemblyPath + ".Base_Customer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IBase_Customer)objType;
        }

        /// <summary>
        /// 创建Base_Family数据层接口。
        /// </summary>
        public static XF.IDAL.IBase_Family CreateBase_Family()
        {

            string ClassNamespace = AssemblyPath + ".Base_Family";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IBase_Family)objType;
        }

        /// <summary>
        /// 创建Base_Student数据层接口。
        /// </summary>
        public static XF.IDAL.IBase_Student CreateBase_Student()
        {

            string ClassNamespace = AssemblyPath + ".Base_Student";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IBase_Student)objType;
        }

        /// <summary>
        /// 创建Base_Teacher数据层接口。
        /// </summary>
        public static XF.IDAL.IBase_Teacher CreateBase_Teacher()
        {

            string ClassNamespace = AssemblyPath + ".Base_Teacher";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.IBase_Teacher)objType;
        }

        /// <summary>
        /// 创建Course_Scheduler数据层接口。
        /// </summary>
        public static XF.IDAL.ICourse_Scheduler CreateCourse_Scheduler()
        {

            string ClassNamespace = AssemblyPath + ".Course_Scheduler";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.ICourse_Scheduler)objType;
        }

        /// <summary>
        /// 创建Course_Selection数据层接口。
        /// </summary>
        public static XF.IDAL.ICourse_Selection CreateCourse_Selection()
        {

            string ClassNamespace = AssemblyPath + ".Course_Selection";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.ICourse_Selection)objType;
        }

        /// <summary>
        /// 创建Course_SelectionStudent数据层接口。
        /// </summary>
        public static XF.IDAL.ICourse_SelectionStudent CreateCourse_SelectionStudent()
        {

            string ClassNamespace = AssemblyPath + ".Course_SelectionStudent";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.ICourse_SelectionStudent)objType;
        }
        
        /// <summary>
        /// 创建CreateCourse_ConfirmedStudent数据层接口。
        /// </summary>
        public static XF.IDAL.ICourse_ConfirmedStudent CreateCourse_ConfirmedStudent()
        {

            string ClassNamespace = AssemblyPath + ".Course_ConfirmedStudent";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.ICourse_ConfirmedStudent)objType;
        }

        /// <summary>
        /// 创建CreateCourse_Evaluate数据层接口。
        /// </summary>
        public static XF.IDAL.ICourse_Evaluate CreateCourse_Evaluate()
        {

            string ClassNamespace = AssemblyPath + ".Course_Evaluate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (XF.IDAL.ICourse_Evaluate)objType;
        }
    }
}
