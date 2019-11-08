using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BabySwim
{
    public class Entry
    {
        public Form CustomerList()
        {
            FrmCustomerList frm = new FrmCustomerList();
            return frm;
        }

        public Form FamilyList()
        {
            FrmFamilyList frm = new FrmFamilyList();
            return frm;
        }

        public Form StudentList()
        {
            FrmStudentList frm = new FrmStudentList();
            return frm;
        }

        public Form TeacherList()
        {
            FrmTeacherList frm = new FrmTeacherList();
            return frm;
        }

        public Form CourseScheduler()
        {
            FrmCourseScheduler frm = new FrmCourseScheduler();
            return frm;
        }

        public Form CourseList()
        {
            FrmCourseList frm = new FrmCourseList();
            return frm;
        }

        public Form CourseSelection()
        {
            FrmCourseSelection frm = new FrmCourseSelection();
            return frm;
        }

        public Form CourseSign()
        {
            FrmCourseSign frm = new FrmCourseSign();
            return frm;
        }

        public Form CourseEvaluate()
        {
            FrmCourseEvaluateSelection frm = new FrmCourseEvaluateSelection();
            return frm;
        }

        public Form SelectionStudentList()
        {
            FrmSelectionStudentList frm = new FrmSelectionStudentList();
            return frm;
        }

        public Form Notice()
        {
            FrmNotice frm = new FrmNotice();
            return frm;
        }

        public Form TeacherReport()
        {
            FrmTeachingReport frm = new FrmTeachingReport();
            return frm;
        }
    }
}
