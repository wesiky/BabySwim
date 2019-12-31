using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
	[Table("Base_CustomerInfo")]
	public partial class BaseCustomerInfo
	{
		[Key]
		public int StudentID { get; set; }

		public string Phone { get; set; }

		public DateTime? Birthday { get; set; }

		public decimal? CoursePrice { get; set; }

		public string InfoSource { get; set; }

		public string FollowInfo { get; set; }

		public string FollowUser { get; set; }

		public bool IsVisit { get; set; }

		public DateTime? VisitDate { get; set; }

		public int Age { get; set; }
	}
}

