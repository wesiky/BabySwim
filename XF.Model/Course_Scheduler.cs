using System;
namespace XF.Model
{
	/// <summary>
	/// Course_Scheduler:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course_Scheduler
	{
		public Course_Scheduler()
		{}
		#region Model
		private int _schedulerid;
		private int _storeid;
		private int _classroomid;
		private int _weekday;
		private int _lessonno;
		private string _description;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
        private bool _enable = true;
		/// <summary>
		/// 
		/// </summary>
		public int SchedulerID
		{
			set{ _schedulerid=value;}
			get{return _schedulerid;}
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
		public int ClassRoomID
		{
			set{ _classroomid=value;}
			get{return _classroomid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int WeekDay
		{
			set{ _weekday=value;}
			get{return _weekday;}
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

