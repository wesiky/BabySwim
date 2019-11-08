using System;
using System.Collections;
using System.Data;

namespace XF.IDAL
{
    public interface IXF_UserGroup
    {
        #region 用户分组
        /// <summary>
        /// 判断用户分组是否存在
        /// </summary>
        /// <param name="Name">用户分组名称</param>
        /// <returns></returns>
        bool XF_UserGroupExists(string Name);

        /// <summary>
        /// 增加一个用户分组
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        int CreateXF_UserGroup(XF.Model.XF_UserGroup model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        bool UpdateXF_UserGroup(XF.Model.XF_UserGroup model);

        /// <summary>
        /// 删除用户分组
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        int DeleteXF_UserGroup(int id);

        /// <summary>
        /// 获取菜单深度
        /// </summary>
        /// <param name="ID">菜单ID</param>
        /// <returns></returns>
        int GetXF_UserGroupDepth(int id);

        /// <summary>
        /// 得到一个用户分组实体
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        XF.Model.XF_UserGroup GetXF_UserGroupModel(int id);

        /// <summary>
        /// 获得用户分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        DataSet GetXF_UserGroupList(string strWhere);

        /// <summary>
        /// 获得用户分组下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        DataSet GetChildXF_UserGroupList(int id);

        /// <summary>
        /// 判断用户分组下是否有菜单
        /// </summary>
        /// <param name="ID">分类iD</param>
        /// <returns></returns>
        bool IsUser(int id);

        #endregion
    }
}