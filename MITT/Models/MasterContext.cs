﻿using Microsoft.EntityFrameworkCore;

namespace MITT.Models
{
    public class MasterContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            optionsBuilder.UseMySQL(configuration
                ["ConnectionStrings:DefaultConnection"]);
        }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<SkillLevel> SkillLevel { get; set; }
        public DbSet<UserSkill> UserSkill { get; set; }
    }
}
