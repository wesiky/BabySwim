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
	/// 业务逻辑类XF_Roles 的摘要说明。
	/// </summary>
	public class XF_Roles
	{
        private readonly IXF_Roles dal = DataAccess.CreateXF_Roles();

		public XF_Roles()
		{ }

        #region 角色管理

        #region BaseMethod
        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <param name="RoleGroupID">角色分组ID</param>
        /// <returns></returns>
        public bool RoleExists(string RoleName, int RoleGroupID)
        {
            return dal.RoleExists(RoleName, RoleGroupID);
        }

        /// <summary>
        /// 增加角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        public int CreateRole(XF.Model.XF_Roles model)
        {
            if (!RoleExists(model.RoleName, model.RoleGroupID))
                return dal.CreateRole(model);
            else
                return -1;
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        public bool UpdateRole(XF.Model.XF_Roles model)
        {
            return dal.UpdateRole(model);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public int DeleteRole(int RoleID)
        {
            return dal.DeleteRole(RoleID);
        }

        /// <summary>
        /// 获取角色实体
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public XF.Model.XF_Roles GetRoleModel(int RoleID)
        {
            return dal.GetRoleModel(RoleID);
        }

        /// <summary>
        /// 获得角色数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetRoleList(string strWhere, string strOrder)
        {
            return dal.GetRoleList(strWhere, strOrder);
        }

        #endregion

        #region ExtendMethod
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataTable GetRoleListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            return dal.GetRoleListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
        }
        public int DeleteRoles(string IDs)
        {
            return dal.DeleteRoles(IDs);
        }
        #endregion

        #endregion

        #region 授权

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        public bool RoleAuthorityExists(XF.Model.XF_RoleAuthorityList model)
        {
            return dal.RoleAuthorityExists(model);
        }      

        /// <summary>
        /// 修改用户菜单权限
        /// </summary>
        public bool UpdateUserAuthority(ArrayList list,string loginName)
        {
            return dal.UpdateUserAuthority(list,loginName);
        }
        
        /// <summary>
        /// 读取用户的菜单权限
        /// </summary>
        public DataSet GetUserAuthorityList(int UserID, int ModuleID)
        {
            return dal.GetUserAuthorityList(UserID, ModuleID);
        }

        /// <summary>
        /// 修改角色菜单权限
        /// </summary>
        public bool UpdateRoleAuthority(ArrayList list,string loginName)
        {
            return dal.UpdateRoleAuthority(list,loginName);
        }

        /// <summary>
        /// 读取角色的菜单权限
        /// </summary>
        public DataSet GetRoleAuthorityList(int RoleID, int ModuleID)
        {
            return dal.GetRoleAuthorityList(RoleID, ModuleID);
        }

        /// <summary>
        /// 修改分组权限
        /// </summary>
        public bool UpdateGroupAuthority(ArrayList list,string loginName)
        {
            return dal.UpdateGroupAuthority(list,loginName);
        }

        /// <summary>
        /// 读取分组权限
        /// </summary>
        public DataSet GetGroupAuthorityList(int GroupID, int ModuleID)
        {
            return dal.GetGroupAuthorityList(GroupID, ModuleID);
        }  
        #endregion
    }
}

