using System;
using System.Data;
using System.Collections.Generic;

using XF.Lib;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;

namespace XF.BLL
{
	/// <summary>
	/// ҵ���߼���XF_Groups ��ժҪ˵����
	/// </summary>
	public class XF_Groups
	{
        private readonly IXF_Groups dal = DataAccess.CreateXF_Groups();

		public XF_Groups()
		{}

        #region BaseMethod
        /// <summary>
        /// �жϷ����Ƿ����
        /// </summary>
        /// <param name="GroupName">��������</param>
        /// <returns></returns>
        public bool Exists(string GroupName, int GroupType)
        {
            return dal.Exists(GroupName, GroupType);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ����</param>
        /// <returns></returns>
        public int CreateGroup(XF.Model.XF_Groups model)
        {
            if (dal.Exists(model.GroupName,model.GroupType))
            {
                return -1;
            }
            else
            {
                return dal.CreateGroup(model);
            }
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">����ʵ����</param>
        /// <returns></returns>
        public bool UpdateGroup(XF.Model.XF_Groups model)
        {
            return dal.UpdateGroup(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="GroupID">����ID</param>
        /// <returns></returns>
        public int DeleteGroup(int GroupID)
        {
            return dal.DeleteGroup(GroupID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        /// <param name="GroupID">����ID</param>
        /// <returns></returns>
        public XF.Model.XF_Groups GetGroupModel(int GroupID)
        {
            return dal.GetGroupModel(GroupID);
        }

        /// <summary>
        /// ��÷��������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetGroupList(string strWhere, string strOrder)
        {
            return dal.GetGroupList(strWhere, strOrder);
        }
        #endregion

        #region ExtendMethod
        /// <summary>
        /// ��÷�ҳ�����б�
        /// </summary>
        public DataTable GetGroupListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            return dal.GetGroupListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
        }
        public int DeleteGroups(string IDs)
        {
            return dal.DeleteGroups(IDs);
        }
        #endregion
    }
}

