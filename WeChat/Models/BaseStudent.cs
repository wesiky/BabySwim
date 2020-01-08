using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
	[Table("Base_Student")]
	public partial class BaseStudent
	{
		[Key]
		public int StudentID { get; set; }

        public string StudentCode { get; set; }

		public string StudentName { get; set; }

		public string Description { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreateUser { get; set; }

		public DateTime? LastUpdateDate { get; set; }

		public string LastUpdateUser { get; set; }

		public bool Enable { get; set; }

		public int StudentType { get; set; }
	}
}

