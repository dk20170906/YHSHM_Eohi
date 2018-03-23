using EohiSHM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EohiSHM.EF.DAL
{
    public class GDBContext<T> : DbContext where T : class
    {
        public GDBContext() : base("EohiSHMDbContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<T> DbSet { get; set; }
        /// <summary>
        /// 评论表
        /// </summary>
        public DbSet<Web_Commentary> Web_Commentary { get; set; }
        /// <summary>
        /// 菜单列表
        /// </summary>
        public DbSet<Web_admin_menu> Web_admin_menu { get; set; }
        /// <summary>
        /// 当前用户表
        /// </summary>
        public DbSet<Web_admin_account> Web_admin_account { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        public DbSet<Web_cms_article> Web_cms_article { get; set; }

        /// <summary>
        /// 网页底部备案信息
        /// </summary>
        public DbSet<ConfOption> ConfOption { get; set; }
        /// <summary>
        /// 招聘表
        /// </summary>
        public DbSet<Web_Recruit> Web_Recruit { get; set; }
    }
}
