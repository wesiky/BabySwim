using System;
using System.Collections;
using System.Data;

namespace XF.IDAL
{
	/// <summary>
	/// 业务逻辑类XF_Users 的摘要说明。
	/// </summary>
	public interface IXF_Users
    {
        #region 用户操作
        #region BaseMethod
        /// <summary>
        /// 用户是否存在
        /// </summary>
        bool UserExists(string UserName);

        /// <summary>
        /// 创建一个新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int CreateUser(XF.Model.XF_Users model);

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        int UpdateUser(XF.Model.XF_Users model);
        
        /// <summary>
        /// 用户登录检测
        /// </summary>
        bool CheckLogin(string UserName,string pwd);

        /// <summary>
        /// 更新用户登录时间
        /// </summary>
        /// <param name="id"></param>
        void UpdateLoginTime(int id);

        /// <summary>
        /// 判断用户原密码是否正确
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">原密码</param>
        /// <returns></returns>
        bool VerifyPassword(int id, string pwd);
        
        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        bool ChangePassword(int id, string pwd);
      
        /// <summary>
        /// 更新安全信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="question">问题</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        bool ChangeSecureInfo(int id, string question, string answer);      

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserID">用户ID</param>
        bool DeleteUser(int UserID);
        
        /// <summary>
        /// 根据ID得到用户对象实体
        /// </summary>
        XF.Model.XF_Users GetUserModel(int UserID);
       
        /// <summary>
        /// 根据用户名得到用户对象实体
        /// </summary>
        XF.Model.XF_Users GetUserModel(string UserName);

        /// <summary>
        /// 根据真实姓名得到用户对象实体
        /// </summary>
        XF.Model.XF_Users GetUserModelByRealName(string RealName);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetUserList(string strWhere, string strOrder);
        #endregion

        #region ExtendMethod
        DataTable GetUserListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="IDs">用户ID集合</param>
        bool DeleteUsers(string IDs);
        #endregion
        #endregion

        #region 角色操作
        #region BaseMethod
        /// <summary>
        /// 读取角色名称
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        object GetRoleName(int roleid);


        /// <summary>
        /// 添加一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        bool addUserRole(int UserID, int RoleID,string LoginName);

        /// <summary>
        /// 批量添加用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool addUserRole(ArrayList list,string loginName);

        /// <summary>
        /// 删除一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        bool DeleteUserRole(int UserID, int RoleID);

        /// <summary>
        /// 批量删除用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteUserRole(ArrayList list);

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        DataSet GetUserRole(int UserID);

         /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        ArrayList GetUserRoleArray(int UserID);

        #endregion
        #endregion
    }
}

