using System;
using System.Data;

namespace XF.IDAL
{
    public interface IXF_Groups
    {
        #region BaseMethod
        /// <summary>
        /// �жϷ����Ƿ����
        /// </summary>
        /// <param name="GroupName">��������</param>
        /// <returns></returns>
        bool Exists(string GroupName, int GroupType);

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ����</param>
        /// <returns></returns>
        int CreateGroup(XF.Model.XF_Groups model);

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ����</param>
        /// <returns></returns>
        bool UpdateGroup(XF.Model.XF_Groups model);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="GroupID">����ID</param>
        /// <returns></returns>
        int DeleteGroup(int GroupID);

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        /// <param name="GroupID">����ID</param>
        /// <returns></returns>
        XF.Model.XF_Groups GetGroupModel(int GroupID);

        /// <summary>
        /// ��÷��������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        DataSet GetGroupList(string strWhere, string strOrder);
        #endregion
        DataTable GetGroupListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count);
        int DeleteGroups(string IDs);
        #region ExtendMethod
        #endregion
    }
}

