using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Models
{
    [Table("Course_Evaluate")]
    public class CourseEvaluate
    {
        [Key]
        public int Id { get; set; }

        public int SelectionStudentId { get; set; }

        public string Item { get; set; }

        public int Score { get; set; }

        public int MaxScore { get; set; }

        [ForeignKey("SelectionStudentId")]
        public virtual CourseSelectionStudent SelectionStudent { get; set; }
    }
}
