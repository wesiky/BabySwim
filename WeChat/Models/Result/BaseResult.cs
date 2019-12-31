﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Models.Result
{
    public class BaseResult
    {
        /// <summary>
        /// 结果编码
        /// </summary>
        public int ResultCode { get; set; } = (int)CommonTips.SUCCESS;
        /// <summary>
        /// 结果消息 如果不成功，返回的错误信息
        /// </summary>
        public string ResultMsg { get; set; } = ((int)CommonTips.SUCCESS).ToEnumDescriptionString(typeof(CommonTips));
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public BaseResult()
        {

        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="resultCode">结果代码</param>
        /// <param name="resultMsg">结果信息</param>
        public BaseResult(int resultCode, string resultMsg)
        {
            ResultCode = resultCode;
            ResultMsg = resultMsg;
        }
    }
}
