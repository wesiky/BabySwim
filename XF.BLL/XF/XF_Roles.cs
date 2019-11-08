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
	/// ҵ���߼���XF_Roles ��ժҪ˵����
	/// </summary>
	public class XF_Roles
	{
        private readonly IXF_Roles dal = DataAccess.CreateXF_Roles();

		public XF_Roles()
		{ }

        #region ��ɫ����

        #region BaseMethod
        /// <summary>
        /// �жϽ�ɫ�Ƿ����
        /// </summary>
        /// <param name="RoleName">��ɫ����</param>
        /// <param name="RoleGroupID">��ɫ����ID</param>
        /// <returns></returns>
        public bool RoleExists(string RoleName, int RoleGroupID)
        {
            return dal.RoleExists(RoleName, RoleGroupID);
        }

        /// <summary>
        /// ���ӽ�ɫ
        /// </summary>
        /// <param name="model">��ɫʵ����</param>
        /// <returns></returns>
        public int CreateRole(XF.Model.XF_Roles model)
        {
            if (!RoleExists(model.RoleName, model.RoleGroupID))
                return dal.CreateRole(model);
            else
                return -1;
        }

        /// <summary>
        /// ���½�ɫ
        /// </summary>
        /// <param name="model">��ɫʵ����</param>
        /// <returns></returns>
        public bool UpdateRole(XF.Model.XF_Roles model)
        {
            return dal.UpdateRole(model);
        }

        /// <summary>
        /// ɾ����ɫ
        /// </summary>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        public int DeleteRole(int RoleID)
        {
            return dal.DeleteRole(RoleID);
        }

        /// <summary>
        /// ��ȡ��ɫʵ��
        /// </summary>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        public XF.Model.XF_Roles GetRoleModel(int RoleID)
        {
            return dal.GetRoleModel(RoleID);
        }

        /// <summary>
        /// ��ý�ɫ�����б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetRoleList(string strWhere, string strOrder)
        {
            return dal.GetRoleList(strWhere, strOrder);
        }

        #endregion

        #region ExtendMethod
        /// <summary>
        /// ��÷�ҳ�����б�
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

        #region ��Ȩ

        /// <summary>
        /// �жϼ�¼�Ƿ����
        /// </summary>
        public bool RoleAuthorityExists(XF.Model.XF_RoleAuthorityList model)
        {
            return dal.RoleAuthorityExists(model);
        }      

        /// <summary>
        /// �޸��û��˵�Ȩ��
        /// </summary>
        public bool UpdateUserAuthority(ArrayList list,string loginName)
        {
            return dal.UpdateUserAuthority(list,loginName);
        }
        
        /// <summary>
        /// ��ȡ�û��Ĳ˵�Ȩ��
        /// </summary>
        public DataSet GetUserAuthorityList(int UserID, int ModuleID)
        {
            return dal.GetUserAuthorityList(UserID, ModuleID);
        }

        /// <summary>
        /// �޸Ľ�ɫ�˵�Ȩ��
        /// </summary>
        public bool UpdateRoleAuthority(ArrayList list,string loginName)
        {
            return dal.UpdateRoleAuthority(list,loginName);
        }

        /// <summary>
        /// ��ȡ��ɫ�Ĳ˵�Ȩ��
        /// </summary>
        public DataSet GetRoleAuthorityList(int RoleID, int ModuleID)
        {
            return dal.GetRoleAuthorityList(RoleID, ModuleID);
        }

        /// <summary>
        /// �޸ķ���Ȩ��
        /// </summary>
        public bool UpdateGroupAuthority(ArrayList list,string loginName)
        {
            return dal.UpdateGroupAuthority(list,loginName);
        }

        /// <summary>
        /// ��ȡ����Ȩ��
        /// </summary>
        public DataSet GetGroupAuthorityList(int GroupID, int ModuleID)
        {
            return dal.GetGroupAuthorityList(GroupID, ModuleID);
        }  
        #endregion
    }
}

