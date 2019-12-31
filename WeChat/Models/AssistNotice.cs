using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
	[Table("Assist_Notice")]
	public partial class AssistNotice
	{
		[Key]
		public int NoticeID { get; set; }

		public string ObjectName { get; set; }

		public string ContentMsg { get; set; }

		public string AttachMsg { get; set; }

		public int Status { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreateUser { get; set; }

		public DateTime? LastUpdateDate { get; set; }

		public string LastUpdateUser { get; set; }

		public bool Enable { get; set; }

	}
}

