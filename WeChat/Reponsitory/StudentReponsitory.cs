﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChat.Context;
using WeChat.IReponsitory;
using WeChat.Models;

namespace WeChat.Reponsitory
{
    public class StudentReponsitory : BaseReponsitory<BaseStudent>, IStudentReponsitory
    {
        public StudentReponsitory(WeChatContext content) : base(content)
        {
        }
    }
}