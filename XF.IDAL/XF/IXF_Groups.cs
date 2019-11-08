using System;
using System.Data;

namespace XF.IDAL
{
    public interface IXF_Groups
    {
        #region BaseMethod
        /// <summary>
        /// 判断分组是否存在
        /// </summary>
        /// <param name="GroupName">分组名称</param>
        /// <returns></returns>
        bool Exists(string GroupName, int GroupType);

        /// <summary>
        /// 增加一个分组
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        int CreateGroup(XF.Model.XF_Groups model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        bool UpdateGroup(XF.Model.XF_Groups model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        int DeleteGroup(int GroupID);

        /// <summary>
        /// 得到一个分组实体
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        XF.Model.XF_Groups GetGroupModel(int GroupID);

        /// <summary>
        /// 获得分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        DataSet GetGroupList(string strWhere, string strOrder);
        #endregion
        DataTable GetGroupListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count);
        int DeleteGroups(string IDs);
        #region ExtendMethod
        #endregion
    }
}

