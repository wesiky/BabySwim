using System;
using System.Collections;

namespace XF.Model
{
	/// <summary>
	/// 实体类XF_Users 。(属性说明自动提取数据库字段的描述信息)
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
        /// 创建时间
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser
        {
            get { return _createuser; }
            set { _createuser = value; }
        }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateDate
        {
            get { return _lastupdatedate; }
            set { _lastupdatedate = value; }
        }

        /// <summary>
        /// 最后更新人
        /// </summary>
        public string LastUpdateUser
        {
            get { return _lastupdateuser; }
            set { _lastupdateuser = value; }
        }
		/// <summary>
		/// 用户ID
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 登录名，用户Email
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
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
		/// 重置密码的问题
		/// </summary>
		public string Question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 重置密码的答案
		/// </summary>
		public string Answer
		{
			set{ _answer=value;}
			get{return _answer;}
		}
		/// <summary>
		/// 角色
		/// </summary>
		public ArrayList RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 用户组
		/// </summary>
		public int UserGroup
		{
			set{ _UserGroup=value;}
			get{return _UserGroup;}
		}
		/// <summary>
		/// 上一次登录的时间
		/// </summary>
		public DateTime LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// 用户状态
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 是否在线
		/// </summary>
		public bool IsOnline
		{
			set{ _isonline=value;}
			get{return _isonline;}
		}
		/// <summary>
		/// 是否授权限限制，0为受限制
		/// </summary>
		public bool IsLimit
		{
			set{ _islimit=value;}
			get{return _islimit;}
		}

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            get { return _realname; }
            set { _realname = value; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        /// <summary>
        /// 所属仓库
        /// </summary>
        public int WarehouseID
        {
            get { return _warehouseid; }
            set { _warehouseid = value; }
        }
		#endregion Model

	}
}

