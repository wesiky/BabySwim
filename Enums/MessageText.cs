using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enums
{
    public class MessageText
    {
        #region 消息框标题
        public const string MESSAGEBOX_CAPTION_TIP = "提示";
        public const string MESSAGEBOX_CAPTION_WARN = "警告";
        public const string MESSAGEBOX_CAPTION_ERROR = "错误";
        #endregion
        #region 导入模板字段
        public const string IMPORT_TEMPLATES_CUSTOMER_CUSTOMERCODE = "客户编号";
        public const string IMPORT_TEMPLATES_CUSTOMER_CUSTOMERNAME = "客户名称";
        public const string IMPORT_TEMPLATES_CUSTOMER_PHONE = "联系号码";
        public const string IMPORT_TEMPLATES_CUSTOMER_AGE = "年龄";
        public const string IMPORT_TEMPLATES_CUSTOMER_BIRTHDAY = "出生日期";
        public const string IMPORT_TEMPLATES_CUSTOMER_COURSEPRICE = "售课价格";
        public const string IMPORT_TEMPLATES_CUSTOMER_INFOSOURCE = "名单来源";
        public const string IMPORT_TEMPLATES_CUSTOMER_FOLLOWINFO = "跟单情况";
        public const string IMPORT_TEMPLATES_CUSTOMER_FOLLOWUSER = "跟单人员";
        public const string IMPORT_TEMPLATES_CUSTOMER_ISVISIT = "到访情况";
        public const string IMPORT_TEMPLATES_CUSTOMER_VISITDATE = "到访日期";
        public const string IMPORT_TEMPLATES_CUSTOMER_DESCRIPTION = "备注";
        #endregion
        #region 通用
        public const string SQL_ERROR_ADD = "第{0}行记录更新失败，请联系管理员！";
        public const string SQL_ERROR_UPDATE = "第{0}行记录更新失败，请联系管理员！";
        public const string TIP_ERROR_ID = "记录ID异常，请联系管理员！错误信息：{0}";
        public const string TIP_ERROR_SELECTCOUNT_ONE = "请选择一条记录后再进行操作！";
        public const string TIP_ERROR_SELECTCOUNT_NULL = "请选择记录后再进行操作！";
        public const string TIP_WARN_DATA_NONE = "操作失败，数据为空";
        public const string TIP_SUCCESS_DELETE = "删除成功";
        public const string TIP_SUCCESS_SAVE = "保存成功";
        public const string TIP_SUCCESS_IMPORT = "导入成功";
        public const string TIP_SUCCESS_GENERATE = "生成成功";
        public const string TIP_FILE_NON_EXIST = "文件不存在";
        public const string TIP_FILE_INVALID = "文件无效，请检查文件是否关闭，格式是否正确";
        public const string LISTITEM_TEXT = "Text";
        public const string LISTITEM_VALUE = "Value";
        public const string LIST_NUMBER_CHINESE = "一二三四五六七八九十百千万亿";
        #region FORMAT
        /// <summary>
        /// 格式：yyyy-MM-dd
        /// </summary>
        public const string FORMAT_DATE = "yyyy-MM-dd";
        public const string FORMAT_DATE_WEEK = "{0}({1})";
        #endregion
        #region KEY
        public const string KEY_ENTER = "\n";
        public const string KEY_COMMA = ",";
        #endregion
        #endregion
        #region 教师
        public const string SQL_ERROR_TEACHER_DELETE = "教师批量删除失败，请联系管理员！";
        public const string SQL_ERROR_TEACHER_UPDATE = "教师{0}修改失败，请联系管理员！";
        public const string SQL_ERROR_TEACHER_ADD = "教师{0}新增失败，请联系管理员！";
        public const string CHECK_ERROR_TEACHER_CODE = "请输入教师编码";
        public const string CHECK_ERROR_TEACHER_NAME = "请输入教师姓名";
        public const string CHECK_ERROR_TEACHER_AGE = "请输入教师年龄，年龄为整数";
        #endregion
        #region 课程
        public const string SQL_ERROR_COURSE_DELETE = "课程批量删除失败，请联系管理员！";
        public const string SQL_ERROR_COURSE_EXIST = "第{0}行课程已存在，添加失败！";
        public const string CHECK_ERROR_COUTSE_NAME = "第{0}行课程名称为空，请输入";
        public const string CHECK_ERROR_COUTSE_MAXCOUNT = "第{0}行最大上课人数有误，请输入整数";
        public const string CHECK_ERROR_COUTSE_MAXSECTION = "第{0}行上课最大节数有误，请输入整数";
        #endregion
        #region 家长
        public const string SQL_ERROR_FAMILY_DELETE = "家长批量删除失败，请联系管理员！";
        public const string SQL_ERROR_FAMILY_EXIST = "第{0}行家长已存在，添加失败！";
        public const string CHECK_ERROR_FAMILY_CODE = "第{0}行家长编号为空，请输入";
        public const string CHECK_ERROR_FAMILY_NAME = "第{0}行家长姓名为空，请输入";
        public const string CHECK_ERROR_FAMILY_COURSECOUNT = "第{0}行剩余课时有误，请输入数字";
        #endregion
        #region 学员
        public const string SQL_ERROR_STUDENT_DELETE = "学员批量删除失败，请联系管理员！";
        public const string SQL_ERROR_STUDENT_EXIST = "第{0}行学员已存在，添加失败！";
        public const string CHECK_ERROR_STUDENT_CODE = "第{0}行学员编号为空，请输入";
        public const string CHECK_ERROR_STUDENT_NAME = "第{0}行学员姓名为空，请输入";
        public const string CHECK_ERROR_STUDENT_NICKNAME = "第{0}行学员昵称为空，请输入";
        public const string CHECK_ERROR_STUDENT_BIRTHDATE = "第{0}行学员出生日期格式不正确，请输入";
        public const string CHECK_ERROR_STUDENT_BIRTHDAY = "第{0}行学员农历生日格式不正确，请输入";
        #endregion
        #region 客户
        public const string SQL_ERROR_CUSTOMER_DELETE = "客户批量删除失败，请联系管理员！";
        public const string SQL_ERROR_CUSTOMER_UPDATE = "客户{0}修改失败，请联系管理员！";
        public const string SQL_ERROR_CUSTOMER_ADD = "客户{0}新增失败，请联系管理员！";
        public const string SQL_ERROR_CUSTOMER_IMPORT = "客户信息导入失败，请联系管理员！";
        public const string CHECK_ERROR_CUSTOMER_CODE = "请输入客户编号";
        public const string CHECK_ERROR_CUSTOMER_NAME = "请输入客户姓名";
        public const string CHECK_ERROR_CUSTOMER_COURSEPRICE = "请输入售课价格，售课价格为为数字";
        public const string CHECK_ERROR_CUSTOMER_IMPORT_CODE = "第{0}行客户编号不能为空";
        public const string CHECK_ERROR_CUSTOMER_IMPORT_NAME = "第{0}行客户姓名不能为空";
        public const string CHECK_ERROR_CUSTOMER_IMPORT_COURSEPRICE = "第{0}售课价格格式有误";
        public const string CHECK_ERROR_CUSTOMER_IMPORT_ISVISIT = "第{0}行到访情况值有误，请输入是/否";
        public const string CHECK_ERROR_CUSTOMER_IMPORT_VISITDATE = "第{0}行到访日期格式有误";
        #endregion
        #region 排课
        public const string HAS_SCHEDULER = "排课";
        public const string SQL_ERROR_SCHEDULER_SAVE = "排课保存失败，请联系管理员！";
        #endregion
        #region 选课
        public const string CHECK_ERROR_SELECTION_TEACHER = "请选择教师";
        public const string CHECK_ERROR_SELECTION_ADVISER = "请选择顾问";
        public const string CHECK_ERROR_SELECTION_SECTIONNO = "请输入课程进度，进度为整数";
        public const string CHECK_ERROR_SELECTION_COURSE = "请选择课程";
        public const string PROGRAM_ERROR_SCHEDULER_DATE = "课表日期异常异常，请联系管理员，错误信息：{0}";
        public const string SQL_ERROR_SELECTION_CLOSE = "关闭课程出错，请联系管理员";
        public const string SUCCESS_SELECTION_CLOSE = "关闭课程成功";
        public const string PROGTAM_ERROR_CONFIRMEDSTUDENT_SAVE = "{0}教室{1}第{2}节已安排其他课程，无法排课";
        public const string SQL_ERROR_GENERATESTUDENTSCHEDULER = "排课数据生成失败，请联系管理员";
        #endregion
        #region 选课学员
        public const string SQL_ERROR_SELECTIONSTUDENT_SAVE = "选课学员数据保存失败";
        public const string SQL_ERROR_SELECTIONSTUDENT_DELETE = "选课学员数据删除失败";
        public const string SQL_ERROR_SELECTIONSTUDENT_SIGNTYPE_SAVE = "学员签到数据保存失败";
        public const string SQL_ERROR_CONFIRMEDSTUDENT_DELETE = "固定选课学员批量删除失败，请联系管理员！";
        public const string TIP_DONT_SAVE_DATA = "数据有修改，确定不保存吗？";
        #endregion
        #region 通知
        public const string SQL_ERROR_COURSENOTICE_GENERATE = "上课通知生成失败";
        public const string SQL_ERROR_BIRTHDAYNOTICE_GENERATE = "生日通知生成失败";
        public const string SQL_ERROR_SCHEDULER_GENERATE = "学员固定选课生成失败";
        public const string TIP_COURSENOTICE_ISGENERATED = "上课通知已生成";
        public const string TIP_BIRTHDAYNOTICE_ISGENERATED = "上课通知已生成";
        public const string TIP_SCHEDULER_ISGENERATED = "排课数据已生成";
        #endregion
        #region 评价
        public const string SQL_ERROR_SELECTIONSTUDENT_EVALUATE_SAVE = "学员评价数据保存失败";
        #endregion
        #region 课程信息
        public const string SQL_ERROR_SELECTIONSTUDENT_UPDATE = "课程信息数据修改失败";
        #endregion
    }
}
