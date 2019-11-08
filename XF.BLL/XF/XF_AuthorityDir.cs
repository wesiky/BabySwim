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
	/// 业务逻辑类XF_AuthorityDir 的摘要说明。
	/// </summary>
	public class XF_AuthorityDir
	{
        private readonly IXF_AuthorityDir dal = DataAccess.CreateXF_AuthorityDir();

        public XF_AuthorityDir()
        { }

        #region BaseMethod

        /// <summary>
        /// 判断权限标识否存在
        /// </summary>
        /// <param name="AuthorityTag">权限标识</param>
        /// <returns></returns>
        public bool Exists(string AuthorityTag)
        {
            return dal.Exists(AuthorityTag);
        }

        /// <summary>
        /// 增加一个权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        public int CreateAuthority(XF.Model.XF_AuthorityDir model)
        {
            if (dal.Exists(model.AuthorityTag))
            {
                return -1;
            }
            else
            {
                return dal.CreateAuthority(model);
            }
        }

        /// <summary>
        /// 更新指定的权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        public bool UpdateAuthority(XF.Model.XF_AuthorityDir model)
        {
            return dal.UpdateAuthority(model);
        }

        /// <summary>
        /// 删除一个权限
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int AuthorityID)
        {
            return dal.DeleteAuthority(AuthorityID);
        }

        /// <summary>
        /// 得到一个权限实体
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        public XF.Model.XF_AuthorityDir GetAuthorityModel(int AuthorityID)
        {
            return dal.GetAuthorityModel(AuthorityID);
        }

        /// <summary>
        /// 获得权限数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(string strWhere, string strOrder)
        {
            return dal.GetAuthorityList(strWhere, strOrder);
        }

        #endregion
        #region ExtendMethod
        /// <summary>
        /// 获得分页数据列表
        /// </summary>
        public DataTable GetAuthorityListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            return dal.GetAuthorityListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
        }
        /// <summary>
        /// 批量删除权限
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool DeleteAuthority(string Tags,ref string result)
        {
            string ret = "";
            DataTable dt = dal.IsUsedAuthority(Tags);
            foreach (DataRow dr in dt.Rows)
            {
                if (int.Parse(dr["Count"].ToString()) > 0)
                {
                    ret += dr["AuthorityTag"].ToString() + "已被菜单使用，请修改菜单权限配置；";
                }
            }
            if (string.IsNullOrEmpty(ret))
            {
                return dal.DeleteAuthority(Tags);
            }
            else
            {
                result += ret;
                return false;
            }
        }
        public DataTable IsUsedAuthority(string Tags)
        {
            return dal.IsUsedAuthority(Tags);
        }
        #endregion
    }
}

