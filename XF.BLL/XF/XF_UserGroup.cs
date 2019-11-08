using System;
using System.Data;
using System.Collections.Generic;

using XF.Lib;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;

namespace XF.BLL
{
    public class XF_UserGroup
    {
        private readonly IXF_UserGroup dal = DataAccess.CreateXF_UserGroup();

        public XF_UserGroup()
        { }

        #region 用户分组
        /// <summary>
        /// 判断用户分组是否存在
        /// </summary>
        /// <param name="Name">用户分组名称</param>
        /// <returns></returns>
        public bool XF_UserGroupExists(string Name)
        {
            return dal.XF_UserGroupExists(Name);
        }

        /// <summary>
        /// 增加一个用户分组
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        public int CreateXF_UserGroup(XF.Model.XF_UserGroup model)
        {
            if (!XF_UserGroupExists(model.UG_Name))
                return dal.CreateXF_UserGroup(model);
            else
                return 2;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        public bool UpdateXF_UserGroup(XF.Model.XF_UserGroup model)
        {
            return dal.UpdateXF_UserGroup(model);
        }

        /// <summary>
        /// 删除用户分组
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        public int DeleteXF_UserGroup(int id)
        {
            return dal.DeleteXF_UserGroup(id);
        }

        /// <summary>
        /// 获取菜单深度
        /// </summary>
        /// <param name="ID">菜单ID</param>
        /// <returns></returns>
        public int GetXF_UserGroupDepth(int id)
        {
            return dal.GetXF_UserGroupDepth(id);
        }

        /// <summary>
        /// 得到一个用户分组实体
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        public XF.Model.XF_UserGroup GetXF_UserGroupModel(int id)
        {
            return dal.GetXF_UserGroupModel(id);
        }

        /// <summary>
        /// 获得用户分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet GetXF_UserGroupList(string strWhere)
        {
            return dal.GetXF_UserGroupList(strWhere);
        }

        /// <summary>
        /// 获得用户分组下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public DataSet GetChildXF_UserGroupList(int id)
        {
            return dal.GetChildXF_UserGroupList(id);
        }

        /// <summary>
        /// 判断用户分组下是否有菜单
        /// </summary>
        /// <param name="ID">分类iD</param>
        /// <returns></returns>
        public bool IsUser(int id)
        {
            return dal.IsUser(id);
        }

        #endregion
    }
}
