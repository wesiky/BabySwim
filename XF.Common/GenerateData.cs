using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace XF.Common
{
    public class GenerateData
    {
        /// <summary>
        /// 是否
        /// </summary>
        /// <returns></returns>
        public static DataTable GetYesNo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text",typeof(string));
            dt.Columns.Add("Value",typeof(bool));
            DataRow dr = dt.NewRow();
            dr["Text"] = "是";
            dr["Value"] = true;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "否";
            dr["Value"] = false;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 是否
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllYesNo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "全部";
            dr["Value"] = -1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "是";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "否";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 开启关闭
        /// </summary>
        /// <returns></returns>
        public static DataTable GetOpenClose()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(bool));
            DataRow dr = dt.NewRow();
            dr["Text"] = "开启";
            dr["Value"] = true;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "关闭";
            dr["Value"] = false;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 显示方式
        /// </summary>
        /// <returns></returns>
        public static DataTable GetShowType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "直接执行方法";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "作为子窗体加载";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "作为弹出框加载";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUserStatus()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "禁止登陆";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "允许登陆";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "锁定";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 成品分类
        /// </summary>
        /// <returns></returns>
        public static DataTable GetProductType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "特殊产品";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "定做产品";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "常规产品";
            dr["Value"] = 3;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "非常用零部件";
            dr["Value"] = 4;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "常用零部件";
            dr["Value"] = 5;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 零部件类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRebelloinType(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "常规报料";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "非常规报料";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "内部报料";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "公斤报料";
            dr["Value"] = 3;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 零部件类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPackageType(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "袋装";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "盒装";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "物料框";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "捆装";
            dr["Value"] = 3;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 安装费类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetInstallFeeType(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "无安装费";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "根据价值";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 安装费类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetPropertyType(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "标准属性";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "附件属性";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "其他属性";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 选课类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSelectionType(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "临时";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "固定";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 签到类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSignType(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "未签到";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "正常";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "迟到";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "早退";
            dr["Value"] = 3;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "请假";
            dr["Value"] = 4;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 岗位
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTeacherType(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "教师";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "顾问";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 教师职位
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTeacherJob(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "教师";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "课程主管";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 顾问职位
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAdviserJob(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "店长";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "销售主管";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "销售";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "市场主管";
            dr["Value"] = 3;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "市场";
            dr["Value"] = 4;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }

        /// <summary>
        /// 教师职位级别
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTeacherJobLevel(bool includeAll)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Text"] = "一级";
            dr["Value"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "二级";
            dr["Value"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "三级";
            dr["Value"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "四级";
            dr["Value"] = 3;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Text"] = "五级";
            dr["Value"] = 4;
            dt.Rows.Add(dr);
            if (includeAll)
            {
                dr = dt.NewRow();
                dr["Text"] = "全部";
                dr["Value"] = -1;
                dt.Rows.InsertAt(dr, 0);
            }
            return dt;
        }
    }
}
