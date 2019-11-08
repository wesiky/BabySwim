using System;
namespace XF.Model
{
	/// <summary>
	/// Base_Customer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Base_Customer
	{
		public Base_Customer()
		{}
		#region Model
		private int _customerid;
        private string _customercode;
		private string _customername;
		private string _phone;
		private DateTime? _birthday;
		private decimal? _courseprice;
		private string _infosource;
		private string _followinfo;
		private string _followuser;
		private bool _isvisit = false;
        private DateTime? _visitdate;
        private int _age;

		private string _description;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
        private bool _enable = true;
        private int _studenttype = 1;
		/// <summary>
		/// 
		/// </summary>
		public int CustomerID
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string CustomerCode
        {
            get { return _customercode; }
            set { _customercode = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CoursePrice
		{
			set{ _courseprice=value;}
			get{return _courseprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InfoSource
		{
			set{ _infosource=value;}
			get{return _infosource;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FollowInfo
		{
			set{ _followinfo=value;}
			get{return _followinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FollowUser
		{
			set{ _followuser=value;}
			get{return _followuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsVisit
		{
			set{ _isvisit=value;}
            get { return _isvisit; }
		}
        /// <summary>
        /// 
        /// </summary>
        public DateTime? VisitDate
        {
            get { return _visitdate; }
            set { _visitdate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            get { return _age; }
            set { _age = value; }
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
        /// <summary>
        /// 
        /// </summary>
        public int StudentType
        {
            get { return _studenttype; }
        }
		#endregion Model

	}
}

