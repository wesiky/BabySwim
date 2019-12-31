using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
	[Table("Base_Teacher")]
	public partial class BaseTeacher
	{
		[Key]
		public int TeacherID { get; set; }

		public string TeacherCode { get; set; }

		public string TeacherName { get; set; }

		public int Age { get; set; }

		public string Sintroduction { get; set; }

		public int TeacherType { get; set; }

		public int Job { get; set; }

		public int JobLevel { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreateUser { get; set; }

		public DateTime? LastUpdateDate { get; set; }

		public string LastUpdateUser { get; set; }

		public bool Enable { get; set; }

	}
}

