using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
	[Table("Base_Course")]
	public partial class BaseCourse
	{
		[Key]
		public int CourseID { get; set; }

		public string CourseName { get; set; }

		public int MaxCount { get; set; }

		public int MaxSection { get; set; }

		public string Description { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreateUser { get; set; }

		public DateTime? LastUpdateDate { get; set; }

		public string LastUpdateUser { get; set; }

		public bool Enable { get; set; }

		public string Color { get; set; }

	}
}

