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
	/// ҵ���߼���XF_Users ��ժҪ˵����
	/// </summary>
	public class XF_Users
	{
        private readonly IXF_Users dal = DataAccess.CreateXF_Users();
		public XF_Users()
		{}
        #region �û�����
        #region BaseMethod
        /// <summary>
        /// �û��Ƿ����
        /// </summary>
        public bool UserExists(string UserName)
        {
            return dal.UserExists(UserName);
        }

        /// <summary>
        /// ����һ�����û�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateUser(XF.Model.XF_Users model)
        {
            if (!UserExists(model.UserName))
            {
                return dal.CreateUser(model);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// �����û�������Ϣ
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public int UpdateUser(XF.Model.XF_Users model)
        {
            return dal.UpdateUser(model);
        }

        /// <summary>
        /// �û���¼���
        /// </summary>
        public bool CheckLogin(string UserName,string pwd)
        {
            return dal.CheckLogin(UserName, pwd);
        }

        /// <summary>
        /// �����û���¼ʱ��
        /// </summary>
        /// <param name="id"></param>
        public void UpdateLoginTime(int id)
        {
            dal.UpdateLoginTime(id);
        }

        /// <summary>
        /// �ж��û�ԭ�����Ƿ���ȷ
        /// </summary>
        /// <param name="id">�û�ID</param>
        /// <param name="pwd">ԭ����</param>
        /// <returns></returns>
        public bool VerifyPassword(int id, string pwd)
        {
            return dal.VerifyPassword(id, pwd);
        }

        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="id">�û�ID</param>
        /// <param name="pwd">������</param>
        /// <returns></returns>
        public bool ChangePassword(int id, string pwd)
        {
            return dal.ChangePassword(id, pwd);
        }

        /// <summary>
        /// ���°�ȫ��Ϣ
        /// </summary>
        /// <param name="id">�û�ID</param>
        /// <param name="question">����</param>
        /// <param name="answer">��</param>
        /// <returns></returns>
        public bool ChangeSecureInfo(int id, string question, string answer)
        {
            return dal.ChangeSecureInfo(id, question, answer);
        }

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="UserID">�û�ID</param>
        public bool DeleteUser(int UserID)
        {
            return dal.DeleteUser(UserID);
        }

        /// <summary>
        /// ����ID�õ��û�����ʵ��
        /// </summary>
        public XF.Model.XF_Users GetUserModel(int UserID)
        {
            return dal.GetUserModel(UserID);
        }

        /// <summary>
        /// �����û����õ��û�����ʵ��
        /// </summary>
        public XF.Model.XF_Users GetUserModel(string UserName)
        {
            return dal.GetUserModel(UserName);
        }

        /// <summary>
        /// ������ʵ�����õ��û�����ʵ��
        /// </summary>
        public XF.Model.XF_Users GetUserModelByRealName(string RealName)
        {
            return dal.GetUserModelByRealName(RealName);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetUserList(string strWhere,string strOrder)
        {
            return dal.GetUserList(strWhere,strOrder);
        }

        /// <summary>
        /// ��ȡ��ɫ����
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public object GetRoleName(int roleid)
        {
            return dal.GetRoleName(roleid);
        }
        #endregion
        #region ExtendMethod
        /// <summary>
        /// ��÷�ҳ�����б�
        /// </summary>
        public DataTable GetUserListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            return dal.GetUserListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
        }
        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="IDs">�û�ID����</param>
        public bool DeleteUsers(string IDs)
        {
            return dal.DeleteUsers(IDs);
        }
        #endregion
        #endregion

        #region ��ɫ����
        #region BaseMethod
        /// <summary>
        /// ���һ�û���ɫ
        /// </summary>
        /// <param name="UserID">�û�ID</param>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        public bool addUserRole(int UserID, int RoleID,string LoginName)
        {
            return dal.addUserRole(UserID, RoleID, LoginName);
        }

        /// <summary>
        /// ��������û���ɫ
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool addUserRole(ArrayList list,string loginName)
        {
            return dal.addUserRole(list, loginName);
        }

        /// <summary>
        /// ɾ��һ�û���ɫ
        /// </summary>
        /// <param name="UserID">�û�ID</param>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        public bool DeleteUserRole(int UserID, int RoleID)
        {
            return dal.DeleteUserRole(UserID, RoleID);
        }

        /// <summary>
        /// ����ɾ���û���ɫ
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteUserRole(ArrayList list)
        {
            return dal.DeleteUserRole(list);
        }

        /// <summary>
        /// ��ȡ�û���ɫ�б�
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetUserRole(int UserID)
        {
            return dal.GetUserRole(UserID);
        }

         /// <summary>
        /// ��ȡ�û���ɫ�б�
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ArrayList GetUserRoleArray(int UserID)
        {
            return dal.GetUserRoleArray(UserID);
        }

        #endregion

        #endregion
    }
}

