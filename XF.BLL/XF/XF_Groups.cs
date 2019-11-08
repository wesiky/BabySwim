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
	/// 业务逻辑类XF_Groups 的摘要说明。
	/// </summary>
	public class XF_Groups
	{
        private readonly IXF_Groups dal = DataAccess.CreateXF_Groups();

		public XF_Groups()
		{}

        #region BaseMethod
        /// <summary>
        /// 判断分组是否存在
        /// </summary>
        /// <param name="GroupName">分组名称</param>
        /// <returns></returns>
        public bool Exists(string GroupName, int GroupType)
        {
            return dal.Exists(GroupName, GroupType);
        }

        /// <summary>
        /// 增加一个分组
        /// </summary>
        /// <param name="model">分组实体类</param>
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
        /// 更新一条数据
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        public bool UpdateGroup(XF.Model.XF_Groups model)
        {
            return dal.UpdateGroup(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        public int DeleteGroup(int GroupID)
        {
            return dal.DeleteGroup(GroupID);
        }

        /// <summary>
        /// 得到一个分组实体
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        public XF.Model.XF_Groups GetGroupModel(int GroupID)
        {
            return dal.GetGroupModel(GroupID);
        }

        /// <summary>
        /// 获得分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetGroupList(string strWhere, string strOrder)
        {
            return dal.GetGroupList(strWhere, strOrder);
        }
        #endregion

        #region ExtendMethod
        /// <summary>
        /// 获得分页数据列表
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

