using System;
namespace XF.Model
{
	/// <summary>
	/// XF_Modules:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XF_Modules
	{
		public XF_Modules()
		{}
		#region Model
		private int _moduleid;
		private int _moduletypeid;
		private string _modulename;
		private string _moduletag;
		private string _moduleurl;
		private bool _moduledisabled= true;
		private int _moduleorder=0;
		private string _moduledescription;
		private bool _ismenu= true;
		private int _showtype;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
		private bool _enable= true;
        private string _icon = "";

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
		/// <summary>
		/// 模块ID
		/// </summary>
		public int ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		/// <summary>
		/// 模块类型
		/// </summary>
		public int ModuleTypeID
		{
			set{ _moduletypeid=value;}
			get{return _moduletypeid;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string ModuleName
		{
			set{ _modulename=value;}
			get{return _modulename;}
		}
		/// <summary>
		/// 模块标识
		/// </summary>
		public string ModuleTag
		{
			set{ _moduletag=value;}
			get{return _moduletag;}
		}
		/// <summary>
		/// 模块地址
		/// </summary>
		public string ModuleURL
		{
			set{ _moduleurl=value;}
			get{return _moduleurl;}
		}
		/// <summary>
		/// 是否禁用
		/// </summary>
		public bool ModuleDisabled
		{
			set{ _moduledisabled=value;}
			get{return _moduledisabled;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int ModuleOrder
		{
			set{ _moduleorder=value;}
			get{return _moduleorder;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string ModuleDescription
		{
			set{ _moduledescription=value;}
			get{return _moduledescription;}
		}
		/// <summary>
		/// 是否显示在导航菜单中
		/// </summary>
		public bool IsMenu
		{
			set{ _ismenu=value;}
			get{return _ismenu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ShowType
		{
			set{ _showtype=value;}
			get{return _showtype;}
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

