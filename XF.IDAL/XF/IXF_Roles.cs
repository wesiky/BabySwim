using System;
using System.Collections;
using System.Data;

namespace XF.IDAL
{
    public interface IXF_Roles
	{

        #region ��ɫ����
        #region BaseMethod
        /// <summary>
        /// �жϽ�ɫ�Ƿ����
        /// </summary>
        /// <param name="RoleName">��ɫ����</param>
        /// <param name="RoleGroupID">��ɫ����ID</param>
        /// <returns></returns>
        bool RoleExists(string RoleName, int RoleGroupID);

        /// <summary>
        /// ���ӽ�ɫ
        /// </summary>
        /// <param name="model">��ɫʵ����</param>
        /// <returns></returns>
        int CreateRole(XF.Model.XF_Roles model);

        /// <summary>
        /// ���½�ɫ
        /// </summary>
        /// <param name="model">��ɫʵ����</param>
        /// <returns></returns>
        bool UpdateRole(XF.Model.XF_Roles model);

        /// <summary>
        /// ɾ����ɫ
        /// </summary>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        int DeleteRole(int RoleID);

        /// <summary>
        /// ��ȡ��ɫʵ��
        /// </summary>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        XF.Model.XF_Roles GetRoleModel(int RoleID);

        /// <summary>
        /// ��ý�ɫ�����б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        DataSet GetRoleList(string strWhere, string strOrder);

        #endregion
        #region ExtendMethod
        DataTable GetRoleListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count);
        int DeleteRoles(string IDs);
        #endregion

        #endregion

        #region ��Ȩ

        /// <summary>
        /// �жϼ�¼�Ƿ����
        /// </summary>
        bool RoleAuthorityExists(XF.Model.XF_RoleAuthorityList model);               

        /// <summary>
        /// �޸��û��˵�Ȩ��
        /// </summary>
        bool UpdateUserAuthority(ArrayList list,string loginName);

        /// <summary>
        /// ��ȡ�û��Ĳ˵�Ȩ��
        /// </summary>
        DataSet GetUserAuthorityList(int UserID, int ModuleID);

        /// <summary>
        /// �޸Ľ�ɫ�˵�Ȩ��
        /// </summary>
        bool UpdateRoleAuthority(ArrayList list,string loginName);

        /// <summary>
        /// ��ȡ��ɫ�Ĳ˵�Ȩ��
        /// </summary>
        DataSet GetRoleAuthorityList(int RoleID, int ModuleID);        

        /// <summary>
        /// �޸ķ���Ȩ��
        /// </summary>
        bool UpdateGroupAuthority(ArrayList list,string loginName);

        /// <summary>
        /// ��ȡ����Ĳ˵�Ȩ��
        /// </summary>
        DataSet GetGroupAuthorityList(int GroupID, int ModuleID);

        #endregion
    }
}

