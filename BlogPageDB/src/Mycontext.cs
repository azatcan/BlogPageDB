using BlogPageDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPageDB.src
{
    public class MyContext : DbContext
    {
        public MyContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public MyContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Blog;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<Users> Users { get; set; }

        public DbSet<CV> CV { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<SiteSettings> SiteSettings { get; set; }

    }
}
