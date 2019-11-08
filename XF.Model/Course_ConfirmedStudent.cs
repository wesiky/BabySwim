using System;
namespace XF.Model
{
	/// <summary>
	/// Course_ConfirmedStudent:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course_ConfirmedStudent
	{
		public Course_ConfirmedStudent()
		{}
		#region Model
		private int _confirmedid;
		private int _studentid;
		private int _dayofweek;
		private int _lessonno;
		private int _classroomid;
        private int _storeid;
		private string _description;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
		private bool _enable= true;
        #region 扩展属性
        private string _studentname;
        private string _nickname;
        private int? _familyid;
        private string _familycode;
        private string _familyname;
        private decimal? _coursecount;
        private string _phone;
        private int? _teacherid;
        private string _teachercode;
        private string _teachername;
        private int _courseid;
        private string _coursename;
        private int _sectionno;

        public int CourseID
        {
            get { return _courseid; }
            set { _courseid = value; }
        }

        public string CourseName
        {
            get { return _coursename; }
            set { _coursename = value; }
        }

        public int SectionNO
        {
            get { return _sectionno; }
            set { _sectionno = value; }
        }

        public string StudentName
        {
            get { return _studentname; }
            set { _studentname = value; }
        }

        public string NickName
        {
            get { return _nickname; }
            set { _nickname = value; }
        }

        public int? FamilyID
        {
            get { return _familyid; }
            set { _familyid = value; }
        }

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

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public int? TeacherID
        {
            get { return _teacherid; }
            set { _teacherid = value; }
        }

        public decimal? CourseCount
        {
            get { return _coursecount; }
            set { _coursecount = value; }
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
        #endregion
        /// <summary>
		/// 
		/// </summary>
		public int ConfirmedID
		{
			set{ _confirmedid=value;}
			get{return _confirmedid;}
		}
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
		public int DayOfWeek
		{
			set{ _dayofweek=value;}
			get{return _dayofweek;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LessonNO
		{
			set{ _lessonno=value;}
			get{return _lessonno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ClassRoomID
		{
			set{ _classroomid=value;}
			get{return _classroomid;}
		}

        /// <summary>
        /// 
        /// </summary>
        public int StoreID
        {
            get { return _storeid; }
            set { _storeid = value; }
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
		#endregion Model

	}
}

