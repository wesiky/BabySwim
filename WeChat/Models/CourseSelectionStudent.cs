using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeChat.Models
{
    [Table("Course_SelectionStudent")]
    public partial class CourseSelectionStudent
	{
		[Key]
		public int SelectionStudentID { get; set; }

		public int SelectionID { get; set; }

		public int StudentID { get; set; }

		public int SelectionType { get; set; }

		public int SignType { get; set; }

		public string Evaluation { get; set; }

		public string Description { get; set; }

		public DateTime? CreateDate { get; set; }

		public string CreateUser { get; set; }

		public DateTime? LastUpdateDate { get; set; }

		public string LastUpdateUser { get; set; }

		public bool Enable { get; set; }

		[ForeignKey("StudentID")]
		public virtual BaseStudentInfo StudentInfo { get; set; }

		[ForeignKey("SelectionID")]
		public virtual CourseSelection Selection { get; set; }
	}
}

