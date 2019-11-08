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
	/// ҵ���߼���XF_AuthorityDir ��ժҪ˵����
	/// </summary>
	public class XF_AuthorityDir
	{
        private readonly IXF_AuthorityDir dal = DataAccess.CreateXF_AuthorityDir();

        public XF_AuthorityDir()
        { }

        #region BaseMethod

        /// <summary>
        /// �ж�Ȩ�ޱ�ʶ�����
        /// </summary>
        /// <param name="AuthorityTag">Ȩ�ޱ�ʶ</param>
        /// <returns></returns>
        public bool Exists(string AuthorityTag)
        {
            return dal.Exists(AuthorityTag);
        }

        /// <summary>
        /// ����һ��Ȩ��
        /// </summary>
        /// <param name="model">Ȩ��ʵ����</param>
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
        /// ����ָ����Ȩ��
        /// </summary>
        /// <param name="model">Ȩ��ʵ����</param>
        /// <returns></returns>
        public bool UpdateAuthority(XF.Model.XF_AuthorityDir model)
        {
            return dal.UpdateAuthority(model);
        }

        /// <summary>
        /// ɾ��һ��Ȩ��
        /// </summary>
        /// <param name="AuthorityID">Ȩ��ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int AuthorityID)
        {
            return dal.DeleteAuthority(AuthorityID);
        }

        /// <summary>
        /// �õ�һ��Ȩ��ʵ��
        /// </summary>
        /// <param name="AuthorityID">Ȩ��ID</param>
        /// <returns></returns>
        public XF.Model.XF_AuthorityDir GetAuthorityModel(int AuthorityID)
        {
            return dal.GetAuthorityModel(AuthorityID);
        }

        /// <summary>
        /// ���Ȩ�������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(string strWhere, string strOrder)
        {
            return dal.GetAuthorityList(strWhere, strOrder);
        }

        #endregion
        #region ExtendMethod
        /// <summary>
        /// ��÷�ҳ�����б�
        /// </summary>
        public DataTable GetAuthorityListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            return dal.GetAuthorityListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
        }
        /// <summary>
        /// ����ɾ��Ȩ��
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
                    ret += dr["AuthorityTag"].ToString() + "�ѱ��˵�ʹ�ã����޸Ĳ˵�Ȩ�����ã�";
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

