using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaAPI.Model
{
    //ef core 使用codeFirst迁移生成数据库
    //在程序包管理器控制台依次执行以下命令
    //Add-Migration Init  //其中Init是你的版本名称
    //update-database Init //更新数据库操作 init为版本名称
    public class TeaContext:DbContext
    {
        public TeaContext() { }

        public TeaContext(DbContextOptions<TeaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //读取json配置文件的字符串的方法（也可以在startup中，项目启动运行时获取）
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connStr = config["ConnectionStrings:DefaultConnection"];

                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsType> GoodsType { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderInfo> OrderInfo { get; set; }
        public DbSet<ShoppingTrolley> ShoppingTrolley { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
