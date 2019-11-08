using System;
using System.Collections;
using System.Data;

namespace XF.IDAL
{
    public interface IXF_Modules
	{

        #region 菜单分类
        #region BaseMethod
        /// <summary>
        /// 判断菜单分类是否存在
        /// </summary>
        /// <param name="ModuleTypeName">菜单分类名称</param>
        /// <returns></returns>
        bool ModuleTypeExists(string ModuleTypeName);

        /// <summary>
        /// 增加一个菜单分类
        /// </summary>
        /// <param name="model">菜单分类实体类</param>
        /// <returns></returns>
        int CreateModuleType(XF.Model.XF_ModuleType model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">菜单分类实体类</param>
        /// <returns></returns>
        bool UpdateModuleType(XF.Model.XF_ModuleType model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleTypeID">菜单分类ID</param>
        /// <returns></returns>
        int DeleteModuleType(int ModuleTypeID);

        /// <summary>
        /// 得到一个菜单分类实体
        /// </summary>
        /// <param name="ModuleTypeID">菜单分类ID</param>
        /// <returns></returns>
        XF.Model.XF_ModuleType GetModuleTypeModel(int ModuleTypeID);

        /// <summary>
        /// 获得菜单分类数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetModuleTypeList(string strWhere);

        #endregion

        #region ExtendMethod

        /// <summary>
        /// 获得菜单分类下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        DataSet GetChildModuleTypeList(int id);

        /// <summary>
        /// 获取菜单深度
        /// </summary>
        /// <param name="ModuleTypeID">菜单ID</param>
        /// <returns></returns>
        int GetModuleDepth(int ModuleTypeID);

        /// <summary>
        /// 判断菜单分类下是否有菜单
        /// </summary>
        /// <param name="ModuleTypeID">分类iD</param>
        /// <returns></returns>
        bool HasChildModules(int ModuleTypeID);

        /// <summary>
        /// 判断菜单分类下是否有子菜单分类
        /// </summary>
        /// <param name="ModuleTypeID">分类iD</param>
        /// <returns></returns>
        bool HasChildModuleType(int ModuleTypeID);
        #endregion
        #endregion

        #region 菜单操作
        #region BaseMethod
        /// <summary>
        /// 判断菜单是否存在
        /// </summary>
        /// <param name="ModuleName">菜单名称</param>
        /// <returns></returns>
        bool ModuleExists(string ModuleTag);

        /// <summary>
        /// 更新时判断菜单是否存在
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <param name="ModuleName">菜单名称</param>
        /// <returns></returns>
        bool UpdateExists(int ModuleID, string ModuleTag);

        /// <summary>
        /// 增加一个菜单
        /// </summary>
        /// <param name="model">菜单实体类</param>
        /// <returns></returns>
        int CreateModule(XF.Model.XF_Modules model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">菜单实体类</param>
        /// <returns></returns>
        int UpdateModule(XF.Model.XF_Modules model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        bool DeleteModule(int ModuleID);

        /// <summary>
        /// 得到一个菜单实体
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        XF.Model.XF_Modules GetModuleModel(int ModuleID);

        /// <summary>
        /// 获得菜单数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetModuleList(string strWhere);

        /// <summary>
        /// 获得菜单数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        DataSet GetModuleList2(string strWhere);

        /// <summary>
        /// 获取菜单ID
        /// </summary>
        /// <param name="ModuleTag">菜单标识</param>
        /// <returns></returns>
        int GetModuleID(string ModuleTag);

        /// <summary>
        /// 菜单是否关闭
        /// </summary>
        /// <param name="ModuleTag">菜单标识</param>
        /// <returns></returns>
        bool IsModule(string ModuleTag);

        #endregion

        #region ExtendMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        bool DeleteModules(string IDs);
        /// <summary>
        /// 得到一个菜单实体
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        XF.Model.XF_Modules GetModuleModel(string ModuleTag);
        #endregion
        #endregion

        #region 菜单授权

        #region BaseMethod
        /// <summary>
        /// 增加菜单权限
        /// </summary>
        /// <param name="list">权限列表</param>
        /// <returns></returns>
        bool CreateAuthorityList(ArrayList list,string loginName);

        /// <summary>
        /// 更新菜单权限
        /// </summary>
        bool UpdateAuthorityList(ArrayList list,string loginName);

        /// <summary>
        /// 删除指定菜单的权限列表
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        bool DeleteAuthority(int ModuleID);

        /// <summary>
        /// 获得指定菜单的权限列表
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
        /// <returns></returns>
        DataSet GetAuthorityList(int ModuleID);

        /// <summary>
        /// 获得指定菜单的权限列表
        /// </summary>
        /// <param name="ModuleID">菜单ID</param>
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

