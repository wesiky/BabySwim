using System;
namespace XF.Model
{
	/// <summary>
	/// XF_AuthorityDir:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XF_AuthorityDir
	{
		public XF_AuthorityDir()
		{}
		#region Model
		private int _authorityid;
		private string _authorityname;
		private string _authoritytag;
		private string _authoritydescription;
		private int _authorityorder=0;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
		private bool _enable= true;
		/// <summary>
		/// 权限ID
		/// </summary>
		public int AuthorityID
		{
			set{ _authorityid=value;}
			get{return _authorityid;}
		}
		/// <summary>
		/// 权限名称
		/// </summary>
		public string AuthorityName
		{
			set{ _authorityname=value;}
			get{return _authorityname;}
		}
		/// <summary>
		/// 权限标识
		/// </summary>
		public string AuthorityTag
		{
			set{ _authoritytag=value;}
			get{return _authoritytag;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string AuthorityDescription
		{
			set{ _authoritydescription=value;}
			get{return _authoritydescription;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int AuthorityOrder
		{
			set{ _authorityorder=value;}
			get{return _authorityorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastUpdateDate
		{
			set{ _lastupdatedate=value;}
			get{return _lastupdatedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LastUpdateUser
		{
			set{ _lastupdateuser=value;}
			get{return _lastupdateuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		#endregion Model

	}
}

