using System;
namespace XF.Model
{
	/// <summary>
	/// XF_Groups:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XF_Groups
	{
		public XF_Groups()
		{}
		#region Model
		private int _groupid;
		private string _groupname;
		private int _grouporder=0;
		private string _groupdescription;
		private int _grouptype=1;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
		private bool _enable= true;
		/// <summary>
		/// 分组ID
		/// </summary>
		public int GroupID
		{
			set{ _groupid=value;}
			get{return _groupid;}
		}
		/// <summary>
		/// 组名称
		/// </summary>
		public string GroupName
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int GroupOrder
		{
			set{ _grouporder=value;}
			get{return _grouporder;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string GroupDescription
		{
			set{ _groupdescription=value;}
			get{return _groupdescription;}
		}
		/// <summary>
		/// 分组类型 用户组0,角色组1
		/// </summary>
		public int GroupType
		{
			set{ _grouptype=value;}
			get{return _grouptype;}
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

