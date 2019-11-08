using System;
using System.Collections;
using System.Data;

namespace XF.IDAL
{
    public interface IXF_Modules
	{

        #region �˵�����
        #region BaseMethod
        /// <summary>
        /// �жϲ˵������Ƿ����
        /// </summary>
        /// <param name="ModuleTypeName">�˵���������</param>
        /// <returns></returns>
        bool ModuleTypeExists(string ModuleTypeName);

        /// <summary>
        /// ����һ���˵�����
        /// </summary>
        /// <param name="model">�˵�����ʵ����</param>
        /// <returns></returns>
        int CreateModuleType(XF.Model.XF_ModuleType model);

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">�˵�����ʵ����</param>
        /// <returns></returns>
        bool UpdateModuleType(XF.Model.XF_ModuleType model);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="ModuleTypeID">�˵�����ID</param>
        /// <returns></returns>
        int DeleteModuleType(int ModuleTypeID);

        /// <summary>
        /// �õ�һ���˵�����ʵ��
        /// </summary>
        /// <param name="ModuleTypeID">�˵�����ID</param>
        /// <returns></returns>
        XF.Model.XF_ModuleType GetModuleTypeModel(int ModuleTypeID);

        /// <summary>
        /// ��ò˵����������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        DataSet GetModuleTypeList(string strWhere);

        #endregion

        #region ExtendMethod

        /// <summary>
        /// ��ò˵������¼�����
        /// </summary>
        /// <param name="id">����ID</param>
        /// <returns></returns>
        DataSet GetChildModuleTypeList(int id);

        /// <summary>
        /// ��ȡ�˵����
        /// </summary>
        /// <param name="ModuleTypeID">�˵�ID</param>
        /// <returns></returns>
        int GetModuleDepth(int ModuleTypeID);

        /// <summary>
        /// �жϲ˵��������Ƿ��в˵�
        /// </summary>
        /// <param name="ModuleTypeID">����iD</param>
        /// <returns></returns>
        bool HasChildModules(int ModuleTypeID);

        /// <summary>
        /// �жϲ˵��������Ƿ����Ӳ˵�����
        /// </summary>
        /// <param name="ModuleTypeID">����iD</param>
        /// <returns></returns>
        bool HasChildModuleType(int ModuleTypeID);
        #endregion
        #endregion

        #region �˵�����
        #region BaseMethod
        /// <summary>
        /// �жϲ˵��Ƿ����
        /// </summary>
        /// <param name="ModuleName">�˵�����</param>
        /// <returns></returns>
        bool ModuleExists(string ModuleTag);

        /// <summary>
        /// ����ʱ�жϲ˵��Ƿ����
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <param name="ModuleName">�˵�����</param>
        /// <returns></returns>
        bool UpdateExists(int ModuleID, string ModuleTag);

        /// <summary>
        /// ����һ���˵�
        /// </summary>
        /// <param name="model">�˵�ʵ����</param>
        /// <returns></returns>
        int CreateModule(XF.Model.XF_Modules model);

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">�˵�ʵ����</param>
        /// <returns></returns>
        int UpdateModule(XF.Model.XF_Modules model);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        bool DeleteModule(int ModuleID);

        /// <summary>
        /// �õ�һ���˵�ʵ��
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        XF.Model.XF_Modules GetModuleModel(int ModuleID);

        /// <summary>
        /// ��ò˵������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        DataSet GetModuleList(string strWhere);

        /// <summary>
        /// ��ò˵������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <returns></returns>
        DataSet GetModuleList2(string strWhere);

        /// <summary>
        /// ��ȡ�˵�ID
        /// </summary>
        /// <param name="ModuleTag">�˵���ʶ</param>
        /// <returns></returns>
        int GetModuleID(string ModuleTag);

        /// <summary>
        /// �˵��Ƿ�ر�
        /// </summary>
        /// <param name="ModuleTag">�˵���ʶ</param>
        /// <returns></returns>
        bool IsModule(string ModuleTag);

        #endregion

        #region ExtendMethod
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        bool DeleteModules(string IDs);
        /// <summary>
        /// �õ�һ���˵�ʵ��
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        XF.Model.XF_Modules GetModuleModel(string ModuleTag);
        #endregion
        #endregion

        #region �˵���Ȩ

        #region BaseMethod
        /// <summary>
        /// ���Ӳ˵�Ȩ��
        /// </summary>
        /// <param name="list">Ȩ���б�</param>
        /// <returns></returns>
        bool CreateAuthorityList(ArrayList list,string loginName);

        /// <summary>
        /// ���²˵�Ȩ��
        /// </summary>
        bool UpdateAuthorityList(ArrayList list,string loginName);

        /// <summary>
        /// ɾ��ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        bool DeleteAuthority(int ModuleID);

        /// <summary>
        /// ���ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        DataSet GetAuthorityList(int ModuleID);

        /// <summary>
        /// ���ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        DataSet GetAuthorityNameList(int ModuleID);

        #endregion

        #region ExtendMethod
        DataSet GetAllAuthorityList(int ModuleID);
        DataSet GetModuleAuthorityList(int ModuleID);
        #endregion

        #endregion
    }
}

