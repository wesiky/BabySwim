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
    /// 业务逻辑类XF_Modules 的摘要说明。
    /// </summary>
    public class XF_Modules
    {
        private readonly IXF_Modules dal = DataAccess.CreateXF_Modules();

        public XF_Modules()
        { }

        #region 菜单分类
        #region BaseMethod
        /// <summary>
        /// 判断菜单分类是否存在
        /// </summary>
        /// <param name="ModuleTypeName">菜单分类名称</param>
        /// <returns></returns>
        public bool ModuleTypeExists(string ModuleTypeName)
        {
            return dal.ModuleTypeExists(ModuleTypeName);
        }

        /// <summary>
        /// 增加一个菜单分类
        /// </summary>
        /// <param name="model">菜单分类实体类</param>
        /// <returns></returns>
        public int CreateModuleType(XF.Model.XF_ModuleType model)
        {
            if (!ModuleTypeExists(model.ModuleTypeName))
                return dal.CreateModuleType(model);
            else
                return -1;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">菜单分类实体类</param>
        /// <returns></returns>
        public bool UpdateModuleType(XF.Model.XF_ModuleType model)
        {
            return dal.UpdateModuleType(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleTypeID">菜单分类ID</param>
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
        /// 得到一个菜单分类实体
        /// </summary>
        /// <param name="ModuleTypeID">菜单分类ID</param>
        /// <returns></returns>
        public XF.Model.XF_ModuleType GetModuleTypeModel(int ModuleTypeID)
        {
            return dal.GetModuleTypeModel(ModuleTypeID);
        }

        /// <summary>
        /// 获得菜单分类数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetModuleTypeList(string strWhere)
        {
            return dal.GetModuleTypeList(strWhere);
        }

        #endregion
        #region ExtendMethod
        /// <summary>
        /// 获得菜单分类下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public DataSet GetChildModuleTypeList(int id)
        {
            return dal.GetChildModuleTypeList(id);
        }

        /// <summary>
        /// 获取菜单深度
        /// </summary>
        /// <param name="ModuleTypeID">菜单ID</param>
        /// <returns></returns>
        public int GetModuleDepth(int ModuleTypeID)
        {
            return dal.GetModuleDepth(ModuleTypeID);
        }

        /// <summary>
        /// 判断菜单分类下是否有菜单
        /// </summary>
        /// <param name="ModuleTypeID">分类iD</param>
        /// <returns></returns>
        public bool HasChildModules(int ModuleTypeID)
        {
            return dal.HasChildModules(ModuleTypeID);
        }

        /// <summary>
        /// 判断菜单分类下是否有子菜单分类
        /// </summary>
        /// <param name="ModuleTypeID">分类iD</param>
        /// <returns></returns>
        public bool HasChildModuleType(int ModuleTypeID)
        {
            return dal.HasChildModuleType(ModuleTypeID);
        }
        #endregion
        #endregion

        #region 菜单操作

        #region BaseMethod
        /// <summary>
        /// 判断菜单是否存在
        /// </summary>
        /// <param name="ModuleName">菜单名称</param>
        /// <returns></returns>
        public bool ModuleExists(string ModuleTag)
        {
            return dal.ModuleExists(ModuleTag);
        }

        /// <summary>
        /// 更新时判断菜单是否存在
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <param name="ModuleName">菜单名称</param>
        /// <returns></returns>
        public bool UpdateExists(int ModuleID, string ModuleTag)
        {
            return dal.UpdateExists(ModuleID, ModuleTag);
        }

        /// <summary>
        /// 增加一个菜单
        /// </summary>
        /// <param name="model">菜单实体类</param>
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
        /// 更新一条数据
        /// </summary>
        /// <param name="model">菜单实体类</param>
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
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        public bool DeleteModule(int ModuleID)
        {
            return dal.DeleteModule(ModuleID);
        }

        /// <summary>
        /// 得到一个菜单实体
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        public XF.Model.XF_Modules GetModuleModel(int ModuleID)
        {
            return dal.GetModuleModel(ModuleID);
        }

        /// <summary>
        /// 获得菜单数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetModuleList(string strWhere)
        {
            return dal.GetModuleList(strWhere);
        }

        /// <summary>
        /// 获得菜单数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet GetModuleList2(string strWhere)
        {
            return dal.GetModuleList2(strWhere);
        }

        /// <summary>
        /// 获取菜单ID
        /// </summary>
        /// <param name="ModuleTag">菜单标识</param>
        /// <returns></returns>
        public int GetModuleID(string ModuleTag)
        {
            return dal.GetModuleID(ModuleTag);
        }

        /// <summary>
        /// 菜单是否关闭
        /// </summary>
        /// <param name="ModuleTag">菜单标识</param>
        /// <returns></returns>
        public bool IsModule(string ModuleTag)
        {
            return dal.IsModule(ModuleTag);
        }

        #endregion
        #region ExtendMenthod

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        public bool DeleteModules(string IDs)
        {
            return dal.DeleteModules(IDs);
        }

        /// <summary>
        /// 得到一个菜单实体
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        public XF.Model.XF_Modules GetModuleModel(string ModuleTag)
        {
            return dal.GetModuleModel(ModuleTag);
        }

        #endregion
        #endregion

        #region 菜单授权

        #region BaseMethod
        /// <summary>
        /// 增加菜单权限
        /// </summary>
        /// <param name="list">权限列表</param>
        /// <returns></returns>
        public bool CreateAuthorityList(ArrayList list,string loginName)
        {
            return dal.CreateAuthorityList(list, loginName);
        }

        /// <summary>
        /// 更新菜单权限
        /// </summary>
        public bool UpdateAuthorityList(ArrayList list,string loginName)
        {
            return dal.UpdateAuthorityList(list,loginName);
        }

        /// <summary>
        /// 删除指定菜单的权限列表
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int ModuleID)
        {
            return dal.DeleteAuthority(ModuleID);
        }

        /// <summary>
        /// 获得指定菜单的权限列表
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(int ModuleID)
        {
            return dal.GetAuthorityList(ModuleID);
        }

        /// <summary>
        /// 获得指定菜单的权限列表
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityNameList(int ModuleID)
        {
            return dal.GetAuthorityNameList(ModuleID);
        }

        #endregion

        #region ExtendMethod

        /// <summary>
        /// 获得所有权限数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
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

