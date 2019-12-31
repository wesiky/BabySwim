﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Models
{
	[Table("Base_StudentInfo")]
    public partial class BaseStudentInfo
    {
		[Key]
		public int StudentID { get; set; }

		public string NickName { get; set; }

		public DateTime Birthdate { get; set; }

		public int TeacherID { get; set; }

		public int AdviserID { get; set; }

		public DateTime Birthday { get; set; }

		public int? CourseID { get; set; }

		public int? Progress { get; set; }

		public int FamilyID { get; set; }
	}
}