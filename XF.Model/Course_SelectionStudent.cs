using System;
using System.Collections.Generic;

namespace XF.Model
{
	/// <summary>
	/// Course_SelectionStudent:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course_SelectionStudent
	{
		public Course_SelectionStudent()
		{}
		#region Model
		private int _selectionstudentid;
		private int _selectionid;
		private int _studentid;
		private int _selectiontype=0;
		private int _signtype=0;
        private string _evaluation;
		private string _description;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
        private bool _enable = true;
        #region 扩展属性
        private string _studentcode;
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
        private int _storeid;
        private int _classroomid;
        private int _courseid;
        private string _coursename;
        private int _sectionno;
        private int _lessonno;
        private DateTime? _coursedate;
        private string openId;

        public string OpenId
        {
            get { return openId; }
            set { openId = value; }
        }

        public DateTime? CourseDate
        {
            get { return _coursedate; }
            set { _coursedate = value; }
        }

        public int LessonNO
        {
            get { return _lessonno; }
            set { _lessonno = value; }
        }

        public int StoreID
        {
            get { return _storeid; }
            set { _storeid = value; }
        }

        public int ClassroomID
        {
            get { return _classroomid; }
            set { _classroomid = value; }
        }

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

        public string StudentCode
        {
            get { return _studentcode; }
            set { _studentcode = value; }
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

        private List<Course_Evaluate> _evaluates;

        /// <summary>
		/// 
		/// </summary>
		public int SelectionStudentID
		{
			set{ _selectionstudentid=value;}
			get{return _selectionstudentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SelectionID
		{
			set{ _selectionid=value;}
			get{return _selectionid;}
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
		public int SelectionType
		{
			set{ _selectiontype=value;}
			get{return _selectiontype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SignType
		{
			set{ _signtype=value;}
			get{return _signtype;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Evaluation
        {
            get { return _evaluation; }
            set { _evaluation = value; }
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

        public List<Course_Evaluate> Evaluates 
        {
            set { _evaluates = value; }
            get 
            { 
                if(_evaluates == null)
                {
                    _evaluates = new List<Course_Evaluate>();
                }
                return _evaluates; 
            }
        }
        #endregion Model

    }
}

