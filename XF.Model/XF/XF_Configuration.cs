using System;
namespace XF.Model
{
	/// <summary>
	/// XF_Configuration:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XF_Configuration
	{
		public XF_Configuration()
		{}
		#region Model
		private int _itemid;
		private string _itemname;
		private string _itemvalue;
		private string _itemdescription;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
		private bool _enable= true;
		/// <summary>
		/// 配置项ID
		/// </summary>
		public int ItemID
		{
			set{ _itemid=value;}
			get{return _itemid;}
		}
		/// <summary>
		/// 配置名
		/// </summary>
		public string ItemName
		{
			set{ _itemname=value;}
			get{return _itemname;}
		}
		/// <summary>
		/// 配置值
		/// </summary>
		public string ItemValue
		{
			set{ _itemvalue=value;}
			get{return _itemvalue;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string ItemDescription
		{
			set{ _itemdescription=value;}
			get{return _itemdescription;}
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

