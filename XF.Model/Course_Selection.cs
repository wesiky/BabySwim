using System;
using System.Collections.Generic;
namespace XF.Model
{
	/// <summary>
	/// Course_Selection:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course_Selection
	{
		public Course_Selection()
		{}
		#region Model
		private int _selectionid;
		private DateTime _coursedate;
		private int _lessonno;
		private int _courseid;
		private int _sectionno = 1;
		private int _teacherid;
        private int _adviserid;
		private int _classroomid;
		private int _storeid;
		private string _description;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
        private bool _enable = true;
        #region 扩展属性
        private string _teachercode;
        private string _teachername;
        private string _advisercode;
        private string _advisername;
        private string _coursename;
        private string _color;
        private int _selectioncount;
        private List<XF.Model.Course_SelectionStudent> _selectionstudents;

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
        public string CourseName
        {
            get { return _coursename; }
            set { _coursename = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int SelectionCount
        {
            get { return _selectioncount; }
            set { _selectioncount = value; }
        }

        public List<XF.Model.Course_SelectionStudent> SelectionStudents
        {
            get
            {
                if (_selectionstudents == null)
                {
                    _selectionstudents = new List<Course_SelectionStudent>();
                }
                return _selectionstudents;
            }
            set { _selectionstudents = value; }
        }
        #endregion
        /// <summary>
		/// 
		/// </summary>
		public int SelectionID
		{
			set
            { 
                _selectionid=value;
                if (SelectionStudents != null)
                {
                    foreach (XF.Model.Course_SelectionStudent student in SelectionStudents)
                    {
                        student.SelectionID = _selectionid;
                    }
                }
            }
			get{return _selectionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CourseDate
		{
			set{ _coursedate=value;}
			get{return _coursedate;}
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
		public int CourseID
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SectionNO
		{
			set{ _sectionno=value;}
			get{return _sectionno;}
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
			set{ _storeid=value;}
			get{return _storeid;}
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

