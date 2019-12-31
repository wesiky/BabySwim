using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
	[Table("Course_ConfirmedStudent")]
	public partial class CourseConfirmedStudent
	{
		[Key]
		public int ConfirmedID { get; set; }

		public int StudentID { get; set; }

		public int DayOfWeek { get; set; }

		public int LessonNO { get; set; }

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

