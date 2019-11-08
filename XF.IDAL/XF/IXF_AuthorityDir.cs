using System;
using System.Data;

namespace XF.IDAL
{
    public interface IXF_AuthorityDir
    {
        #region BaseMethod
        /// <summary>
        /// �ж�Ȩ�ޱ�ʶ�����
        /// </summary>
        /// <param name="AuthorityTag">Ȩ�ޱ�ʶ</param>
        /// <returns></returns>
        bool Exists(string AuthorityTag);

        /// <summary>
        /// ����һ��Ȩ��
        /// </summary>
        /// <param name="model">Ȩ��ʵ����</param>
        /// <returns></returns>
        int CreateAuthority(XF.Model.XF_AuthorityDir model);

        /// <summary>
        /// ����ָ����Ȩ��
        /// </summary>
        /// <param name="model">Ȩ��ʵ����</param>
        /// <returns></returns>
        bool UpdateAuthority(XF.Model.XF_AuthorityDir model);

        /// <summary>
        /// ɾ��һ��Ȩ��
        /// </summary>
        /// <param name="AuthorityID">Ȩ��ID</param>
        /// <returns></returns>
        bool DeleteAuthority(int AuthorityID);

        /// <summary>
        /// �õ�һ��Ȩ��ʵ��
        /// </summary>
        /// <param name="AuthorityID">Ȩ��ID</param>
        /// <returns></returns>
        XF.Model.XF_AuthorityDir GetAuthorityModel(int AuthorityID);

        /// <summary>
        /// ���Ȩ�������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        DataSet GetAuthorityList(string strWhere, string strOrder);
        #endregion

        #region ExtendMethod
        DataTable GetAuthorityListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count);
        bool DeleteAuthority(string Tags);
        DataTable IsUsedAuthority(string Tags);
        #endregion
    }
}

