using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using XF.Lib;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;

namespace XF.BLL
{
	/// <summary>
	/// 业务逻辑类XF_Users 的摘要说明。
	/// </summary>
	public class XF_Users
	{
        private readonly IXF_Users dal = DataAccess.CreateXF_Users();
		public XF_Users()
		{}
        #region 用户操作
        #region BaseMethod
        /// <summary>
        /// 用户是否存在
        /// </summary>
        public bool UserExists(string UserName)
        {
            return dal.UserExists(UserName);
        }

        /// <summary>
        /// 创建一个新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateUser(XF.Model.XF_Users model)
        {
            if (!UserExists(model.UserName))
            {
                return dal.CreateUser(model);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public int UpdateUser(XF.Model.XF_Users model)
        {
            return dal.UpdateUser(model);
        }

        /// <summary>
        /// 用户登录检测
        /// </summary>
        public bool CheckLogin(string UserName,string pwd)
        {
            return dal.CheckLogin(UserName, pwd);
        }

        /// <summary>
        /// 更新用户登录时间
        /// </summary>
        /// <param name="id"></param>
        public void UpdateLoginTime(int id)
        {
            dal.UpdateLoginTime(id);
        }

        /// <summary>
        /// 判断用户原密码是否正确
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">原密码</param>
        /// <returns></returns>
        public bool VerifyPassword(int id, string pwd)
        {
            return dal.VerifyPassword(id, pwd);
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        public bool ChangePassword(int id, string pwd)
        {
            return dal.ChangePassword(id, pwd);
        }

        /// <summary>
        /// 更新安全信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="question">问题</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        public bool ChangeSecureInfo(int id, string question, string answer)
        {
            return dal.ChangeSecureInfo(id, question, answer);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserID">用户ID</param>
        public bool DeleteUser(int UserID)
        {
            return dal.DeleteUser(UserID);
        }

        /// <summary>
        /// 根据ID得到用户对象实体
        /// </summary>
        public XF.Model.XF_Users GetUserModel(int UserID)
        {
            return dal.GetUserModel(UserID);
        }

        /// <summary>
        /// 根据用户名得到用户对象实体
        /// </summary>
        public XF.Model.XF_Users GetUserModel(string UserName)
        {
            return dal.GetUserModel(UserName);
        }

        /// <summary>
        /// 根据真实姓名得到用户对象实体
        /// </summary>
        public XF.Model.XF_Users GetUserModelByRealName(string RealName)
        {
            return dal.GetUserModelByRealName(RealName);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserList(string strWhere,string strOrder)
        {
            return dal.GetUserList(strWhere,strOrder);
        }

        /// <summary>
        /// 读取角色名称
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public object GetRoleName(int roleid)
        {
            return dal.GetRoleName(roleid);
        }
        #endregion
        #region ExtendMethod
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataTable GetUserListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            return dal.GetUserListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="IDs">用户ID集合</param>
        public bool DeleteUsers(string IDs)
        {
            return dal.DeleteUsers(IDs);
        }
        #endregion
        #endregion

        #region 角色操作
        #region BaseMethod
        /// <summary>
        /// 添加一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool addUserRole(int UserID, int RoleID,string LoginName)
        {
            return dal.addUserRole(UserID, RoleID, LoginName);
        }

        /// <summary>
        /// 批量添加用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool addUserRole(ArrayList list,string loginName)
        {
            return dal.addUserRole(list, loginName);
        }

        /// <summary>
        /// 删除一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool DeleteUserRole(int UserID, int RoleID)
        {
            return dal.DeleteUserRole(UserID, RoleID);
        }

        /// <summary>
        /// 批量删除用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteUserRole(ArrayList list)
        {
            return dal.DeleteUserRole(list);
        }

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetUserRole(int UserID)
        {
            return dal.GetUserRole(UserID);
        }

         /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ArrayList GetUserRoleArray(int UserID)
        {
            return dal.GetUserRoleArray(UserID);
        }

        #endregion

        #endregion
    }
}

