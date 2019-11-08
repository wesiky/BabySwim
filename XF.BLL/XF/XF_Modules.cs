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
    /// ҵ���߼���XF_Modules ��ժҪ˵����
    /// </summary>
    public class XF_Modules
    {
        private readonly IXF_Modules dal = DataAccess.CreateXF_Modules();

        public XF_Modules()
        { }

        #region �˵�����
        #region BaseMethod
        /// <summary>
        /// �жϲ˵������Ƿ����
        /// </summary>
        /// <param name="ModuleTypeName">�˵���������</param>
        /// <returns></returns>
        public bool ModuleTypeExists(string ModuleTypeName)
        {
            return dal.ModuleTypeExists(ModuleTypeName);
        }

        /// <summary>
        /// ����һ���˵�����
        /// </summary>
        /// <param name="model">�˵�����ʵ����</param>
        /// <returns></returns>
        public int CreateModuleType(XF.Model.XF_ModuleType model)
        {
            if (!ModuleTypeExists(model.ModuleTypeName))
                return dal.CreateModuleType(model);
            else
                return -1;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">�˵�����ʵ����</param>
        /// <returns></returns>
        public bool UpdateModuleType(XF.Model.XF_ModuleType model)
        {
            return dal.UpdateModuleType(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="ModuleTypeID">�˵�����ID</param>
        /// <returns></returns>
        public int DeleteModuleType(int ModuleTypeID)
        {
            if (dal.HasChildModules(ModuleTypeID))
            {
                return -1;
            }
            if (dal.HasChildModuleType(ModuleTypeID))
            {
                return -2;
            }
            return dal.DeleteModuleType(ModuleTypeID);
        }

        /// <summary>
        /// �õ�һ���˵�����ʵ��
        /// </summary>
        /// <param name="ModuleTypeID">�˵�����ID</param>
        /// <returns></returns>
        public XF.Model.XF_ModuleType GetModuleTypeModel(int ModuleTypeID)
        {
            return dal.GetModuleTypeModel(ModuleTypeID);
        }

        /// <summary>
        /// ��ò˵����������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetModuleTypeList(string strWhere)
        {
            return dal.GetModuleTypeList(strWhere);
        }

        #endregion
        #region ExtendMethod
        /// <summary>
        /// ��ò˵������¼�����
        /// </summary>
        /// <param name="id">����ID</param>
        /// <returns></returns>
        public DataSet GetChildModuleTypeList(int id)
        {
            return dal.GetChildModuleTypeList(id);
        }

        /// <summary>
        /// ��ȡ�˵����
        /// </summary>
        /// <param name="ModuleTypeID">�˵�ID</param>
        /// <returns></returns>
        public int GetModuleDepth(int ModuleTypeID)
        {
            return dal.GetModuleDepth(ModuleTypeID);
        }

        /// <summary>
        /// �жϲ˵��������Ƿ��в˵�
        /// </summary>
        /// <param name="ModuleTypeID">����iD</param>
        /// <returns></returns>
        public bool HasChildModules(int ModuleTypeID)
        {
            return dal.HasChildModules(ModuleTypeID);
        }

        /// <summary>
        /// �жϲ˵��������Ƿ����Ӳ˵�����
        /// </summary>
        /// <param name="ModuleTypeID">����iD</param>
        /// <returns></returns>
        public bool HasChildModuleType(int ModuleTypeID)
        {
            return dal.HasChildModuleType(ModuleTypeID);
        }
        #endregion
        #endregion

        #region �˵�����

        #region BaseMethod
        /// <summary>
        /// �жϲ˵��Ƿ����
        /// </summary>
        /// <param name="ModuleName">�˵�����</param>
        /// <returns></returns>
        public bool ModuleExists(string ModuleTag)
        {
            return dal.ModuleExists(ModuleTag);
        }

        /// <summary>
        /// ����ʱ�жϲ˵��Ƿ����
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <param name="ModuleName">�˵�����</param>
        /// <returns></returns>
        public bool UpdateExists(int ModuleID, string ModuleTag)
        {
            return dal.UpdateExists(ModuleID, ModuleTag);
        }

        /// <summary>
        /// ����һ���˵�
        /// </summary>
        /// <param name="model">�˵�ʵ����</param>
        /// <returns></returns>
        public int CreateModule(XF.Model.XF_Modules model)
        {
            if (!ModuleExists(model.ModuleTag))
            {
                return dal.CreateModule(model);
            }
            else
                return -1;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">�˵�ʵ����</param>
        /// <returns></returns>
        public int UpdateModule(XF.Model.XF_Modules model)
        {
            if (!UpdateExists(model.ModuleID, model.ModuleTag))
            {
                return dal.UpdateModule(model);
            }
            else
                return -1;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public bool DeleteModule(int ModuleID)
        {
            return dal.DeleteModule(ModuleID);
        }

        /// <summary>
        /// �õ�һ���˵�ʵ��
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public XF.Model.XF_Modules GetModuleModel(int ModuleID)
        {
            return dal.GetModuleModel(ModuleID);
        }

        /// <summary>
        /// ��ò˵������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetModuleList(string strWhere)
        {
            return dal.GetModuleList(strWhere);
        }

        /// <summary>
        /// ��ò˵������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <returns></returns>
        public DataSet GetModuleList2(string strWhere)
        {
            return dal.GetModuleList2(strWhere);
        }

        /// <summary>
        /// ��ȡ�˵�ID
        /// </summary>
        /// <param name="ModuleTag">�˵���ʶ</param>
        /// <returns></returns>
        public int GetModuleID(string ModuleTag)
        {
            return dal.GetModuleID(ModuleTag);
        }

        /// <summary>
        /// �˵��Ƿ�ر�
        /// </summary>
        /// <param name="ModuleTag">�˵���ʶ</param>
        /// <returns></returns>
        public bool IsModule(string ModuleTag)
        {
            return dal.IsModule(ModuleTag);
        }

        #endregion
        #region ExtendMenthod

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public bool DeleteModules(string IDs)
        {
            return dal.DeleteModules(IDs);
        }

        /// <summary>
        /// �õ�һ���˵�ʵ��
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public XF.Model.XF_Modules GetModuleModel(string ModuleTag)
        {
            return dal.GetModuleModel(ModuleTag);
        }

        #endregion
        #endregion

        #region �˵���Ȩ

        #region BaseMethod
        /// <summary>
        /// ���Ӳ˵�Ȩ��
        /// </summary>
        /// <param name="list">Ȩ���б�</param>
        /// <returns></returns>
        public bool CreateAuthorityList(ArrayList list,string loginName)
        {
            return dal.CreateAuthorityList(list, loginName);
        }

        /// <summary>
        /// ���²˵�Ȩ��
        /// </summary>
        public bool UpdateAuthorityList(ArrayList list,string loginName)
        {
            return dal.UpdateAuthorityList(list,loginName);
        }

        /// <summary>
        /// ɾ��ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int ModuleID)
        {
            return dal.DeleteAuthority(ModuleID);
        }

        /// <summary>
        /// ���ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(int ModuleID)
        {
            return dal.GetAuthorityList(ModuleID);
        }

        /// <summary>
        /// ���ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityNameList(int ModuleID)
        {
            return dal.GetAuthorityNameList(ModuleID);
        }

        #endregion

        #region ExtendMethod

        /// <summary>
        /// �������Ȩ�������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetAllAuthorityList(int ModuleID)
        {
            return dal.GetAllAuthorityList(ModuleID);
        }

        public DataSet GetModuleAuthorityList(int ModuleID)
        {
            return dal.GetModuleAuthorityList(ModuleID);
        }

        #endregion
        #endregion
    }
}

