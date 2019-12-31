using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChat.Context
{
    public class WeChatContext : DbContext
    {
        public WeChatContext(DbContextOptions<WeChatContext> options)
            : base(options)
        {
        }

        public DbSet<WeChat.Models.BaseFamily> Families { get; set; }
    }
}
