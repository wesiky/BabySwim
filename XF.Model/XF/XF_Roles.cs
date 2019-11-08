using System;
namespace XF.Model
{
	/// <summary>
	/// XF_Roles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XF_Roles
	{
		public XF_Roles()
		{}
		#region Model
		private int _roleid;
		private int _rolegroupid;
		private string _rolename;
		private string _roledescription;
		private int _roleorder=0;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
		private bool _enable= true;
		/// <summary>
		/// 角色ID
		/// </summary>
		public int RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 分组ID
		/// </summary>
		public int RoleGroupID
		{
			set{ _rolegroupid=value;}
			get{return _rolegroupid;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string RoleDescription
		{
			set{ _roledescription=value;}
			get{return _roledescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int RoleOrder
		{
			set{ _roleorder=value;}
			get{return _roleorder;}
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

