using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
	[Table("Base_Family")]
	public partial class BaseFamily
	{
		[Key]
		public int FamilyID { get; set; }

		public string FamilyCode { get; set; }

		public string FamilyName { get; set; }

		public decimal CourseCount { get; set; }

		public string OpenId { get; set; }

		public string Phone { get; set; }

		public string Description { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreateUser { get; set; }

		public DateTime? LastUpdateDate { get; set; }

		public string LastUpdateUser { get; set; }

		public bool Enable { get; set; }

	}
}

