using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeChat.Context;
using WeChat.IReponsitory;
using WeChat.Models;

namespace WeChat.Reponsitory
{
    public class SelectionStudentReponsitory : BaseReponsitory<CourseSelectionStudent>, ISelectionStudentReponsitory
    {
        public SelectionStudentReponsitory(WeChatContext content) : base(content)
        {
        }

        public IQueryable<CourseSelectionStudent> GetSelectionStudentDetail(Expression<Func<CourseSelectionStudent, bool>> whereLambda)
        {
            return Context.SelectionStudents
                .Include(a => a.Selection).ThenInclude(a => a.SelectionStudents)
                .Include(a => a.StudentInfo).ThenInclude(a => a.Family)
                .Include(a => a.Selection).ThenInclude(a => a.Course)
                .Include(a => a.Selection).ThenInclude(a => a.Teacher)
                .Include(a => a.Evaluates)
                .Where(whereLambda);
        }

        public CourseSelectionStudent GetSelectionStudent(int id)
        {
            return Context.SelectionStudents
                .Include(a => a.Selection).ThenInclude(a => a.SelectionStudents)
                .Include(a => a.StudentInfo).ThenInclude(a => a.Family)
                .Include(a => a.StudentInfo).ThenInclude(a => a.Student)
                .Include(a => a.Selection).ThenInclude(a => a.Course)
                .Include(a => a.Selection).ThenInclude(a => a.Teacher)
                .Include(a => a.Evaluates)
                .FirstOrDefault(a => a.SelectionStudentID == id);
        }
    }
}
