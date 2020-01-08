using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF.Model
{
	/// <summary>
	/// Course_Evaluate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course_Evaluate
    {
		public Course_Evaluate()
		{ }

		#region Model
		private int _id;
		private int _selectionstudentid;
		private string _item;
		private int _score;
		private int _maxscore;

		/// <summary>
		/// 
		/// </summary>
		public int Id {
			set { _id = value; }
			get { return _id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int SelectionStudentId
		{
			set { _selectionstudentid = value; }
			get { return _selectionstudentid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Item
		{
			set { _item = value; }
			get { return _item; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Score
		{
			set { _score = value; }
			get { return _score; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int MaxScore
		{
			set { _maxscore = value; }
			get { return _maxscore; }
		}
		#endregion
	}
}
