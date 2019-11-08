using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enums
{
    public class PhysicalConstants
    {
        /// <summary>
        /// 数据已存在
        /// </summary>
        public const int SQL_Existed = -1;
        /// <summary>
        /// ID错误
        /// </summary>
        public const int ERROR_ID = -1;
        /// <summary>
        /// 选择记录数错误
        /// </summary>
        public const int ERROR_SELECT_COUNT = -1;

        /// <summary>
        /// 周一到周日
        /// </summary>
        public static readonly string[] DAY_OF_WEEK_CHN = { "周一", "周二", "周三", "周四", "周五", "周六", "周日" };

        /// <summary>
        /// 默认年份
        /// </summary>
        public static readonly int DEFAULT_YEAR = 2019;

        private PhysicalConstants(){}
    }
}
