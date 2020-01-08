using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeChat.Models;

namespace WeChat.IReponsitory
{
    public interface ISelectionStudentReponsitory : IBaseReponsitory<CourseSelectionStudent>
    {
        IQueryable<CourseSelectionStudent> GetSelectionStudentDetail(Expression<Func<CourseSelectionStudent, bool>> whereLambda);

        CourseSelectionStudent GetSelectionStudent(int id);
    }
}
