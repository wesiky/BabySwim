using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace XF.BLL
{
    public class LoginOptioner
    {

        #region 用户Session操作

        /// <summary>
        /// 校验是否登陆
        /// </summary>
        /// <returns></returns>
        public static bool CheckLogin()
        {
            if (LoginInfo.LoginTime == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 保存登陆信息
        /// </summary>
        /// <param name="userinfo"></param>
        public static void SaveLoginInfo(int _loginId, string _loginname, string _realName, DateTime _loginTime, ArrayList _roleid, int _groupid, bool _islimit, int _status,string _phone,string _email,int _warehouseid,string _lgort,string _mrp)
        {
            LoginInfo.LoginId = _loginId;
            LoginInfo.LoginName = _loginname;
            LoginInfo.RealName = _realName;
            LoginInfo.LoginTime = _loginTime;
            LoginInfo.RoleID = _roleid;
            LoginInfo.GroupID = _groupid;
            LoginInfo.IsLimit = _islimit;
            LoginInfo.Status = _status;
            LoginInfo.Phone = _phone;
            LoginInfo.Email = _email;
            LoginInfo.WarehouseID = _warehouseid;
            LoginInfo.LGORT = _lgort;
            LoginInfo.MRP = _mrp;
        }

        /// <summary>
        /// 移除User Session
        /// </summary>
        public static void LogOffUser()
        {
            LoginInfo.LoginId = null;
            LoginInfo.LoginName = null;
            LoginInfo.LoginTime = null;
            LoginInfo.RoleID = null;
            LoginInfo.GroupID = null;
            LoginInfo.IsLimit = null;
            LoginInfo.Status = null;
            LoginInfo.Phone = null;
            LoginInfo.Email = null;
            LoginInfo.WarehouseID = null;
            LoginInfo.LGORT = null;
            LoginInfo.MRP = null;
            LoginInfo.ModuleList = null;
            LoginInfo.AuthorityList = null;
        }

        #endregion

        #region 菜单Session操作

        /// <summary>
        /// 登记Moudule Session
        /// </summary>
        /// <param name="lists"></param>
        public static void CreateModuleList(ArrayList lists)
        {
            LoginInfo.ModuleList = lists;
        }

        /// <summary>
        /// 读取菜单权限
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetModuleList()
        {
            if (LoginInfo.ModuleList == null) throw new Exception("读取权限失败。");
            else return LoginInfo.ModuleList;
        }

        /// <summary>
        /// 移除菜单权限
        /// </summary>
        public static void RemoveModuleList()
        {
            LoginInfo.ModuleList = null;
        }

        #endregion

        #region 当前已登录会员对当前菜单的权限集合

        /// <summary>
        /// 创建菜单权限列表
        /// </summary>
        /// <param name="lists"></param>
        public static void CreateAuthority(ArrayList lists)
        {
            LoginInfo.AuthorityList = lists;
        }

        /// <summary>
        /// 读取菜单权限
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetAuthority()
        {
            if (LoginInfo.AuthorityList == null) throw new Exception("读取权限失败。");
            else return LoginInfo.AuthorityList;
        }

        /// <summary>
        /// 移除菜单权限
        /// </summary>
        public static void RemoveAuthority()
        {
            LoginInfo.AuthorityList = null;
        }

        #endregion
    }
}
