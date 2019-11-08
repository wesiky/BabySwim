using System;
namespace XF.Model
{
	/// <summary>
	/// XF_ModuleType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class XF_ModuleType
	{
		public XF_ModuleType()
		{}
		#region Model
		private int _moduletypeid;
		private string _moduletypename;
		private int _moduletypeorder=0;
		private string _moduletypedescription;
		private int _moduletypedepth=0;
		private int _moduletypesuperiorid=0;
		private int _moduletypecount=0;
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
		/// 模块分类ID
		/// </summary>
		public int ModuleTypeID
		{
			set{ _moduletypeid=value;}
			get{return _moduletypeid;}
		}
		/// <summary>
		/// 模块类型名称
		/// </summary>
		public string ModuleTypeName
		{
			set{ _moduletypename=value;}
			get{return _moduletypename;}
		}
		/// <summary>
		/// 排序
		/// </summary>
		public int ModuleTypeOrder
		{
			set{ _moduletypeorder=value;}
			get{return _moduletypeorder;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string ModuleTypeDescription
		{
			set{ _moduletypedescription=value;}
			get{return _moduletypedescription;}
		}
		/// <summary>
		/// 深度
		/// </summary>
		public int ModuleTypeDepth
		{
			set{ _moduletypedepth=value;}
			get{return _moduletypedepth;}
		}
		/// <summary>
		/// 上级ID
		/// </summary>
		public int ModuleTypeSuperiorID
		{
			set{ _moduletypesuperiorid=value;}
			get{return _moduletypesuperiorid;}
		}
		/// <summary>
		/// 下级个数
		/// </summary>
		public int ModuleTypeCount
		{
			set{ _moduletypecount=value;}
			get{return _moduletypecount;}
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

