using System;
namespace XF.Model
{
	/// <summary>
	/// Base_Family:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Base_Family
	{
		public Base_Family()
		{}
		#region Model
		private int _familyid;
		private string _familycode;
		private string _familyname;
		private decimal _coursecount=0M;
		private string _description;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
        private bool _enable = true;
        private string _phone;
		private string _openid;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int FamilyID
		{
			set{ _familyid=value;}
			get{return _familyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyCode
		{
			set{ _familycode=value;}
			get{return _familycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FamilyName
		{
			set{ _familyname=value;}
			get{return _familyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CourseCount
		{
			set{ _coursecount=value;}
			get{return _coursecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
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

		public string OpenId
		{
			set { _openid = value; }
			get { return _openid; }
		}
		#endregion Model

	}
}

