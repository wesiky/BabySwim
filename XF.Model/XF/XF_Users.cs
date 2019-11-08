using System;
using System.Collections;

namespace XF.Model
{
	/// <summary>
	/// ʵ����XF_Users ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class XF_Users
	{
		public XF_Users()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _password;
		private string _question;
		private string _answer;
        private string _email;
		private ArrayList _roleid;
		private int _UserGroup;
		private DateTime _lastlogintime;
		private int _status;
		private bool _isonline;
		private bool _islimit;
        private DateTime _createdate;
        private string _createuser;
        private DateTime _lastupdatedate;
        private string _lastupdateuser;
        private string _realname;
        private bool _enable = true;
        private string _phone;
        private int _warehouseid = -1;
        private string _lgort;
        private string _mrp;

        public string MRP
        {
            get { return _mrp; }
            set { _mrp = value; }
        }

        public string LGORT
        {
            get { return _lgort; }
            set { _lgort = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }

        /// <summary>
        /// ������ʱ��
        /// </summary>
        public DateTime LastUpdateDate
        {
            get { return _lastupdatedate; }
            set { _lastupdatedate = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string LastUpdateUser
        {
            get { return _lastupdateuser; }
            set { _lastupdateuser = value; }
        }
		/// <summary>
		/// �û�ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// ��¼�����û�Email
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
		/// <summary>
		/// �������������
		/// </summary>
		public string Question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// ��������Ĵ�
		/// </summary>
		public string Answer
		{
			set{ _answer=value;}
			get{return _answer;}
		}
		/// <summary>
		/// ��ɫ
		/// </summary>
		public ArrayList RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public int UserGroup
		{
			set{ _UserGroup=value;}
			get{return _UserGroup;}
		}
		/// <summary>
		/// ��һ�ε�¼��ʱ��
		/// </summary>
		public DateTime LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// �û�״̬
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// �Ƿ�����
		/// </summary>
		public bool IsOnline
		{
			set{ _isonline=value;}
			get{return _isonline;}
		}
		/// <summary>
		/// �Ƿ���Ȩ�����ƣ�0Ϊ������
		/// </summary>
		public bool IsLimit
		{
			set{ _islimit=value;}
			get{return _islimit;}
		}

        /// <summary>
        /// �Ƿ���Ч
        /// </summary>
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string RealName
        {
            get { return _realname; }
            set { _realname = value; }
        }

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        /// <summary>
        /// �����ֿ�
        /// </summary>
        public int WarehouseID
        {
            get { return _warehouseid; }
            set { _warehouseid = value; }
        }
		#endregion Model

	}
}

