using System;
using System.Collections;
using System.Data;

namespace XF.IDAL
{
	/// <summary>
	/// ҵ���߼���XF_Users ��ժҪ˵����
	/// </summary>
	public interface IXF_Users
    {
        #region �û�����
        #region BaseMethod
        /// <summary>
        /// �û��Ƿ����
        /// </summary>
        bool UserExists(string UserName);

        /// <summary>
        /// ����һ�����û�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int CreateUser(XF.Model.XF_Users model);

        /// <summary>
        /// �����û�������Ϣ
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        int UpdateUser(XF.Model.XF_Users model);
        
        /// <summary>
        /// �û���¼���
        /// </summary>
        bool CheckLogin(string UserName,string pwd);

        /// <summary>
        /// �����û���¼ʱ��
        /// </summary>
        /// <param name="id"></param>
        void UpdateLoginTime(int id);

        /// <summary>
        /// �ж��û�ԭ�����Ƿ���ȷ
        /// </summary>
        /// <param name="id">�û�ID</param>
        /// <param name="pwd">ԭ����</param>
        /// <returns></returns>
        bool VerifyPassword(int id, string pwd);
        
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="id">�û�ID</param>
        /// <param name="pwd">������</param>
        /// <returns></returns>
        bool ChangePassword(int id, string pwd);
      
        /// <summary>
        /// ���°�ȫ��Ϣ
        /// </summary>
        /// <param name="id">�û�ID</param>
        /// <param name="question">����</param>
        /// <param name="answer">��</param>
        /// <returns></returns>
        bool ChangeSecureInfo(int id, string question, string answer);      

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="UserID">�û�ID</param>
        bool DeleteUser(int UserID);
        
        /// <summary>
        /// ����ID�õ��û�����ʵ��
        /// </summary>
        XF.Model.XF_Users GetUserModel(int UserID);
       
        /// <summary>
        /// �����û����õ��û�����ʵ��
        /// </summary>
        XF.Model.XF_Users GetUserModel(string UserName);

        /// <summary>
        /// ������ʵ�����õ��û�����ʵ��
        /// </summary>
        XF.Model.XF_Users GetUserModelByRealName(string RealName);

        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetUserList(string strWhere, string strOrder);
        #endregion

        #region ExtendMethod
        DataTable GetUserListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count);

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="IDs">�û�ID����</param>
        bool DeleteUsers(string IDs);
        #endregion
        #endregion

        #region ��ɫ����
        #region BaseMethod
        /// <summary>
        /// ��ȡ��ɫ����
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        object GetRoleName(int roleid);


        /// <summary>
        /// ���һ�û���ɫ
        /// </summary>
        /// <param name="UserID">�û�ID</param>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        bool addUserRole(int UserID, int RoleID,string LoginName);

        /// <summary>
        /// ��������û���ɫ
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool addUserRole(ArrayList list,string loginName);

        /// <summary>
        /// ɾ��һ�û���ɫ
        /// </summary>
        /// <param name="UserID">�û�ID</param>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        bool DeleteUserRole(int UserID, int RoleID);

        /// <summary>
        /// ����ɾ���û���ɫ
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteUserRole(ArrayList list);

        /// <summary>
        /// ��ȡ�û���ɫ�б�
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        DataSet GetUserRole(int UserID);

         /// <summary>
        /// ��ȡ�û���ɫ�б�
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        ArrayList GetUserRoleArray(int UserID);

        #endregion
        #endregion
    }
}

