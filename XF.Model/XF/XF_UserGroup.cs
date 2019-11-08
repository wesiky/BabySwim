using System;
namespace XF.Model
{
	/// <summary>
	/// XF_UserGroup:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XF_UserGroup
	{
		public XF_UserGroup()
		{}
		#region Model
		private int _ug_id;
		private string _ug_name;
		private int _ug_order;
		private string _ug_description;
		private int _ug_depth=0;
		private int _ug_superiorid=0;
		private int _ug_count=0;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
		private bool _enable= true;
		/// <summary>
		/// 用户组ID
		/// </summary>
		public int UG_ID
		{
			set{ _ug_id=value;}
			get{return _ug_id;}
		}
		/// <summary>
		/// 用户分组名称
		/// </summary>
		public string UG_Name
		{
			set{ _ug_name=value;}
			get{return _ug_name;}
		}
		/// <summary>
		/// 用户分组排序
		/// </summary>
		public int UG_Order
		{
			set{ _ug_order=value;}
			get{return _ug_order;}
		}
		/// <summary>
		/// 用户分组描述
		/// </summary>
		public string UG_Description
		{
			set{ _ug_description=value;}
			get{return _ug_description;}
		}
		/// <summary>
		/// 用户分组深度
		/// </summary>
		public int UG_Depth
		{
			set{ _ug_depth=value;}
			get{return _ug_depth;}
		}
		/// <summary>
		/// 用户分组上级
		/// </summary>
		public int UG_SuperiorID
		{
			set{ _ug_superiorid=value;}
			get{return _ug_superiorid;}
		}
		/// <summary>
		/// 用户分组下级数
		/// </summary>
		public int UG_Count
		{
			set{ _ug_count=value;}
			get{return _ug_count;}
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

