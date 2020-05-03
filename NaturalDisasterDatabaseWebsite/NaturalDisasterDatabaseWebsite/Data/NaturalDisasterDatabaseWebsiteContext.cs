using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NaturalDisasterDatabaseWebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NaturalDisasterDatabaseWebsite.Models
{
    public class NaturalDisasterDatabaseWebsiteContext : DbContext
    //public class NaturalDisasterDatabaseWebsiteContext : IdentityDbContext<UsersViewModel,UsersRoleViewModel,int>
    //public class NaturalDisasterDatabaseWebsiteContext : IdentityDbContext
    {
        public NaturalDisasterDatabaseWebsiteContext() { }
        public NaturalDisasterDatabaseWebsiteContext(DbContextOptions<NaturalDisasterDatabaseWebsiteContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=Natural_Disaster_Database.db");
        //}

        //为每个实体集创建DbSet属性。在 Entity Framework 中，实体集通常与数据表相对应，具体实体与表中的行相对应
        //在这里可以省略 DbSet<Forum_msgViewModel> 和 DbSet<Science_essayViewModel> 语句，实现的功能没有任何改变。 Entity Framework 会隐式包含这两个实体因为 UsersViewModel 实体引用了 Forum_msgViewModel 实体、Forum_msgViewModel 实体引用了 Science_essayViewModel 实体...
        //当数据库创建完成后， EF 创建一系列数据表，表名默认和 DbSet 属性名相同。 集合属性的名称一般使用复数形式，但不同的开发人员的命名习惯可能不一样，开发人员根据自己的情况确定是否使用复数形式

        //每个 DbSet 将映射到数据库中的一个表
        public DbSet<Science_essayViewModel> Science_essay { get; set; }
        public DbSet<Forum_msgViewModel> Forum_msg { get; set; }
        public DbSet<UsersViewModel> users { get; set; }
        public DbSet<DisasterStyleViewModel> naturalDisasterStyles { get; set; }

        public DbSet<CropBiologicalViewModel> cropBiologicalDisaster { get; set; }
        public DbSet<ForestViewModel> forestBiologicalDisaster { get; set; }
        public DbSet<GeologicalViewModel> geologicalDisaster { get; set; }
        public DbSet<FireViewModel> forestFireDisaster { get; set; }
        public DbSet<FloodViewModel> floodDisaster { get; set; }
        public DbSet<MeteorologyViewModel> meteorologicalDisaster { get; set; }
        public DbSet<MarineViewModel> marineDisaster { get; set; }
        public DbSet<EarthquakeViewModel> earthquakeDisaster { get; set; }
        public DbSet<CropDetailsViewModel> CropDetailList { get; set; }
        public DbSet<ForestDetailsViewModel> ForestDetailList { get; set; }
        public DbSet<GeologyDetailsViewModel> GeologyDetailList { get; set; }
        public DbSet<FireDetailsViewModel> FireDetailList { get; set; }
        public DbSet<FloodDetailsViewModel> FloodDetailList { get; set; }
        public DbSet<QixiangDetailsViewModel> QixiangDetailList { get; set; }
        public DbSet<MarineDetailsViewModel> MarineDetailList { get; set; }
        public DbSet<QuakeDetailsViewModel> QuakeDetailList { get; set; }

        //对NaturalDisasterDatabaseWebsiteContext指定单复|数的表名来覆盖默认的表名    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Science_essayViewModel>().ToTable("science_essay");
            modelBuilder.Entity<Forum_msgViewModel>().ToTable("forum_msg");
            modelBuilder.Entity<UsersViewModel>().ToTable("users");
            modelBuilder.Entity<DisasterStyleViewModel>().ToTable("naturalDisasterStyles");
            modelBuilder.Entity<CropBiologicalViewModel>().ToTable("cropBiologicalDisaster");
            modelBuilder.Entity<ForestViewModel>().ToTable("forestBiologicalDisaster");
            modelBuilder.Entity<GeologicalViewModel>().ToTable("geologicalDisaster");
            modelBuilder.Entity<FireViewModel>().ToTable("forestFireDisaster");
            modelBuilder.Entity<FloodViewModel>().ToTable("floodDisaster");
            modelBuilder.Entity<MeteorologyViewModel>().ToTable("meteorologicalDisaster");
            modelBuilder.Entity<MarineViewModel>().ToTable("marineDisaster");
            modelBuilder.Entity<EarthquakeViewModel>().ToTable("earthquakeDisaster");
            modelBuilder.Entity<CropDetailsViewModel>().ToTable("CropDetailList");
            modelBuilder.Entity<ForestDetailsViewModel>().ToTable("ForestDetailList");
            modelBuilder.Entity<GeologyDetailsViewModel>().ToTable("GeologyDetailList");
            modelBuilder.Entity<FireDetailsViewModel>().ToTable("FireDetailList");
            modelBuilder.Entity<FloodDetailsViewModel>().ToTable("FloodDetailList");
            modelBuilder.Entity<QixiangDetailsViewModel>().ToTable("QixiangDetailList");
            modelBuilder.Entity<MarineDetailsViewModel>().ToTable("MarineDetailList");
            modelBuilder.Entity<QuakeDetailsViewModel>().ToTable("QuakeDetailList");

            //组合键（外键）
            //modelBuilder.Entity<T>().HasKey(x => new { x.xID, x.xID });
        }

    }
}
