using System;
namespace XF.Model
{
	/// <summary>
	/// Base_Student:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Base_Student
	{
		public Base_Student()
		{}
		#region Model
		private int _studentid;
        private string _studentcode;
		private string _studentname;
		private string _nickname;
		private DateTime _birthdate;
		private int _teacherid;
        private int _adviserid;
		private DateTime _birthday;
		private int? _courseid;
		private int? _progress;
		private string _description;
        private int _familyid;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
        private bool _enable = true;
        private int _studenttype = 0;
        #region 扩展属性
        private string _familycode;
        private string _familyname;
        private decimal _coursecount;
        private string _phone;
        private string _teachercode;
        private string _teachername;
        private string _advisercode;
        private string _advisername;

        public string FamilyCode
        {
            get { return _familycode; }
            set { _familycode = value; }
        }

        public string FamilyName
        {
            get { return _familyname; }
            set { _familyname = value; }
        }

        public decimal CourseCount
        {
            get { return _coursecount; }
            set { _coursecount = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string TeacherCode
        {
            get { return _teachercode; }
            set { _teachercode = value; }
        }

        public string TeacherName
        {
            get { return _teachername; }
            set { _teachername = value; }
        }

        public string AdviserCode
        {
            get { return _advisercode; }
            set { _advisercode = value; }
        }

        public string AdviserName
        {
            get { return _advisername; }
            set { _advisername = value; }
        }
        #endregion
        /// <summary>
		/// 
		/// </summary>
		public int StudentID
		{
			set{ _studentid=value;}
			get{return _studentid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string StudentCode
        {
            get { return _studentcode; }
            set { _studentcode = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string StudentName
		{
			set{ _studentname=value;}
			get{return _studentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Birthdate
		{
			set{ _birthdate=value;}
			get{return _birthdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TeacherID
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int AdviserID
        {
            get { return _adviserid; }
            set { _adviserid = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CourseID
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Progress
		{
			set{ _progress=value;}
			get{return _progress;}
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
        public int FamilyID
        {
            get { return _familyid; }
            set { _familyid = value; }
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

