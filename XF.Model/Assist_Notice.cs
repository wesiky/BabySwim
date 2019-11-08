using System;
namespace XF.Model
{
	/// <summary>
	/// Assist_Notice:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Assist_Notice
	{
		public Assist_Notice()
		{}
		#region Model
		private int _noticeid;
		private string _objectname;
		private string _contentmsg;
		private string _attachmsg;
		private int _status=0;
		private DateTime? _createdate;
		private string _createuser;
		private DateTime? _lastupdatedate;
		private string _lastupdateuser;
		private bool _enable= true;
		/// <summary>
		/// 
		/// </summary>
		public int NoticeID
		{
			set{ _noticeid=value;}
			get{return _noticeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ObjectName
		{
			set{ _objectname=value;}
			get{return _objectname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContentMsg
		{
			set{ _contentmsg=value;}
			get{return _contentmsg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttachMsg
		{
			set{ _attachmsg=value;}
			get{return _attachmsg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
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

