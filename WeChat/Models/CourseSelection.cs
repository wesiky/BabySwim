using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
	[Table("Course_Selection")]
	public partial class CourseSelection
	{
		[Key]
		public int SelectionID { get; set; }

		public DateTime CourseDate { get; set; }

		public int LessonNO { get; set; }

		public int CourseID { get; set; }

		public int SectionNO { get; set; }

		public int TeacherID { get; set; }

		public int AdviserID { get; set; }

		public int ClassRoomID { get; set; }

		public int StoreID { get; set; }

		public string Description { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreateUser { get; set; }

		public DateTime? LastUpdateDate { get; set; }

		public string LastUpdateUser { get; set; }

		public bool Enable { get; set; }

	}
}

