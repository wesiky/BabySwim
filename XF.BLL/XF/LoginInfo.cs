using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace XF.BLL
{
    public class LoginInfo
    {
        /// <summary>
        /// 初始化用户登录信息
        /// </summary>
        /// <param name="_loginId">用户ID</param>
        /// <param name="_loginname">用户名</param>
        /// <param name="_roleid">角色ID</param>
        /// <param name="_groupid">分组ID</param>
        /// <param name="_islimit">是否授权限限制</param>
        /// <param name="_status">用户状态</param>
        public LoginInfo(int _loginId, string _loginname, DateTime _loginTime, ArrayList _roleid, int _groupid, bool _islimit, int _status, string _phone, string _email, int _warehouseid, string _lgort, string _mrp)
        {
            LoginInfo.LoginId = _loginId;
            LoginInfo.LoginName = _loginname;
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

        public static ArrayList ModuleList;
        public static ArrayList AuthorityList;
        public static int? LoginId;
        public static string LoginName;
        public static string RealName;
        public static DateTime? LoginTime;
        public static ArrayList RoleID;
        public static int? GroupID;
        public static bool? IsLimit;
        public static int? Status;
        public static int? WarehouseID;
        public static string Email;
        public static string Phone;
        public static string LGORT;
        public static string MRP;
    }
}
