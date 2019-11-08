using System;
namespace XF.Model
{
	/// <summary>
	/// Base_Teacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Base_Teacher
	{
		public Base_Teacher()
		{}
		#region Model
		private int _teacherid;
		private string _teachercode;
		private string _teachername;
		private int _age;
		private string _sintroduction;
        private int _teachertype;
        private int _job;
        private int _joblevel;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
        private bool _enable = true;
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
		public string TeacherCode
		{
			set{ _teachercode=value;}
			get{return _teachercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherName
		{
			set{ _teachername=value;}
			get{return _teachername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sintroduction
		{
			set{ _sintroduction=value;}
			get{return _sintroduction;}
        }
        /// <summary>
        /// 
        /// </summary>
        public int TeacherType
        {
            get { return _teachertype; }
            set { _teachertype = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Job
        {
            get { return _job; }
            set { _job = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int JobLevel
        {
            get { return _joblevel; }
            set { _joblevel = value; }
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

