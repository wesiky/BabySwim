using System;
using System.Collections;
using System.Data;

namespace XF.IDAL
{
    public interface IXF_Roles
	{

        #region 角色管理
        #region BaseMethod
        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <param name="RoleGroupID">角色分组ID</param>
        /// <returns></returns>
        bool RoleExists(string RoleName, int RoleGroupID);

        /// <summary>
        /// 增加角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        int CreateRole(XF.Model.XF_Roles model);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        bool UpdateRole(XF.Model.XF_Roles model);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        int DeleteRole(int RoleID);

        /// <summary>
        /// 获取角色实体
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        XF.Model.XF_Roles GetRoleModel(int RoleID);

        /// <summary>
        /// 获得角色数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetRoleList(string strWhere, string strOrder);

        #endregion
        #region ExtendMethod
        DataTable GetRoleListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count);
        int DeleteRoles(string IDs);
        #endregion

        #endregion

        #region 授权

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        bool RoleAuthorityExists(XF.Model.XF_RoleAuthorityList model);               

        /// <summary>
        /// 修改用户菜单权限
        /// </summary>
        bool UpdateUserAuthority(ArrayList list,string loginName);

        /// <summary>
        /// 读取用户的菜单权限
        /// </summary>
        DataSet GetUserAuthorityList(int UserID, int ModuleID);

        /// <summary>
        /// 修改角色菜单权限
        /// </summary>
        bool UpdateRoleAuthority(ArrayList list,string loginName);

        /// <summary>
        /// 读取角色的菜单权限
        /// </summary>
        DataSet GetRoleAuthorityList(int RoleID, int ModuleID);        

        /// <summary>
        /// 修改分组权限
        /// </summary>
        bool UpdateGroupAuthority(ArrayList list,string loginName);

        /// <summary>
        /// 读取分组的菜单权限
        /// </summary>
        DataSet GetGroupAuthorityList(int GroupID, int ModuleID);

        #endregion
    }
}

